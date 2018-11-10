using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Findings{

    public class EditModel : PageModel{

        private readonly FindingContext _context;

        public EditModel(FindingContext context){
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

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){return Page();
            }
            _context.Attach(Finding).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException){
                if (!FindingExists(Finding.ID)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool FindingExists(int id){
            return _context.Finding.Any(e => e.ID == id);
        }
    }
}
