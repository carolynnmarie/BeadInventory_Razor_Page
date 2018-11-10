using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Findings{

    public class DetailsModel : PageModel{

        private readonly FindingContext _context;

        public Finding Finding { get; set; }

        public DetailsModel(FindingContext context){
            _context = context;
        }

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
    }
}
