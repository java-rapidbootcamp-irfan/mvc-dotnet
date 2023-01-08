namespace Webmvc.Models
{
    public class AbsenViewModel
    {
        public int Id { get; set; } 
        public String Name { get; set; }    
        public String Keterangan { get; set; }  
        public int TotalAbsen { get; set; } 

        public AbsenViewModel() 
        {
        } 


        public AbsenViewModel(int id, string name, string keterangan, int totalabsen) 
        {
            Id = id;    
            Name = name;    
            Keterangan = keterangan;
            TotalAbsen = totalabsen;
        } 
    }
}
