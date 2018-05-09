using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using ClassLibrary1.Annotations;
using Newtonsoft.Json;

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
        public Head head { get; set; }
        public Neck neck { get; set; }
        public Shoulder shoulder { get; set; }
        public Back back { get; set; }
        public Chest chest { get; set; }
        public Wrist wrist { get; set; }
        public Hands hands { get; set; }
        public Waist waist { get; set; }
        public Legs legs { get; set; }
        public Feet feet { get; set; }
        public Finger1 finger1 { get; set; }
        public Finger2 finger2 { get; set; }
        public Trinket1 trinket1 { get; set; }
        public Trinket2 trinket2 { get; set; }
        public Mainhand mainHand { get; set; }
        public Offhand offHand { get; set; }
    }

    public class Head
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }

    }
    public class Stat
    {   
        
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Neck
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }

    }
 

    public class Shoulder
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }


    public class Back
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }
    public class Stat3
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Chest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }

    public class Wrist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }
 
    public class Hands
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }

    public class Waist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }

    public class Legs
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }

    public class Feet
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }

    public class Finger1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }


    public class Finger2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }


    public class Trinket1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }
 

    public class Trinket2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
    }
  
    public class Mainhand
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
        public Weaponinfo weaponInfo { get; set; }
    }
    public class Weaponinfo
    {
        public Damage damage { get; set; }
        public float weaponSpeed { get; set; }
        public float dps { get; set; }
    }

    public class Damage
    {
        public int min { get; set; }
        public int max { get; set; }
        public float exactMin { get; set; }
        public float exactMax { get; set; }
    }

    public class Offhand
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public Stat[] stats { get; set; }
        public int armor { get; set; }
        public Weaponinfo1 weaponInfo { get; set; }
    }
    public class Weaponinfo1
    {
        public Damage1 damage { get; set; }
        public float weaponSpeed { get; set; }
        public float dps { get; set; }
    }

    public class Damage1
    {
        public int min { get; set; }
        public int max { get; set; }
        public float exactMin { get; set; }
        public float exactMax { get; set; }
    }

}
