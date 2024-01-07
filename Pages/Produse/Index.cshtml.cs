using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext _context;

        public IndexModel(Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get; set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategoryID { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string searchString)
        {
            ProdusD = new ProdusData();
            CurrentFilter = searchString;
            ProdusD.Produse = await _context.Produs
            .Include(b => b.Furnizor)
            .Include(b => b.ProdusCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                ProdusD.Produse = ProdusD.Produse.Where(s => s.Furnizor.NumeFurnizor.Contains(searchString)

                || s.Furnizor.NumeFurnizor.Contains(searchString)
                || s.Denumire.Contains(searchString));
                if (id != null)
                {
                    ProdusID = id.Value;
                    Produs produs = ProdusD.Produse
                    .Where(i => i.ID == id.Value).Single();
                    ProdusD.Categories = produs.ProdusCategories.Select(s => s.Category);
                }
            }
        }
    }
}
