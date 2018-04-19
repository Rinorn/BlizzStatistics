using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace BlizzStatistics.DataAccess
{
    public class BlizzStatisticsDbInitializer : DropCreateDatabaseIfModelChanges<BlizzStatisticsContext>
    {
        protected override void Seed(BlizzStatisticsContext context)
        {
            var shaman =
                context.CharacterClasses.Add(new CharacterClass()
                {
                    id = 1,
                    name = "Shaman",
                    classDescription = "Shaman er best"
                });
        base.Seed(context);
        }

    }
}
