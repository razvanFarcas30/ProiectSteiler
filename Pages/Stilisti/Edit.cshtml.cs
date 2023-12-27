using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Stilisti
{
    public class EditModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public EditModel(ProiectSteiler.Data.ProiectSteilerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stilist Stilist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stilist == null)
            {
                return NotFound();
            }

            var stilist =  await _context.Stilist.FirstOrDefaultAsync(m => m.ID == id);
            if (stilist == null)
            {
                return NotFound();
            }
            Stilist = stilist;
           ViewData["SalonID"] = new SelectList(_context.Salon, "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stilist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StilistExists(Stilist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StilistExists(int id)
        {
          return (_context.Stilist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
