namespace Tonko_Zsanett_Proiect.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProdusCategory> ProdusCategories { get; set; }
    }
}
