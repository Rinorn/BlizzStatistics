using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsContext : DbContext
    {
        public virtual DbSet<CharacterClass> CharacterClasses { get; set; }

        public virtual DbSet<CharacterRace> CharacterRaces { get; set; }

        

        public BlizzStatisticsContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new BlizzStatisticsDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            
        }

        
    }
}
