using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BandTracker.Models;

public class VenuesController : Controller
{
  [HttpPost("/venues/artists/{id}")]
  public ActionResult NewVenues(int id)
  {
    string name = Request.Form["name"];
    string location = Request.Form["location"];
    int star = int.Parse(Request.Form["stars"]);
    string hours = Request.Form["hours"];
    string phone = Request.Form["phone"];

    Venue NewVenue = new Venue(name,location,star,hours,phone);
    NewVenue.Save();

    Band MyBand = Band.Find(id);
    MyBand.AddJoinTable(NewVenue);

    List<Venue> ListVenues = MyBand.GetVenues();

    return View(ListVenues);
  }

  [HttpGet("/venues/view")]
  public ActionResult Views()
  {
    List<Venue> VenueLists = Venue.GetAll();
    if( VenueLists.Count != 0 )
    {
      return View(VenueLists);
    } else {
      return View("CreateForm");
    }
  }

  [HttpGet("/venues/{id}")]
  public ActionResult Results(int id)
  {
    Venue MyVenue = Venue.Find(id);
    List<Band> ListOfBands = MyVenue.GetBands();
    Dictionary<string,object> model = new Dictionary<string,object>();
    model.Add("MyVenue", MyVenue);
    model.Add("ListOfBands",ListOfBands);
    return View(model);
  }

  [HttpGet("/venues/create")]
  public ActionResult Create()
  {
    return View("CreateForm");
  }

  [HttpPost("/venues/createform")]
  public ActionResult CreateForm()
  {
    string name = Request.Form["name"];
    string location = Request.Form["location"];
    int star = int.Parse(Request.Form["stars"]);
    string hours = Request.Form["hours"];
    string phone = Request.Form["phone"];

    Venue MyVenue = new Venue(name,location,star,hours,phone);
    MyVenue.Save();
    List<Venue> VenueLists = Venue.GetAll();
    return View("Views",VenueLists);

  }
  [HttpGet("/venues/update/{id}")]
  public ActionResult UpdateForm(int id)
  {
    return View(id);
  }

  [HttpPost("/venues/update")]
  public ActionResult NewForm()
  {
    int id = int.Parse(Request.Form["id"]);
    string name = Request.Form["name"];
    string location = Request.Form["location"];
    int star = int.Parse(Request.Form["stars"]);
    string hours = Request.Form["hours"];
    string phone = Request.Form["phone"];

    Venue foundVenue = Venue.Find(id);
    foundVenue.UpdateDescription(name,location,star,hours,phone);

    List<Venue> MyVenues = Venue.GetAll();
    return View("Views",MyVenues);

  }

}
