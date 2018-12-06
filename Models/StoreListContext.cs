using Microsoft.EntityFrameworkCore;

namespace BeadDotNetApp.Models{
    
    public class StoreListContext: DbContext{

        public StoreListContext(DbContextOptions<StoreListContext> options) : base(options){ }

        public DbSet<StoreList> StoreList {get;set;}
    }
}