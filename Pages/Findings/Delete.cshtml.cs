using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Findings{

    public class DeleteModel : PageModel{

        private readonly FindingContext _context;

        public DeleteModel(FindingContext context){
            _context = context;
        }

        [BindProperty]
        public Finding Finding { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id){
            if (id == null){
                return NotFound();
            }
            Finding = await _context.Finding.FirstOrDefaultAsync(m => m.ID == id);
            if (Finding == null){
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id){
            if (id == null){
                return NotFound();
            }
            Finding = await _context.Finding.FindAsync(id);
            if (Finding != null){
                _context.Finding.Remove(Finding);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
