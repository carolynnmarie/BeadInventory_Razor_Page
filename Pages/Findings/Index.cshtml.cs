using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeadDotNetApp.Pages.Findings{
    public class IndexModel : PageModel{

        public IList<Finding> Finding { get;set; }
        public SelectList FindingCategories {get;set;}
        public SelectList Materials {get;set;}
        public string FindingCategory {get;set;}
        public string Material {get;set;}

        private readonly FindingContext _context;

        public IndexModel(FindingContext context){
            _context = context;
        }

        public async Task OnGetAsync(string findingCategory, string material){
            IQueryable<string> fCQuery = from f in _context.Finding orderby f.FindingCategory select f.FindingCategory;
            IQueryable<string> mQuery = from f in _context.Finding orderby f.Material select f.Material;
            var findings = from f in _context.Finding select f;

            FindingCategories = new SelectList(await fCQuery.Distinct().ToListAsync());
            Materials = new SelectList(await mQuery.Distinct().ToListAsync());
            FindingCategory = findingCategory;
            Material = material;

            if(!String.IsNullOrEmpty(findingCategory)){
                findings = findings.Where(f=>f.FindingCategory == findingCategory);
            }
            if(!String.IsNullOrEmpty(material)){
                findings = findings.Where(f=>f.Material == material);
            }
            findings = findings.OrderBy(f =>f.FindingCategory);
            Finding = await findings.ToListAsync();
        }
    }
}
