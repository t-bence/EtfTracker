using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Transfers
{
    public class CreateModel : PageModel
    {
        private readonly EtfTracker.Data.EtfTrackerContext _context;

        public CreateModel(EtfTracker.Data.EtfTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Transfer Transfer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transfer.Add(Transfer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
