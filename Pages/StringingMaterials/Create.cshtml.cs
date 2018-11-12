using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StringingMaterials{

    public class CreateModel : PageModel{

        private readonly StringingMaterialContext _context;
        [BindProperty]
        public StringingMaterial StringingMaterial { get; set; }        

        public CreateModel(StringingMaterialContext context){
            _context = context;
        }

        public IActionResult OnGet(){
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){
                return Page();
            }
            _context.StringingMaterial.Add(StringingMaterial);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}