using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OriginalCharacterStats
    {
        public Stats stats { get; set; }
    }

    public class Stats
    {
    public int health { get; set; }
    public string powerType { get; set; }
    public int power { get; set; }
    public int str { get; set; }
    public int agi { get; set; }
    public int Int { get; set; }
    public int sta { get; set; }
    public float crit { get; set; }
    public int critRating { get; set; }
    public float haste { get; set; }
    public int hasteRating { get; set; }
    public float hasteRatingPercent { get; set; }
    public float mastery { get; set; }
    public int masteryRating { get; set; }
    public float leech { get; set; }
    public int versatility { get; set; }
    public int armor { get; set; }   
    }
}
