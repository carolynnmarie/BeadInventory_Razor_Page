using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeadDotNetApp.Pages.StringingMaterials{

    public class IndexModel : PageModel{

        public IList<StringingMaterial> StringingMaterial { get;set; }
        public SelectList Categories {get;set;}
        public string Category {get;set;}

        private readonly StringingMaterialContext _context;

        public IndexModel(StringingMaterialContext context){
            _context = context;
        }

        public async Task OnGetAsync(string category){
            IQueryable<string> query = from s in _context.StringingMaterial orderby s.Category select s.Category;
            var sMaterials = from s in _context.StringingMaterial select s;
            
            Categories = new SelectList(await query.Distinct().ToListAsync());
            Category = category;

            if(!String.IsNullOrEmpty(category)){ 
                sMaterials = sMaterials.Where(s=>s.Category == category);
            };
            sMaterials = sMaterials.OrderBy(s=>s.Category);
            StringingMaterial = await sMaterials.ToListAsync();
        }
    }
}
