﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectSteiler.Data;
using ProiectSteiler.Models;

namespace ProiectSteiler.Pages.Saloane
{
    public class EditModel : PageModel
    {
        private readonly ProiectSteiler.Data.ProiectSteilerContext _context;

        public EditModel(ProiectSteiler.Data.ProiectSteilerContext context)
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

            var salon =  await _context.Salon.FirstOrDefaultAsync(m => m.ID == id);
            if (salon == null)
            {
                return NotFound();
            }
            Salon = salon;
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

            _context.Attach(Salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(Salon.ID))
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

        private bool SalonExists(int id)
        {
          return (_context.Salon?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
