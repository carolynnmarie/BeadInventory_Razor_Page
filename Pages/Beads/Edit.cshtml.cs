using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Beads{

    public class EditModel : PageModel{

        private readonly BeadContext _context;

        public EditModel(BeadContext context){
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

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){
                return Page();
            }
            _context.Attach(Bead).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException){
                if (!BeadExists(Bead.ID)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool BeadExists(int id){
            return _context.Bead.Any(e => e.ID == id);
        }
    }
}
