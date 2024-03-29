﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Furnizori
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext _context;

        public CreateModel(Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Furnizor Furnizor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Furnizor == null || Furnizor == null)
            {
                return Page();
            }

            _context.Furnizor.Add(Furnizor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
