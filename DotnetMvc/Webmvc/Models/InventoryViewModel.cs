namespace Webmvc.Models
{
    public class InventoryViewModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Procecor { get; set; }

        public int  Tahun { get; set;}

        public InventoryViewModel() 
        {
        }

        
        public InventoryViewModel(int id, string name, string procecor, int tahun) 
        {
            Id = id;
            Name = name;
            Procecor = procecor;
            Tahun = tahun;
        }
    }
}
