using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ClassLibrary1;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsContext : DbContext
    {
        public virtual DbSet<CharacterClass> CharacterClasses { get; set; }

        public virtual DbSet<CharacterRace> CharacterRaces { get; set; }
        public virtual DbSet<SavedCharacter> SavedCharacters { get; set; }


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
