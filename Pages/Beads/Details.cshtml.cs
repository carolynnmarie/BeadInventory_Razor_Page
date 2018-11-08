using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Beads{

    public class DetailsModel : PageModel{

        public Bead Bead { get; set; }
        private readonly BeadContext _context;

        public DetailsModel(BeadContext context){
            _context = context;
        }

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
    }
}
