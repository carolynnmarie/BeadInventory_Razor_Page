using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace BeadDotNetApp.Models{  

    public static class SeedData{ 

        public static void Initialize(IServiceProvider serviceProvider){
             using (var context = new BeadContext(
                serviceProvider.GetRequiredService<DbContextOptions<BeadContext>>())){
                if(context.Bead.Any()){
                    return;
                }
                context.Bead.AddRange(
                new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 10,
                        Quantity = 20,PricePoint = 0.08M,Brand = "Bead Gallery"},
                new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 8,
                        Quantity = 30,PricePoint = 0.05M,Brand = "Bead Gallery"},
                new Bead{Material = "Adventurine",Shape = "round", Color = "dark green", SizeMM = 8,
                        Quantity = 10,PricePoint = 0.05M,Brand = "Bead Gallery"},  
                new Bead{Material = "Adventurine",Shape = "round", Color = "light green", SizeMM = 8,
                        Quantity = 15,PricePoint = 0.05M,Brand = "Bead Gallery"},      
                new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 6,
                        Quantity = 20,PricePoint = 0.03M,Brand = "Bead Gallery"},
                new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 4,
                        Quantity = 25,PricePoint = 0.03M,Brand = "Bead Gallery"},
                new Bead{Material= "Hematite",Shape="donut",Color="metallic grey", SizeMM = 12,
                        Quantity = 15, PricePoint = 0.1M, Brand = "Bead Gallery"});
                context.SaveChanges();
                };
            
        }
    }
}