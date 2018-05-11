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
      Venue MyVenue = new Venue("Sobak Sodo", "2916 Utah Ave S Seattle WA 98204",5 , "8AM-12PM", "(206)532-7293");
      MyVenue.Save();
      List<Venue> VenueLists = Venue.GetAll();
      Console.WriteLine("Size: " + VenueLists.Count);
      Assert.AreEqual(1,VenueLists.Count);
    }

    [TestMethod]
    public void TestFindVenues()
    {
      Venue newVenue = new Venue("Within Sodo", "2916 Utah Ave S Seattle WA 98204",5 , "8AM-12PM", "(206)532-7293");
      newVenue.Save();
      Venue foundVenue = Venue.Find(newVenue.GetId());

      Assert.AreEqual("Within Sodo",foundVenue.GetName());
    }


    [TestMethod]
    public void TestUpdateVenueDescription()
    {
      Venue newVenue = new Venue("Sobak Sodo", "24343 Utah Ave S Seattle WA 98204",5 , "8AM-12PM", "(206)532-7293");
      newVenue.Save();

      newVenue.UpdateDescription("Sobak Sudo", "2916 Utah Ave S Seattle WA 98204",5 , "8AM-12PM", "(206)532-7293");
      Venue foundVenue = Venue.Find(newVenue.GetId());

      // Console.WriteLine("Venue Title: " + found.GetVenueTitle());
      Assert.AreEqual("Sobak Sudo", foundVenue.GetName());

    }

  }
}
