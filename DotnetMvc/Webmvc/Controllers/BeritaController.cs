using Microsoft.AspNetCore.Mvc;
using Webmvc.Models;
namespace Webmvc.Controllers
{
    public class BeritaController : Controller
    {
        private static List<BeritaViewModel> _beritaViewModel = new List<BeritaViewModel>()
        {
                new BeritaViewModel(1, "Argentina Juara Piala Dunia", "Berita Olah Raga"),
                new BeritaViewModel(2, "Pemerinta menyebuta 2023 Akan menjadi Tahun Yang Gelap", "Berita Ekonomi"),
                new BeritaViewModel(3, "Mie Instan dari Indonesia Ternyata berada hampir diseluruh negara","Berita Kuliner"),
        };
        public IActionResult AddBerita()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveBerita([Bind("Id, Name, Description")] BeritaViewModel berita)
        {
            _beritaViewModel.Add(berita);
            return Redirect("List");
        }

        public IActionResult ListBerita()
        {
            return View(_beritaViewModel);
        }

        public IActionResult EditBerita(int? id)
        {

            BeritaViewModel berita = _beritaViewModel.Find(x => x.Id.Equals(id));
            return View(berita);
        }

        [HttpPost]
        public IActionResult UpdateBerita(int id, [Bind("Id, Name, Description")] BeritaViewModel berita)
        {

            BeritaViewModel beritaOld = _beritaViewModel.Find(x => x.Id.Equals(id));
            _beritaViewModel.Remove(beritaOld);


            _beritaViewModel.Add(berita);
            return Redirect("List");
        }

        public IActionResult DetailBerita(int id)
        {

            BeritaViewModel berita = (
                    from b in _beritaViewModel
                    where b.Id.Equals(id)
                    select b
                ).SingleOrDefault(new BeritaViewModel());
            return View(berita);
        }

        public IActionResult DeleteBerita(int? id)
        {

            BeritaViewModel berita = _beritaViewModel.Find(x => x.Id.Equals(id));

            _beritaViewModel.Remove(berita);

            return Redirect("List");
        }
    }
}

