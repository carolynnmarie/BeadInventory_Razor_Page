using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.Findings{

    public class CreateModel : PageModel{

        private readonly FindingContext _context;

        public CreateModel(FindingContext context){
            _context = context;
        }

        public IActionResult OnGet(){
            return Page();
        }

        [BindProperty]
        public Finding Finding { get; set; }

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){
                return Page();
            }
            _context.Finding.Add(Finding);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}