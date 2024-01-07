using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Tonko_Zsanett_ProiectContext _context;

        public EditModel(Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public List<AssignedCategoryData> AssignedCategoryDataList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(p => p.Furnizor)
                .Include(p => p.ProdusCategories).ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Produs);

            ViewData["FurnizorID"] = new SelectList(_context.Furnizor, "ID", "NumeFurnizor");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsToUpdate = await _context.Produs
                .Include(p => p.Furnizor)
                .Include(p => p.ProdusCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (produsToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Produs>(
                produsToUpdate,
                "Produs",
                p => p.Denumire,
                p => p.Pret,
                p => p.FurnizorID))
            {
                UpdateProdusCategories(_context, selectedCategories, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, produsToUpdate);
            return Page();
        }

        private void PopulateAssignedCategoryData(Tonko_Zsanett_ProiectContext context, Produs produs)
        {
            var allCategories = context.Category;
            var produsCategories = new HashSet<int>(produs.ProdusCategories.Select(pc => pc.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = produsCategories.Contains(cat.ID)
                });
            }
        }

        private void UpdateProdusCategories(Tonko_Zsanett_ProiectContext context, string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.ProdusCategories = new List<ProdusCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var produsCategories = new HashSet<int>(produsToUpdate.ProdusCategories.Select(pc => pc.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategories.Contains(cat.ID))
                    {
                        produsToUpdate.ProdusCategories.Add(new ProdusCategory
                        {
                            ProdusID = produsToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (produsCategories.Contains(cat.ID))
                    {
                        ProdusCategory courseToRemove = produsToUpdate.ProdusCategories.SingleOrDefault(pc => pc.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
