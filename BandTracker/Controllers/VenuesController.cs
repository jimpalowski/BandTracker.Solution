using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BandTracker.Models;

public class VenuesController : Controller
{
  [HttpPost("/venues/artists/{id}")]
  public ActionResult NewVenue()
  {
    string name = Request.Form["name"];
    return View();
  }
}
