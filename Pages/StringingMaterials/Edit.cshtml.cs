using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StringingMaterials{

    public class EditModel : PageModel{

        private readonly BeadDotNetApp.Models.StringingMaterialContext _context;
        [BindProperty]
        public StringingMaterial StringingMaterial { get; set; }        

        public EditModel(BeadDotNetApp.Models.StringingMaterialContext context){
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id){
            if (id == null){
                return NotFound();
            }
            StringingMaterial = await _context.StringingMaterial.FirstOrDefaultAsync(m => m.ID == id);
            if (StringingMaterial == null){
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){
                return Page();
            }
            _context.Attach(StringingMaterial).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException){
                if (!StringingMaterialExists(StringingMaterial.ID)){
                    return NotFound();
                }else{
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool StringingMaterialExists(int id){
            return _context.StringingMaterial.Any(e => e.ID == id);
        }
    }
}
