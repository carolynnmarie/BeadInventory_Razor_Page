using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StoreLists
{
    public class EditModel : PageModel
    {
        private readonly BeadDotNetApp.Models.StoreListContext _context;

        public EditModel(BeadDotNetApp.Models.StoreListContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StoreList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreListExists(StoreList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoreListExists(int id)
        {
            return _context.StoreList.Any(e => e.ID == id);
        }
    }
}
