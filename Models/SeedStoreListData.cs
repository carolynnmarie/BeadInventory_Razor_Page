// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace BeadDotNetApp.Models{

//     public class SeedStoreListData{

//         public static void InitializeData(IServiceProvider serviceProvider){
//             using(var sLContext = new StoreListContext(
//                 serviceProvider.GetRequiredService<DbContextOptions<StoreListContext>>())){
//                     if(sLContext.StoreList.Any()){
//                         return;
//                     }
//                     sLContext.StoreList.AddRange();
//                     sLContext.StoreList.AddRange(
//                     new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 10,
//                         Quantity = 20,PricePoint = 0.08M,Brand = "Bead Gallery"},
//                     new Bead{Material = "Adventurine",Shape = "round", Color = "green", SizeMM = 8,
//                         Quantity = 30,PricePoint = 0.05M,Brand = "Bead Gallery"}
//                     );
//                     sLContext.Finding.AddRange(
//                        new Finding{FindingCategory="head pin", Material = "bright silver",
//                         Description="bright silver colored 2 inch head pin",Color="bright silver",
//                         Length_CM=2.0, Price_Point=0.05,Brand="Bead Gallery"}
//                     );
//                     sLContext.StringingMaterial.AddRange(
//                         new StringingMaterial {Category = "Beading Wire", Material="wire with plastic coating",
//                             Color="bright silver",Price_Per_Foot=0.25, Brand = "Beadalon", 
//                             Description= "7 strand silver beading wire"}
//                     );
//                     sLContext.SaveChanges();

//                 }
//         }
//     }
// }
// using(var fContext = new FindingContext(
//                 serviceProvider.GetRequiredService<DbContextOptions<FindingContext>>())){
//                 if(fContext.Finding.Any()){
//                    return;
//                 }
//                 fContext.Finding.AddRange(
//                 new Finding{FindingCategory="head pin", Material = "bright silver",
//                         Description="bright silver colored 2 inch head pin",Color="bright silver",
//                         Length_CM=2.0, Price_Point=0.05,Brand="Bead Gallery"});
//                 fContext.SaveChanges();
//                 };