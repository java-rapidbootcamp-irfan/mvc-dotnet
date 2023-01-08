using Microsoft.AspNetCore.Mvc;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class InventoryController : Controller
    {
        private static List<InventoryViewModel> _inventoryViewModel = new List<InventoryViewModel>()
            {
                new InventoryViewModel(1, "Legion", "Intel", 2019 ),
                new InventoryViewModel(2, "Asus ROG", "intel", 2020),
                new InventoryViewModel(3, "Predator", "Raizen", 2018),
            };

        public IActionResult AddInventory()
        {
            return View();
        }

        public IActionResult SaveInventory([Bind("Id, Name, Procecor, Tahun")] InventoryViewModel inventory)
        {
            _inventoryViewModel.Add(inventory);
            return Redirect("List");
        }

        public IActionResult ListInventory()
        {
            return View(_inventoryViewModel);
        }

        public IActionResult EidtInventory(int? id)
        {
            InventoryViewModel inventory = _inventoryViewModel.Find(x => x.Id.Equals(id));
            return View(inventory);
        }

        [HttpPost]

        public IActionResult UpdateInventory(int id, [Bind("Id, Name, Procecor, Tahun")] InventoryViewModel inventory)
        {
            InventoryViewModel inventoryOld = _inventoryViewModel.Find(x => x.Id.Equals(id));
            _inventoryViewModel.Remove(inventoryOld);

            _inventoryViewModel.Add(inventory);
            return Redirect("List");
        }

        public IActionResult DetailInventory(int id)
        {
            InventoryViewModel inventory = (
                from i in _inventoryViewModel
                where i.Id.Equals(id)
                select i).SingleOrDefault(new InventoryViewModel());
            return View(inventory);
        }

        public IActionResult DeleteInventory(int id) 
        {
            InventoryViewModel inventory = _inventoryViewModel.Find(x => x.Id.Equals(id));
            _inventoryViewModel.Remove(inventory);

            return Redirect("List");
        }
    }
}