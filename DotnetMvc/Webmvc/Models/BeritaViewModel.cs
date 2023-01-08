namespace Webmvc.Models
{
    public class BeritaViewModel
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        public String Description { get; set; } 
        

        public BeritaViewModel() 
        { 
        }

        public BeritaViewModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
