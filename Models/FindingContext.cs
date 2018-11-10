using Microsoft.EntityFrameworkCore;

namespace BeadDotNetApp.Models{
    
    public class FindingContext : DbContext{

        public FindingContext(DbContextOptions<FindingContext> options) : base(options){ }

        public DbSet<Finding> Finding {get;set;}

    }
}