using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StoreLists
{
    public class CreateModel : PageModel
    {
        private readonly BeadDotNetApp.Models.StoreListContext _context;

        public CreateModel(BeadDotNetApp.Models.StoreListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StoreList StoreList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StoreList.Add(StoreList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}