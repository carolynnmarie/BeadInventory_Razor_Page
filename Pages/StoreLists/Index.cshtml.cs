using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Pages.StoreLists{

    public class IndexModel : PageModel{

        private readonly StoreListContext _context;

        public IndexModel(StoreListContext context){
            _context = context;
        }

        public IList<StoreList> StoreList { get;set; }
        public IList<Bead> Bead {get;set;}
        public IList<Finding> Finding {get;set;}
        public IList<StringingMaterial> StringingMaterial {get;set;}

        public async Task OnGetAsync(){
            StoreList = await _context.StoreList.ToListAsync();
            // Bead = await _context.Bead.ToListAsync();
            // Finding = await _context.Finding.ToListAsync();
            // StringingMaterial = await _context.StringingMaterial.ToListAsync();
        }
    }
}
