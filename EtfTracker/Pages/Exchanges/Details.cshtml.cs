using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Exchanges
{
    public class DetailsModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public DetailsModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

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
    }
}
