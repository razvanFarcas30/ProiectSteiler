using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Saloane
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public DeleteModel(ProiectSteiler.Data.ProiectSteilerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Salon Salon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Salon == null)
            {
                return NotFound();
            }

            var salon = await _context.Salon.FirstOrDefaultAsync(m => m.ID == id);

            if (salon == null)
            {
                return NotFound();
            }
            else 
            {
                Salon = salon;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Salon == null)
            {
                return NotFound();
            }
            var salon = await _context.Salon.FindAsync(id);

            if (salon != null)
            {
                Salon = salon;
                _context.Salon.Remove(Salon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
