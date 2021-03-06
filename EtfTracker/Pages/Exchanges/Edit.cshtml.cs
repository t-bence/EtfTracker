using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Exchanges
{
    public class EditModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public EditModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exchange Exchange { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exchange = await _context.Exchange.FirstOrDefaultAsync(m => m.ID == id);

            if (Exchange == null)
            {
                return NotFound();
            }
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

            _context.Attach(Exchange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeExists(Exchange.ID))
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

        private bool ExchangeExists(int id)
        {
            return _context.Exchange.Any(e => e.ID == id);
        }
    }
}
