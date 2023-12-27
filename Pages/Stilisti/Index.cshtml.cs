using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Stilisti
{
    public class IndexModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public IndexModel(ProiectSteiler.Data.ProiectSteilerContext context)
        {
            _context = context;
        }

        public IList<Stilist> Stilist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stilist != null)
            {
                Stilist = await _context.Stilist
                .Include(s => s.Salon).ToListAsync();
            }
        }
    }
}
