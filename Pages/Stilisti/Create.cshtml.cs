using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Stilisti
{
    public class CreateModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public CreateModel(ProiectSteiler.Data.ProiectSteilerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SalonID"] = new SelectList(_context.Salon, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Stilist Stilist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stilist == null || Stilist == null)
            {
                return Page();
            }

            _context.Stilist.Add(Stilist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
