using System.ComponentModel.DataAnnotations;

namespace Tonko_Zsanett_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Categorii")]
        public string CategoryName { get; set; }
        public ICollection<ProdusCategory>? ProdusCategories { get; set; }
    }
}
