using EtfTracker.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtfTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Calculator Calculator { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Calculator calculator)
        {
            _logger = logger;
            Calculator = calculator;
        }

        public void OnGet()
        {

        }
    }
}