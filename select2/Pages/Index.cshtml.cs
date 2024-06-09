
using bl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

namespace select2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
 
        }

        [BindProperty] public List<bl.employee> Employees { get; set; }

        public string Error { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            var result = await bl.employeedata.GetAllDataAsync();
            
            if(!string.IsNullOrEmpty(result.err)) return BadRequest(new {message  = "Employee data Null"});

            Employees = result.data;

            return Page();
        }
    }
}
