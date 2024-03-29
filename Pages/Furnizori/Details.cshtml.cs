﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Furnizori
{
    public class DetailsModel : PageModel
    {
        private readonly Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext _context;

        public DetailsModel(Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

      public Furnizor Furnizor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }

            var furnizor = await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);
            if (furnizor == null)
            {
                return NotFound();
            }
            else 
            {
                Furnizor = furnizor;
            }
            return Page();
        }
    }
}
