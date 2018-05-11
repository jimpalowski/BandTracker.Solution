using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BandTracker.Models;

namespace BandTracker.Test
{
  [TestClass]
  public class BandTrackerTest : IDisposable
  {
    public BandTrackerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
    }
    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }

    [TestMethod]
    public void TestGetAllVenues()
    {
      Venue MyVenue = new Venue("Intro to Football", "Sports", "Available" , "none", "none");
      MyVenue.Save();
      List<Venue> VenueLists = Venue.GetAll();
      Console.WriteLine("Size: " + VenueLists.Count);
      Assert.AreEqual(1,VenueLists.Count);
    }

    [TestMethod]
    public void TestFindVenues()
    {
      Venue newVenue = new Venue("Intro to Sudoku", "Science", "Available", "Later", "Yesterday");
      newVenue.Save();
      Venue foundVenue = Venue.Find(newVenue.GetId());

      Assert.AreEqual("Intro to Sudoku",foundVenue.GetVenueTitle());
    }


    [TestMethod]
    public void TestUpdateVenueDescription()
    {
      Venue newVenue = new Venue("Temp Title", "Genre", "Available", "Later", "Yesterday");
      newVenue.Save();

      newVenue.UpdateDescription("Intro to Machine Learning", "Science", "Not Available", "Now", "Today");
      Venue foundVenue = Venue.Find(newVenue.GetId());

      // Console.WriteLine("Venue Title: " + found.GetVenueTitle());
      Assert.AreEqual("Intro to Machine Learning", foundVenue.GetVenueTitle());

    }

    [TestMethod]
    public void TestCreateAuthors()
    {
      Author MyAuthor = new Author("John Jones",21);
      MyAuthor.Save();
      Assert.AreEqual("John Jones",MyAuthor.GetName());
    }

    [TestMethod]
    public void TestFindAuthors()
    {
      Author newAuthor = new Author("James Bond",45);
      newAuthor.Save();
      Author foundAuthor = Author.Find(newAuthor.GetId());
      Assert.AreEqual("James Bond", foundAuthor.GetName());
    }

    [TestMethod]
    public void TestUpdateAuthorDescription()
    {
      Author newAuthor = new Author("Jose Santos",41);
      newAuthor.Save();

      newAuthor.UpdateDescription("John Doe",41);
      Author foundAuthor = Author.Find(newAuthor.GetId());

      Assert.AreEqual("John Doe",foundAuthor.GetName());
    }

    [TestMethod]
    public void TestVenueGetAllAuthors()
    {
      Venue newVenue = new Venue("Intro to machine learning", "Science", "Not Available" , "None", "None");
      newVenue.Save();
      Author newAuthor = new Author("James Harrison", 45);
      newAuthor.Save();
      newVenue.AddJoinTable(newAuthor);

      List<Author> MyAuthors = newVenue.GetAuthors();
      Assert.AreEqual("James Harrison" , MyAuthors[0].GetName());
    }

    [TestMethod]
    public void TestAuthorGetAllVenues()
    {
      Author newAuthor = new Author("Tom Brady", 40);
      newAuthor.Save();

      Venue newVenue = new Venue("Football Life", "Sports" , "Not Available" , "None", "None");
      newVenue.Save();

      newAuthor.AddJoinTable(newVenue);

      List<Venue> MyVenues = newAuthor.GetVenues();
      Assert.AreEqual("Football Life", MyVenues[0].GetVenueTitle());
    }

  }
}
