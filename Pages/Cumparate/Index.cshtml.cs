using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tonko_Zsanett_Proiect.Data;
using Tonko_Zsanett_Proiect.Models;

namespace Tonko_Zsanett_Proiect.Pages.Cumparate
{
    public class IndexModel : PageModel
    {
        private readonly Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext _context;

        public IndexModel(Tonko_Zsanett_Proiect.Data.Tonko_Zsanett_ProiectContext context)
        {
            _context = context;
        }

        public IList<Cumparat> Cumparat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cumparat != null)
            {
                Cumparat = await _context.Cumparat
                .Include(c => c.Produs)
                .Include(c => c.User).ToListAsync();
            }
        }
    }
}
