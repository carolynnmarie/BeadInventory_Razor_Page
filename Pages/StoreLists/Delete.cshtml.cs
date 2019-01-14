using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StoreLists
{
    public class DeleteModel : PageModel
    {
        private readonly BeadDotNetApp.Models.StoreListContext _context;

        public DeleteModel(BeadDotNetApp.Models.StoreListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StoreList StoreList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreList = await _context.StoreList.FirstOrDefaultAsync(m => m.ID == id);

            if (StoreList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreList = await _context.StoreList.FindAsync(id);

            if (StoreList != null)
            {
                _context.StoreList.Remove(StoreList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
