using Microsoft.EntityFrameworkCore;

namespace BeadDotNetApp.Models{
    public class BeadContext : DbContext {

        public BeadContext(DbContextOptions<BeadContext> options)
        : base(options){ }

        public DbSet<Bead> Bead {get; set;}
    }
}
