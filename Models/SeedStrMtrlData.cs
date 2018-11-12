
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BeadDotNetApp.Models{
    
    public static class SeedStrMtrData{

        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new StringingMaterialContext(
                serviceProvider.GetRequiredService<DbContextOptions<StringingMaterialContext>>())){
                    if(context.StringingMaterial.Any()){
                        return;
                    }
                    context.StringingMaterial.AddRange(
                        new StringingMaterial {Category = "Beading Wire", Material="wire with plastic coating",
                            Color="bright silver",Price_Per_Foot=0.25, Brand = "Beadalon", 
                            Description= "7 strand silver beading wire"});
                    context.SaveChanges();
                }
        }
    }
}


// namespace BeadDotNetApp.Models{  

//     public static class SeedData{ 

//         public static void Initialize(IServiceProvider serviceProvider){
//              using (var context = new BeadContext(
//                 serviceProvider.GetRequiredService<DbContextOptions<BeadContext>>())){
//                 if(context.Bead.Any()){
//                     return;
//                 }
//                 context.Bead.AddRange(