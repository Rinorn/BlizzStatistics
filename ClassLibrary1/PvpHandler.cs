namespace ClassLibrary1
{
    public class PvpHandler
    {
        /// <summary>
        /// Gets or sets the ranking.
        /// </summary>
        /// <value>
        /// The ranking.
        /// </value>
        public int Ranking { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int Rating { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the realm.
        /// </summary>
        /// <value>
        /// The name of the realm.
        /// </value>
        public string RealmName { get; set; }
        /// <summary>
        /// Gets or sets the race identifier.
        /// </summary>
        /// <value>
        /// The race identifier.
        /// </value>
        public int RaceId { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public int ClassId { get; set; }
        /// <summary>
        /// Gets or sets the faction identifier.
        /// </summary>
        /// <value>
        /// The faction identifier.
        /// </value>
        public int FactionId { get; set; }
        /// <summary>
        /// Gets or sets the season wins.
        /// </summary>
        /// <value>
        /// The season wins.
        /// </value>
        public int SeasonWins { get; set; }
        /// <summary>
        /// Gets or sets the season losses.
        /// </summary>
        /// <value>
        /// The season losses.
        /// </value>
        public int SeasonLosses { get; set; }
    }
    /// <summary>
    /// Object that holds the information from the blizzard api, so that it can be accessed directly from hte api instead of a database.
    /// </summary>
    public class Rootobject
    {
        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public PvpHandler[] Rows { get; set; }
    }
}
