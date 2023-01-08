namespace Webmvc.Models
{
    public class NinjaViewModel
    {
        public int Id { get; set; } 
        public String Name { get; set; }    
        public String Color { get; set; }   
        public int Power { get; set; }  

        public NinjaViewModel() 
        {
        } 

        public NinjaViewModel(int id, string name, string color, int power)
        {
            Id=id;
            Name=name;
            Color=color;
            Power=power;
        }   
    }

}
