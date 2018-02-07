using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  public class TamagotchisController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/Tamagotchi/CreateNew")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/Tamagotchi/View")]
    public ActionResult Create()
    {
      TamagotchiVariable myTamagotchi = new TamagotchiVariable(Request.Form["new-tama"]);
      List<TamagotchiVariable> tamas = TamagotchiVariable.GetAll();
      return View("ViewTamas", tamas);
    }

    [HttpGet("/Tamagotchi/{id}")]
    public ActionResult Detail(int id)
    {
      TamagotchiVariable tama = TamagotchiVariable.Find(id);
      if (tama.IsDead()){
        return RedirectToAction("Death",tama);
      } else {
        return View(tama);
      }
    }

    [HttpGet("/Tamagotchi/{id}/Feed")]
    public ActionResult Feed(int id)
    {
      TamagotchiVariable tama = TamagotchiVariable.Find(id);
      tama.GiveFood();
      if (tama.IsDead()){
        return RedirectToAction("Death",tama);
      } else {
        return View("Detail", tama);
      }
    }
    [HttpGet("/Tamagotchi/{id}/Play")]
    public ActionResult Play(int id)
    {
      TamagotchiVariable tama = TamagotchiVariable.Find(id);
      tama.GiveHappy();
      if (tama.IsDead()){
        return RedirectToAction("Death",tama);
      }else{
        return View("Detail", tama);
      }
    }
    [HttpGet("/Tamagotchi/{id}/Sleep")]
    public ActionResult Sleep(int id)
    {
      TamagotchiVariable tama = TamagotchiVariable.Find(id);
      tama.Sleep();
      if (tama.IsDead()){
        return RedirectToAction("Death",tama);
      } else {
        return View("Detail", tama);
      }
    }

    [HttpGet("/Tamagotchi/ViewTamasPass")]
    public ActionResult PassTime()
    {
      List<TamagotchiVariable> tamas = TamagotchiVariable.GetAll();
      foreach (TamagotchiVariable tama in tamas)
      {
        TamagotchiVariable.PassTime();
      }
      return View("ViewTamas", tamas);
    }

    [HttpGet("/Tamagotchi/ViewTama")]
    public ActionResult ViewTamas()
    {
      List<TamagotchiVariable> tamaList = TamagotchiVariable.GetAll();
      return View(tamaList);
    }

    [HttpGet("/Tamagotchi/{id}/Death")]
    public ActionResult Death(int id)
    {
      TamagotchiVariable tama = TamagotchiVariable.Find(id);
      return View(tama);
    }
  }
}
