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
    public class IndexModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public IndexModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        public IList<Exchange> Exchange { get;set; }

        public async Task OnGetAsync()
        {
            Exchange = await _context.Exchange.ToListAsync();
        }
    }
}
