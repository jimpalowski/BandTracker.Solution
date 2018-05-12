using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BandTracker.Models;

public class BandsController : Controller
{
  [HttpGet("/bands/view")]
  public ActionResult Views()
  {
    List<Band> MyBands = Band.GetAll();
    if(MyBands.Count != 0)
    {
      return View(MyBands);

    } else {
      return View("CreateForm");
    }
  }

  [HttpGet("/bands/{id}")]
  public ActionResult Results(int id)
  {
    Band MyBand = Band.Find(id);
    List<Venue> MyVenues = MyBand.GetVenues();
    Dictionary<string,object> model = new Dictionary<string,object>();
    model.Add("MyBand",MyBand);
    model.Add("MyVenues",MyVenues);
    return View(model);
  }

  [HttpGet("/bands/create")]
  public ActionResult Create()
  {
    return View("CreateForm");
  }

  [HttpPost("/bands/createform")]
  public ActionResult CreateForm()
  {
    string name = Request.Form["name"];
    string song = Request.Form["song"];
    Band NewBand = new Band(name,song);
    NewBand.Save();
    List<Band> BandLists = Band.GetAll();
    return View("Views",BandLists);
  }

  [HttpPost("/bands/artists/{id}")]
  public ActionResult NewBands(int id)
  {
    string name = Request.Form["name"];
    string song = Request.Form["song"];

    Band NewBand = new Band(name,song);
    NewBand.Save();

    Venue foundVenue = Venue.Find(id);
    foundVenue.AddJoinTable(NewBand);

    List<Band> ListBands = foundVenue.GetBands();

    return View(ListBands);

  }
}
