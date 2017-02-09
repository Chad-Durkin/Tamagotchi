using Nancy;
using TamagotchiApp.Objects;
using System.Collections.Generic;

namespace TamagotchiApp
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tamagotchi/all"] = _ => {
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_all.cshtml", allTamagotchis];
      };
      Get["/tamagotchi/new"] = _ => {
        return View["tamagotchi_form.cshtml"];
      };
      Post["/tamagotchi/all"] = _ => {
        Tamagotchi tamagotchi = new Tamagotchi(Request.Form["name"], Request.Form["animal"]);
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["tamagotchi_all.cshtml", allTamagotchis];
      };
      Get["/tamagotchi/{id}"] = parameters => {
        Tamagotchi specificTamagotchi = Tamagotchi.Find(parameters.id);
        return View["specific_tamagotchi.cshtml", specificTamagotchi];
      };
      Post["/tamagotchi/feed/{id}"] = parameters => {
        Tamagotchi specificTamagotchi = Tamagotchi.Find(parameters.id);
        if(specificTamagotchi.GetEnergy() > 0 && specificTamagotchi.GetPlayfulness() > 0)
        {
          specificTamagotchi.Feed();
          return View["specific_tamagotchi.cshtml", specificTamagotchi];
        }
        else
        {
          Tamagotchi.RemoveOne(parameters.id);
          return View["dead_tamagotchi.cshtml", specificTamagotchi];
        }
      };
      Post["/tamagotchi/play/{id}"] = parameters => {
        Tamagotchi specificTamagotchi = Tamagotchi.Find(parameters.id);
        if(specificTamagotchi.GetEnergy() > 0 && specificTamagotchi.GetAppetite() > 0)
        {
          specificTamagotchi.Play();
          return View["specific_tamagotchi.cshtml", specificTamagotchi];
        }
        else
        {
          Tamagotchi.RemoveOne(parameters.id);
          return View["dead_tamagotchi.cshtml", specificTamagotchi];
        }
      };
      Post["/tamagotchi/rest/{id}"] = parameters => {
        Tamagotchi specificTamagotchi = Tamagotchi.Find(parameters.id);
        if(specificTamagotchi.GetAppetite() > 0 && specificTamagotchi.GetPlayfulness() > 0)
        {
          specificTamagotchi.Rest();
          return View["specific_tamagotchi.cshtml", specificTamagotchi];
        }
        else
        {
          Tamagotchi.RemoveOne(parameters.id);
          return View["dead_tamagotchi.cshtml", specificTamagotchi];
        }
      };
    }
  }
}
