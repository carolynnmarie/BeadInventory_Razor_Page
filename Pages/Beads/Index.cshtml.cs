using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeadDotNetApp.Pages.Beads{

    public class IndexModel : PageModel{

        public IList<Bead> Bead { get;set; }
        public string SearchString { get; set; }
        public SelectList Materials { get; set; }
        public SelectList Shapes {get; set;}
        public string BeadMaterial { get; set; }
        public string BeadShape {get; set;}

        private readonly BeadContext _context;

        public IndexModel(BeadContext context){
            _context = context;
        }

        public async Task OnGetAsync(string beadMaterial, string beadShape){
            IQueryable<string> mQuery = from b in _context.Bead orderby b.Material select b.Material;
            IQueryable<string> sQuery = from b in _context.Bead orderby b.Shape select b.Shape;
            var beads = from b in _context.Bead select b;
            if (!String.IsNullOrEmpty(beadMaterial)){
                beads = beads.Where(b => b.Material == beadMaterial);
            }
            if(!String.IsNullOrEmpty(beadShape)){
                beads = beads.Where(b => b.Shape == beadShape);
            }
            Materials = new SelectList(await mQuery.Distinct().ToListAsync());
            Shapes = new SelectList(await sQuery.Distinct().ToListAsync());
            Bead = await beads.ToListAsync();
            BeadMaterial = beadMaterial;
            BeadShape = beadShape;
        }
    }
}
