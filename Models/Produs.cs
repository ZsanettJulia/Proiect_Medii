using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Tonko_Zsanett_Proiect.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        
        public int? FurnizorID { get; set; }
        public Furnizor? Furnizor { get; set; }
        public int? CumparatID { get; set; }
        public Cumparat? Cumparat { get; set; }

        [Display(Name = "Categorie")]
        public ICollection<ProdusCategory>? ProdusCategories { get; set; }

    }
}
