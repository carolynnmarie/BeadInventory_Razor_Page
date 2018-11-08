using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Beads{

    public class CreateModel : PageModel{

        private readonly BeadContext _context;

        public CreateModel(BeadContext context){
            _context = context;
        }

        public IActionResult OnGet(){
            return Page();
        }

        [BindProperty]
        public Bead Bead { get; set; }

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){return Page();}
            _context.Bead.Add(Bead);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}