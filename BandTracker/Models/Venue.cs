using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BandTracker;

namespace BandTracker.Models
{

  public class Venue
  {
    // private members
    private int _id;
    private string _name;
    private string _location;
    private int _star;
    private string _hour;
    private string _phone;

    // constructor
    public Venue(string name, string location, int star, string hour, string phone, int id = 0)
    {

      _name = name;
      _location = location;
      _star = star;
      _hour = hour;
      _phone = phone;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetLocation()
    {
      return _location;
    }

    public int GetStar()
    {
      return _star;
    }

    public string GetPhone()
    {
      return _phone;
    }

    // Create
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO venue (name,locations,stars,hours,phone) VALUES (@ItemName,@ItemLocation,@ItemStar,@ItemHour,@ItemPhone);";


      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter location = new MySqlParameter();
      location.ParameterName = "@ItemLocation";
      location.Value = this._location;
      cmd.Parameters.Add(location);

      MySqlParameter star = new MySqlParameter();
      star.ParameterName = "@ItemStar";
      star.Value = this._star;
      cmd.Parameters.Add(star);

      MySqlParameter hour = new MySqlParameter();
      hour.ParameterName = "@ItemHour";
      hour.Value = this._hour;
      cmd.Parameters.Add(hour);

      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@ItemPhone";
      phone.Value = this._phone;
      cmd.Parameters.Add(phone);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    // Read
    public static List<Venue> GetAll()
    {
      List<Venue> MyVenueLists = new List<Venue> {} ;
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText= @"SELECT * from venue;";

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr. GetInt32(0);
        string name = rdr.GetString(1);
        string location = rdr.GetString(2);
        int star = rdr.GetInt32(3);
        string hour = rdr.GetString(4);
        string phone = rdr.GetString(5);
        Venue MyVenue = new Venue(name,location,star,hour,phone,id);
        MyVenueLists.Add(MyVenue);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return MyVenueLists;
    }

    // Delete
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM venue;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static Venue Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM venue WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int VenueId = 0;
      string name = "" ;
      string location = "" ;
      int star = 0 ;
      string hour = "" ;
      string phone = "" ;


      while(rdr.Read())
      {
        VenueId = rdr. GetInt32(0);
        name = rdr.GetString(1);
        location = rdr.GetString(2);
        star = rdr.GetInt32(3);
        hour = rdr.GetString(4);
        phone = rdr.GetString(5);
      }

      Venue MyVenue = new Venue(name,location,star,hour,phone,VenueId);
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return MyVenue;
    }

    public void UpdateDescription(string VenueName, string VenueLocation, int VenueStar , string VenueHour, string VenuePhone)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE venue SET  name=@newName, locations=@newLocation, stars=@newStar, hours=@newHour , phone=@newPhone WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = _id;
      cmd.Parameters.Add(searchId);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = VenueName;
      cmd.Parameters.Add(name);

      MySqlParameter location = new MySqlParameter();
      location.ParameterName = "@newLocation";
      location.Value = VenueLocation;
      cmd.Parameters.Add(location);

      MySqlParameter star = new MySqlParameter();
      star.ParameterName = "@newStar";
      star.Value = VenueStar;
      cmd.Parameters.Add(star);

      MySqlParameter hour = new MySqlParameter();
      hour.ParameterName = "@newHour";
      hour.Value = VenueHour;
      cmd.Parameters.Add(hour);

      MySqlParameter phone = new MySqlParameter();
      phone.ParameterName = "@newPhone";
      phone.Value = VenuePhone;
      cmd.Parameters.Add(phone);
      // VenueTitle, string VenueGenre, string VenueAvailability , string VenuedDueDate, string VenueIssueDate
      cmd.ExecuteNonQuery();

      _name = VenueName;
      _location = VenueLocation;
      _star = VenueStar;
      _hour = VenueHour;
      _phone = VenuePhone;

      if(conn != null)
      {
        conn.Dispose();
      }
    }


    public List<Band> GetBands()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT bands.* FROM venue
                            JOIN bands_venues ON ( venue.id = bands_venues.venue_id)
                            JOIN bands ON ( bands_venues.band_id = bands.id) where venue.id = @venueId;";

      MySqlParameter venueId = new MySqlParameter();
      venueId.ParameterName = "@venueId";
      venueId.Value = _id;
      cmd.Parameters.Add(venueId);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Band> Bands = new List<Band>{};
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string song = rdr.GetString(2);
        Band MyBand = new Band(name,song,id);
        Bands.Add(MyBand);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return Bands;
    }

    public void AddJoinTable(Band newBand)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO bands_venues (band_id,venue_id) VALUES (@bandId,@venueId);";

      MySqlParameter venue_id = new MySqlParameter();
      venue_id.ParameterName = "@venueId";
      venue_id.Value = _id;
      cmd.Parameters.Add(venue_id);

      MySqlParameter Band_id = new MySqlParameter();
      Band_id.ParameterName = "@bandId";
      Band_id.Value = newBand.GetId();
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
