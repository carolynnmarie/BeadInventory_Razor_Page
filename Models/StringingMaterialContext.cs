using Microsoft.EntityFrameworkCore;

namespace BeadDotNetApp.Models{
    public class StringingMaterialContext: DbContext{

        public StringingMaterialContext(DbContextOptions<StringingMaterialContext> options) 
            : base(options){ }

        public DbSet<StringingMaterial> StringingMaterial {get;set;}
    }
}