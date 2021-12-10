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
    public class DetailsModel : PageModel
    {
        private readonly EtfTrackerContext _context;

        public DetailsModel(EtfTrackerContext context)
        {
            _context = context;
        }

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
    }
}
