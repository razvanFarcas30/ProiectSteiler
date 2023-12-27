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
    public class DetailsModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public DetailsModel(ProiectSteiler.Data.ProiectSteilerContext context)
        {
            _context = context;
        }

      public Stilist Stilist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stilist == null)
            {
                return NotFound();
            }

            var stilist = await _context.Stilist.FirstOrDefaultAsync(m => m.ID == id);
            if (stilist == null)
            {
                return NotFound();
            }
            else 
            {
                Stilist = stilist;
            }
            return Page();
        }
    }
}
