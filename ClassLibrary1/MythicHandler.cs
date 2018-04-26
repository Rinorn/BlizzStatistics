namespace ClassLibrary1
{
    // Changing the variable names that are simular to leading_groups, wil make the app unable to get the right information from the world of warcraft api. it ill instead return null, and the app wont work as intended 
    /// <summary>
    /// Objects used to access information from the codebehind
    /// </summary>
    public class MythicRootobject
    {

        /// <summary>
        /// Gets or sets the leading groups.
        /// </summary>
        /// <value>
        /// The leading groups.
        /// </value>
        public Leading_Groups[] leading_groups { get; set; }
        /// <summary>
        /// Gets or sets the keystone affixes.
        /// </summary>
        /// <value>
        /// The keystone affixes.
        /// </value>
        public Keystone_Affixes[] keystone_affixes { get; set; }
        
    }
    /// <summary>
    /// The name cant be changed to LeadingGroups, as it will lead to errors when the app attempts to get information from the blizzard api
    /// </summary>
    public class Leading_Groups
    {
        /// <summary>
        /// Gets or sets the ranking.
        /// </summary>
        /// <value>
        /// The ranking.
        /// </value>
        public int Ranking { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public int Duration { get; set; }
        /// <summary>
        /// Gets or sets the completed timestamp.
        /// </summary>
        /// <value>
        /// The completed timestamp.
        /// </value>
        public long completed_timestamp { get; set; }
        /// <summary>
        /// Gets or sets the keystone level.
        /// </summary>
        /// <value>
        /// The keystone level.
        /// </value>
        public int keystone_level { get; set; }
        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>
        /// The members.
        /// </value>
        public Member[] Members { get; set; }
    }
    /// <summary>
    /// Holds the playerMember of every group in Leading_Groups
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public Profile Profile { get; set; }
    }
    /// <summary>
    /// holds information about every playerMember in the Member class
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
    /// <summary>
    /// Holds the Current Keystone affixes
    /// </summary>
    public class Keystone_Affixes
    {
        /// <summary>
        /// Gets or sets the keystone affix.
        /// </summary>
        /// <value>
        /// The keystone affix.
        /// </value>
        public Keystone_Affix keystone_affix { get; set; }
    }
    /// <summary>
    /// Holds the name of the keystone affix
    /// </summary>
    public class Keystone_Affix
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        
    }

    

}
