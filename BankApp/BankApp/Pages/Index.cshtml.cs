using BankApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private KursController _kursController;

        public IndexModel(ILogger<IndexModel> logger)
        { 
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}