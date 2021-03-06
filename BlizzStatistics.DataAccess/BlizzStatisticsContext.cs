﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ClassLibrary1;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsContext : DbContext
    {
        /// <summary>
        /// Gets or sets the character classes.
        /// </summary>
        /// <value>
        /// The character classes.
        /// </value>
        public virtual DbSet<CharacterClass> CharacterClasses { get; set; }

        /// <summary>
        /// Gets or sets the character races.
        /// </summary>
        /// <value>
        /// The character races.
        /// </value>
        public virtual DbSet<CharacterRace> CharacterRaces { get; set; }
        /// <summary>
        /// Gets or sets the saved characters.
        /// </summary>
        /// <value>
        /// The saved characters.
        /// </value>
        public virtual DbSet<SavedCharacter> SavedCharacters { get; set; }

        public virtual DbSet<Equipment> Equipments { get; set; }
        


        /// <summary>
        /// Initializes a new instance of the <see cref="BlizzStatisticsContext"/> class.
        /// </summary>
        public BlizzStatisticsContext() : base("BlizzStatistics.Data.Api.Properties.Settings.ConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new BlizzStatisticsDbInitializer());
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ClassLibrary1.Realm> Realms { get; set; }

        public System.Data.Entity.DbSet<ClassLibrary1.ExceptionHandler> ExceptionHandlers { get; set; }
    }
}
