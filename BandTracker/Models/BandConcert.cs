using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BandTracker;

namespace BandTracker.Models
{
  public class Band
  {
    // private members
    private int _id;
    private string _name;
    private string _song;

    // constructor
    public Band(string name, string song, int id = 0)
    {
      _name = name;
      _song = song;
      _id = id;
    }

    // getters
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetSong()
    {
      return _song;
    }


    // Create
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO bands (name,songs) VALUES (@ItemName,@ItemSong);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter song = new MySqlParameter();
      song.ParameterName = "@ItemSong";
      song.Value = this._song;
      cmd.Parameters.Add(song);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    // Read
    public static List<Band> GetAll()
    {
      List<Band> MyBandLists = new List<Band> {} ;
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText= @"SELECT * from bands;";

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr. GetInt32(0);
        string name = rdr.GetString(1);
        string song = rdr.GetString(2);
        Band MyBand = new Band(name,song);
        MyBandLists.Add(MyBand);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return MyBandLists;
    }

    // Delete
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM bands;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static Band Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM bands WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BandId = 0;
      string name = "" ;
      string song = "" ;

      while(rdr.Read())
      {
        BandId = rdr. GetInt32(0);
        name = rdr.GetString(1);
        song = rdr.GetString(2);
      }

      Band MyBand = new Band(name,song,BandId);
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return MyBand;
    }

    public List<Venue> GetVenues()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT venue.* FROM bands
                            JOIN bands_venues ON ( bands.id = bands_venues.band_id)
                            JOIN venue ON ( bands_venues.venue_id = venue.id) where bands.id = @banId;";

      MySqlParameter bandId = new MySqlParameter();
      bandId.ParameterName = "@bandId";
      bandId.Value = _id;
      cmd.Parameters.Add(bandId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Venue> Venues = new List<Venue>{};
      while(rdr.Read())
      {
        int id = rdr. GetInt32(0);
        string name = rdr.GetString(1);
        string location = rdr.GetString(2);
        int star = rdr.GetInt32(3);
        string hour = rdr.GetString(4);
        string phone = rdr.GetString(5);
        Venue MyVenue = new Venue(name,location,star,hour,phone,id);
        Venues.Add(MyVenue);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return Venues;
    }

    public void AddJoinTable(Venue newVenue)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO bands_venues (band_id,venue_id) VALUES (@bandId,@venuId);";

      MySqlParameter venue_id = new MySqlParameter();
      venue_id.ParameterName = "@venueId";
      venue_id.Value = newVenue.GetId();
      cmd.Parameters.Add(venue_id);

      MySqlParameter Band_id = new MySqlParameter();
      Band_id.ParameterName = "@bandId";
      Band_id.Value = _id;
      cmd.Parameters.Add(Band_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


  }
}
