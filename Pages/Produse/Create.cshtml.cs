using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Produse
{
    public class CreateModel : ProdusCategoriesPageModel
    {
        private readonly Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext _context;

        public CreateModel(Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID",
"NumeFurnizor");
            var produs = new Produs();
            produs.ProdusCategories = new List<ProdusCategory>();
            PopulateAssignedCategoryData(_context, produs);
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProdus = new Produs();
            if (selectedCategories != null)
            {
                newProdus.ProdusCategories = new List<ProdusCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProdusCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProdus.ProdusCategories.Add(catToAdd);
                }
            }
            Produs.ProdusCategories = newProdus.ProdusCategories;
            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
