using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BeadDotNetApp.Models{
    
    public class SeedFindingData{
        
        public static void InitializeData(IServiceProvider serviceProvider){
            using(var fContext = new FindingContext(
                serviceProvider.GetRequiredService<DbContextOptions<FindingContext>>())){
                if(fContext.Finding.Any()){
                   return;
                }
                fContext.Finding.AddRange(
                new Finding{FindingCategory="head pin", Material = "bright silver",
                        Description="bright silver colored 2 inch head pin",Color="bright silver",
                        Length_CM=2.0, Price_Point=0.05,Brand="Bead Gallery"});
                fContext.SaveChanges();
                };
        }
    }
}