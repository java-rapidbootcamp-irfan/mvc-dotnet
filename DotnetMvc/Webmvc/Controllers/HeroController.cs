using Microsoft.AspNetCore.Mvc;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class HeroController : Controller
    {
        private static List<HeroViewModel> _heroViewModel = new List<HeroViewModel>()
                {
                    new HeroViewModel(1, "Alucard", "Fighter", 10000),
                    new HeroViewModel(2, "Hanabi", "Marsman",15000),
                    new HeroViewModel(3, "Aurora", "Mage", 12000),
                    new HeroViewModel(4, "Franco", "Tank", 50000),
                };
        public IActionResult AddHero() 
        {
            return View();  
        }

        [HttpPost]

        public IActionResult SaveHero([Bind("Id, Name, Role, Power")] HeroViewModel hero) 
        {
            _heroViewModel.Add(hero);
            return Redirect("ListHero");
        }

        public IActionResult ListHero() 
        {
            return View(_heroViewModel);  
        }

        public IActionResult EditHero(int? id) 
        {
            HeroViewModel hero = _heroViewModel.Find(x => x.Id.Equals(id));  
            return View(hero);
        }

        [HttpPost]

        public IActionResult UpdateHero(int id, [Bind("Id, Name, Role, Power")] HeroViewModel hero) 
        {
            HeroViewModel heroOld = _heroViewModel.Find(x => x.Id.Equals(id));
            _heroViewModel.Remove(heroOld); 

            _heroViewModel.Add(hero);
            return Redirect("ListHero");
        }

        public IActionResult DetailHero(int id) 
        {
            HeroViewModel hero = (
                from h in _heroViewModel
                where h.Id.Equals(id)
                select h).SingleOrDefault(new HeroViewModel());
            
            return View(hero);
        }

        public IActionResult DeleteHero(int? id) 
        {
            HeroViewModel hero = _heroViewModel.Find(x => x.Id.Equals(id)); 
            _heroViewModel.Remove(hero);

            return Redirect("ListHero");    
        }


    }

}
       