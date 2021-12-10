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
    public class IndexModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public IndexModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        public IList<EtfPurchase> EtfPurchase { get;set; }

        public async Task OnGetAsync()
        {
            EtfPurchase = await _context.EtfPurchase.ToListAsync();
        }
    }
}
