using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Saloane
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
            ViewData["Stilisti"] = new SelectList(_context.Set<Stilist>(), "ID","Nume");

            
            
            return Page();
        }

        [BindProperty]
        public Salon Salon { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Salon == null || Salon == null)
            {
                return Page();
            }

            _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
