using System.Collections.Generic;

namespace TamagotchiApp.Objects
{
  public class Tamagotchi
  {
    private string _name;
    private string _animal;
    private int _food;
    private int _attention;
    private int _rest;
    private int _interactCount;

    private int _id;

    private static List<Tamagotchi> _tamagotchiList = new List<Tamagotchi> {};

    public Tamagotchi(string newName, string newAnimal)
    {
      _name = newName;
      _animal = newAnimal;
      _food = 10;
      _attention = 10;
      _rest = 10;
      _interactCount = 0;
      _tamagotchiList.Add(this);
      _id = _tamagotchiList.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetAnimal()
    {
      return _animal;
    }

    public void SetAnimal(string newAnimal)
    {
      _animal = newAnimal;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetAppetite()
    {
      return _food;
    }

    public void SetAppetite(int newFood)
    {
      _food = newFood;
    }

    public int GetPlayfulness()
    {
      return _attention;
    }

    public void SetPlayfulness(int newAttention)
    {
      _attention = newAttention;
    }

    public int GetEnergy()
    {
      return _rest;
    }

    public void SetEnergy(int newRest)
    {
      _rest = newRest;
    }

    public void Feed()
    {
      _food += 3;
      _attention -= 2;
      _rest -= 2;
      _interactCount++;
    }

    public void Play()
    {
      _food -= 2;
      _attention += 3;
      _rest -= 2;
      _interactCount++;
    }

    public void Rest()
    {
      _food = 10;
      _attention = 10;
      _rest = 10;
      _interactCount++;
    }

    public static Tamagotchi Find(int searchId)
    {
      return _tamagotchiList[searchId-1];
    }

    public static List<Tamagotchi> GetAll()
    {
      return _tamagotchiList;
    }

    public static void RemoveOne(int searchId)
    {
      _tamagotchiList.RemoveAt(searchId-1);
    }

    public static void ClearAll()
    {
      _tamagotchiList.Clear();
    }
  }
}
