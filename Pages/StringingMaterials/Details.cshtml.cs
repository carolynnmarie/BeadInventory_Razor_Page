using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StringingMaterials{

    public class DetailsModel : PageModel{

        private readonly StringingMaterialContext _context;
        public StringingMaterial StringingMaterial { get; set; }        

        public DetailsModel(StringingMaterialContext context){
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
    }
}
