namespace Tonko_Zsanett_Proiect.Models
{
    public class Cumparat
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? ProdusID { get; set; }
        public Produs? Produs { get; set; }

    }
}
