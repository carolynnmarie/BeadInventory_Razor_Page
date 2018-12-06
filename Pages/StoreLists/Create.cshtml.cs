using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StoreLists{

    public class CreateModel : PageModel{

        private readonly StoreListContext _context;
        [BindProperty]
        public BeadDotNetApp.Models.StoreList StoreList { get; set; }

        public CreateModel(StoreListContext context){
            _context = context;
        }

        public IActionResult OnGet(){
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if (!ModelState.IsValid){
                return Page();
            }
            _context.StoreList.Add(StoreList);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}