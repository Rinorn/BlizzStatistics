namespace ClassLibrary1
{
    public class PvpHandler
    {
        public int Ranking { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string RealmName { get; set; }
        public int RaceId { get; set; }
        public int ClassId { get; set; }
        public int FactionId { get; set; }
        public int SeasonWins { get; set; }
        public int SeasonLosses { get; set; }
    }
    public class Rootobject
    {
        public PvpHandler[] Rows { get; set; }
    }
}
