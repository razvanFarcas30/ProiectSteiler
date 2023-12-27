using System.Security.Policy;

namespace ProiectSteiler.Models
{
    public class Stilist
    {
        public int ID { get; set; }
        public string? Nume { get; set; }

        public decimal Pret { get; set; }
        public int? SalonID { get; set; }
        public Salon? Salon { get; set; }


    }
}
