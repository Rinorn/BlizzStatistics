namespace ClassLibrary1
{

    public class MythicRootobject
    {
        public _Links _links { get; set; }
        public Map map { get; set; }
        public int period { get; set; }
        public long period_start_timestamp { get; set; }
        public long period_end_timestamp { get; set; }
        public Connected_Realm connected_realm { get; set; }
        public Leading_Groups[] leading_groups { get; set; }
        public Keystone_Affixes[] keystone_affixes { get; set; }
        public int map_challenge_mode_id { get; set; }
        public string name { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Map
    {
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Connected_Realm
    {
        public string href { get; set; }
    }

    public class Leading_Groups
    {
        public int ranking { get; set; }
        public int duration { get; set; }
        public long completed_timestamp { get; set; }
        public int keystone_level { get; set; }
        public Member[] members { get; set; }
    }

    public class Member
    {
        public Profile profile { get; set; }
        public Faction faction { get; set; }
        public Specialization specialization { get; set; }
    }

    public class Profile
    {
        public string name { get; set; }
        public int id { get; set; }
        public Realm realm { get; set; }
    }

    public class Realm
    {
        public Key key { get; set; }
        public int id { get; set; }
        public string slug { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Faction
    {
        public string type { get; set; }
    }

    public class Specialization
    {
        public Key1 key { get; set; }
        public int id { get; set; }
    }

    public class Key1
    {
        public string href { get; set; }
    }

    public class Keystone_Affixes
    {
        public Keystone_Affix keystone_affix { get; set; }
        public int starting_level { get; set; }
    }

    public class Keystone_Affix
    {
        public Key2 key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key2
    {
        public string href { get; set; }
    }

}
