using Microsoft.AspNetCore.Mvc;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class NinjaController : Controller
    {
        private static List<NinjaViewModel> _ninjaViewModel = new List<NinjaViewModel>()
        {
            new NinjaViewModel(1, "Ninja Merah", "Merah", 100000),
            new NinjaViewModel(2, "Ninja Merah Muda", "Merah Muda", 850000),
            new NinjaViewModel(3, "Ninja Kuning", "Kuning", 95000),
        };

        public IActionResult AddNinja() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult SaveNinja([Bind("Id, Name, Color, Power")] NinjaViewModel ninja) 
        {
            _ninjaViewModel.Add(ninja);
            return Redirect("listNinja");
        }

        public IActionResult ListNinja() 
        {
            return View(_ninjaViewModel);
        }

        public IActionResult Editninja(int? Id) 
        {
            NinjaViewModel ninja = _ninjaViewModel.Find(x => x.Id.Equals(Id));
            return View(ninja);
        }

        [HttpPost]

        public IActionResult UpdateNinja(int Id, [Bind("Id, Name, Color, Power")] NinjaViewModel ninja) 
        {
            NinjaViewModel ninjaOld = _ninjaViewModel.Find(x => x.Id.Equals(Id));
            _ninjaViewModel.Remove(ninjaOld);

            _ninjaViewModel.Add(ninja);
            return Redirect("ListNinja");
        }

        public IActionResult DetailNinja(int Id) 
        {
            NinjaViewModel ninja = (
                from n in _ninjaViewModel
                where n.Id.Equals(Id)
                select n).SingleOrDefault(new NinjaViewModel());

            return View(ninja);
        }

        public IActionResult DeleteNinja(int? Id) 
        {
            NinjaViewModel ninja = _ninjaViewModel.Find(x => x.Id.Equals(Id));
            _ninjaViewModel.Remove(ninja);

            return Redirect("ListNinja");
        }
    }
}
