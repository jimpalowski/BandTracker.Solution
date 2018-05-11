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
}
