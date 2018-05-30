using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    //This class in not finished yet. It will led to a lot of warnings in its current state. i Dont know what parts of the class i need to keep to make the app function the way i want it do, therefore i will leave it in its current state for now.
    public class GameCharacter 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the realm.
        /// </summary>
        /// <value>
        /// The realm.
        /// </value>
        [Required]
        public string Realm { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public int Class { get; set; }
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        [Required]
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        [Required]
        public int Level { get; set; }
        [Required]
        public int Race { get; set; }
        [Required]
        public Items Items { get; set; }
        
    }

    public class Items
    {
        public Head Head { get; set; }
        public Neck Neck { get; set; }
        public Shoulder Shoulder { get; set; }
        public Back Back { get; set; }
        public Chest Chest { get; set; }
        public Wrist Wrist { get; set; }
        public Hands Hands { get; set; }
        public Waist Waist { get; set; }
        public Legs Legs { get; set; }
        public Feet Feet { get; set; }
        public Finger1 Finger1 { get; set; }
        public Finger2 Finger2 { get; set; }
        public Trinket1 Trinket1 { get; set; }
        public Trinket2 Trinket2 { get; set; }
        public Mainhand MainHand { get; set; }
        public Offhand OffHand { get; set; }
    }

    public class Head
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }

    }
    public class Stat
    {   
        
        public int stat { get; set; }
        public int Amount { get; set; }
    }

    public class Neck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }

    }
 

    public class Shoulder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }


    public class Back
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }
    public class Stat3
    {
        public int Stat { get; set; }
        public int Amount { get; set; }
    }

    public class Chest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }

    public class Wrist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }
 
    public class Hands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }

    public class Waist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }

    public class Legs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }

    public class Feet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }

    public class Finger1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }


    public class Finger2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }


    public class Trinket1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }
 

    public class Trinket2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
    }
  
    public class Mainhand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
        public Weaponinfo WeaponInfo { get; set; }
    }
    public class Weaponinfo
    {
        public Damage Damage { get; set; }
        public float WeaponSpeed { get; set; }
        public float Dps { get; set; }
    }

    public class Damage
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public float ExactMin { get; set; }
        public float ExactMax { get; set; }
    }

    public class Offhand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public int ItemLevel { get; set; }
        public Stat[] Stats { get; set; }
        public int Armor { get; set; }
        public Weaponinfo1 WeaponInfo { get; set; }
    }
    public class Weaponinfo1
    {
        public Damage1 Damage { get; set; }
        public float WeaponSpeed { get; set; }
        public float Dps { get; set; }
    }

    public class Damage1
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public float ExactMin { get; set; }
        public float ExactMax { get; set; }
    }

}
