namespace ProiectSteiler.Models
{
    public class Salon
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Locatie { get; set; }
        public string Adresa { get; set; }
        
        public string Pret { get; set; }
        public string Categorie { get; set; }

        public ICollection<Stilist>? Stilisti { get; set; }
        

    }
}
