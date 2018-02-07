using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class TamagotchiVariable
  {
    private string _name;
    private static int _foodMeter;
    private static int _happyMeter;
    private static int _sleepMeter;
    private int _id;
    private bool _dead;
    private static List<TamagotchiVariable> _tamas = new List<TamagotchiVariable>{};

    public TamagotchiVariable(string name)
    {
      _name = name;
      _foodMeter = 50;
      _happyMeter = 50;
      _sleepMeter = 50;
      _tamas.Add(this);
      _dead = false;
      _id = _tamas.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetFoodMeter()
    {
      return _foodMeter;
    }

    public int GetHappyMeter()
    {
      return _happyMeter;
    }
    public int GetSleepMeter()
    {
      return _sleepMeter;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<TamagotchiVariable> GetAll()
    {
      return _tamas;
    }
    public static TamagotchiVariable Find(int id)
    {
      return _tamas[id - 1];
    }
    public void SetFoodMeter(int number)
    {
      _foodMeter = number;
    }
    public void SetHappyMeter(int number)
    {
      _happyMeter = number;
    }
    public void SetSleepMeter(int number)
    {
      _sleepMeter = number;
    }

    public static void PassTime()
    {
      _foodMeter += 10;
      _happyMeter -= 10;
      _sleepMeter += 20;
    }

    public void GiveFood()
    {
      _foodMeter -= 5;
      _sleepMeter -= 5;
    }
    public void GiveHappy()
    {
      _happyMeter += 10;
      _sleepMeter += 10;
      _foodMeter += 10;
    }
    public void Sleep()
    {
      _sleepMeter -= 15;
      _happyMeter += 10;
      _foodMeter += 15;
    }
    public bool IsDead()
    {
      if (_happyMeter <= 0 || _sleepMeter >= 100 || _foodMeter >= 100)
      {
        _dead = true;
        return true;
      }
      else
      {
        _dead = false;
        return false;
      }
    }
  }
}
