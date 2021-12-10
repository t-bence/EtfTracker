using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EtfTracker.Data;
using EtfTracker.Models;

namespace EtfTracker.Pages.Etfs
{
    public class CreateModel : PageModel
    {
        private readonly EtfTrackerContext _context;
        
        public CreateModel(EtfTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EtfPurchase EtfPurchase { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EtfPurchase.Add(EtfPurchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
