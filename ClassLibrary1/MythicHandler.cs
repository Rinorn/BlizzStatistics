namespace ClassLibrary1
{
    // Changing the variable names that are simular to leading_groups, wil make the app unable to get the right information from the world of warcraft api. it ill instead return null, and the app wont work as intended 
    public class MythicRootobject
    {

        public Leading_Groups[] leading_groups { get; set; }
        public Keystone_Affixes[] keystone_affixes { get; set; }
        
    }
    public class Leading_Groups
    {
        public int Ranking { get; set; }
        public int Duration { get; set; }
        public long completed_timestamp { get; set; }
        public int keystone_level { get; set; }
        public Member[] Members { get; set; }
    }
    public class Member
    {
        public Profile Profile { get; set; }
    }
    public class Profile
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class Keystone_Affixes
    {
        public Keystone_Affix keystone_affix { get; set; }
    }
    public class Keystone_Affix
    {
        public string Name { get; set; }
        
    }

    

}
