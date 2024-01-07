using System.ComponentModel.DataAnnotations;

namespace Tonko_Zsanett_Proiect.Models
{
    public class Furnizor
    {
        public int ID { get; set; }
        [Display(Name = "Furnizori")]
        public string NumeFurnizor { get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
