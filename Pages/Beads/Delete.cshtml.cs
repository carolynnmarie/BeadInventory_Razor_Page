using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Beads{

    public class DeleteModel : PageModel{

        private readonly BeadContext _context;

        public DeleteModel(BeadContext context){
            _context = context;
        }

        [BindProperty]
        public Bead Bead { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id){
            if (id == null){
                return NotFound();
            }
            Bead = await _context.Bead.FirstOrDefaultAsync(m => m.ID == id);
            if (Bead == null){
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id){
            if (id == null){
                return NotFound();
            }
            Bead = await _context.Bead.FindAsync(id);
            if (Bead != null){
                _context.Bead.Remove(Bead);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
