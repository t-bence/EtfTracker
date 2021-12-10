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
    public class IndexModel : PageModel
    {
        private readonly EtfTrackerContext _context;

        public IndexModel(EtfTrackerContext context)
        {
            _context = context;
        }

        public IList<Transfer> Transfer { get;set; }

        public async Task OnGetAsync()
        {
            Transfer = await _context.Transfer.ToListAsync();
        }
    }
}
