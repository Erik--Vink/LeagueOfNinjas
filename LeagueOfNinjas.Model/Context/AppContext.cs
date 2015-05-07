using LeagueOfNinjas.Model.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LeagueOfNinjas.Model.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Equip> Equip { get; set; }
        public DbSet<Ninja> Ninja { get; set; }    
        public AppContext()
            : base("AppContext") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

    }
}
