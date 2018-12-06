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
        public IList<BeadDotNetApp.Models.StoreList> StoreList { get;set; }

        public IndexModel(BeadDotNetApp.Models.StoreListContext context){
            _context = context;
        }

        public async Task OnGetAsync(){
            StoreList = await _context.StoreList.ToListAsync();
        }
    }
}
