using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatBDWPF
{
    internal class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("DefaultConnection") { }
        public DbSet<Family> Families { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<BreedInformation> BreedInformation { get; set; }
    }
}
