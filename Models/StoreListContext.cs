using Microsoft.EntityFrameworkCore;
using BeadDotNetApp.Models;

namespace BeadDotNetApp.Models{
    
    public class StoreListContext: DbContext{

        public StoreListContext(DbContextOptions<StoreListContext> options) : base(options){ }

        public DbSet<StoreList> StoreList {get;set;}


        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<StoreList>().HasMany<Bead>(s => s.beads);
        //     modelBuilder.Entity<StoreList>().HasMany<Finding>(s => s.findings);
        //     modelBuilder.Entity<StoreList>().HasMany<StringingMaterial>(s => s.stringingMaterial);

        // }
    }
}