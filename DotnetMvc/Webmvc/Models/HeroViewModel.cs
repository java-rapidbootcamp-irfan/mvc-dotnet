namespace Webmvc.Models
{
    public class HeroViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Role { get; set; } 
        public int Power { get; set;}

        public HeroViewModel() 
        {
        }

        public HeroViewModel(int id, string name, string role, int power) 
        {
            Id = id;
            Name = name;    
            Role = role;
            Power = power;
        }
    }
}
