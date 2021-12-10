using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Etfs
{
    public class DetailsModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public DetailsModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        public EtfPurchase EtfPurchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EtfPurchase = await _context.EtfPurchase.FirstOrDefaultAsync(m => m.ID == id);

            if (EtfPurchase == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
