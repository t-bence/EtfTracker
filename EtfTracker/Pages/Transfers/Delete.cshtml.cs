using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Transfers
{
    public class DeleteModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public DeleteModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transfer Transfer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transfer = await _context.Transfer.FirstOrDefaultAsync(m => m.ID == id);

            if (Transfer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transfer = await _context.Transfer.FindAsync(id);

            if (Transfer != null)
            {
                _context.Transfer.Remove(Transfer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
