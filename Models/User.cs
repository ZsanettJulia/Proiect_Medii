using System.ComponentModel.DataAnnotations;

namespace Tonko_Zsanett_Proiect.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Nume complet")]
        public string? Numecomplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Cumparat>? Cumparate { get; set; }
    }
}

