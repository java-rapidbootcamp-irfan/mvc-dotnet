using Microsoft.AspNetCore.Mvc;
using Webmvc.Models;
namespace Webmvc.Controllers
{
    public class AbsenController : Controller
    {
        private static List<AbsenViewModel> _absenViewModel = new List<AbsenViewModel>()
            {
                new AbsenViewModel(1, "irfan", "Hadir", 3),
                new AbsenViewModel(2, "Budi", "Izin", 2),
                new AbsenViewModel(3, "Diego", "Sakit", 4),
            };

        public IActionResult AddAbsen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, Keterangan, TotalAbsen")] AbsenViewModel absen)
        {
            _absenViewModel.Add(absen);
            return Redirect("List");
        }

        public IActionResult ListAbsen()
        {
            return View(_absenViewModel);
        }

        public IActionResult EditAbsen(int? id)
        {
           
            AbsenViewModel absen = _absenViewModel.Find(x => x.Id.Equals(id));
            return View(absen);
        }

        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Keterangan, TotalAbsen")] AbsenViewModel absen)
        {
            
            AbsenViewModel absenOld = _absenViewModel.Find(x => x.Id.Equals(id));
            _absenViewModel.Remove(absenOld);

            
            _absenViewModel.Add(absen);
            return Redirect("List");
        }

        public IActionResult DetailAbsen(int id)
        {

            AbsenViewModel absen = (
                    from a in _absenViewModel
                    where a.Id.Equals(id)
                    select a
                ).SingleOrDefault(new AbsenViewModel());
            return View(absen);
        }

        public IActionResult Delete(int? id)
        {
            
            AbsenViewModel absen = _absenViewModel.Find(x => x.Id.Equals(id));
          
            _absenViewModel.Remove(absen);

            return Redirect("List");
        }
    }
}

