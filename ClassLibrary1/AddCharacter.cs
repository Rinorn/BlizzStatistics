using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AddCharacter
    {
        public class CharacterRootobject
        {
            public string name { get; set; }
            public string realm { get; set; }
            public int _class { get; set; }
            public int race { get; set; }
            public int level { get; set; }
            public Items items { get; set; }
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
            public int itemLevel { get; set; }
            public Stat1[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat1
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Shoulder
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat2[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat2
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Back
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat3[] stats { get; set; }
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
            public int itemLevel { get; set; }
            public Stat4[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat4
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Wrist
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }        
            public Stat5[] stats { get; set; }
            public int armor { get; set; } 
        }    
        public class Stat5
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Hands
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }           
            public Stat6[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat6
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Waist
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }         
            public Stat7[] stats { get; set; }
            public int armor { get; set; }            
        }
        public class Stat7
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Legs
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat8[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat8
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Feet
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }          
            public Stat9[] stats { get; set; }
            public int armor { get; set; }  
        }
        public class Stat9
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Finger1
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat10[] stats { get; set; }
            public int armor { get; set; }
        }       
        public class Stat10
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Finger2
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; } 
            public Stat11[] stats { get; set; }
            public int armor { get; set; }         
        }
        public class Stat11
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Trinket1
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }        
            public Stat12[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat12
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Trinket2
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public Stat13[] stats { get; set; }
            public int armor { get; set; }  
        }       
        public class Stat13
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Mainhand
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat14[] stats { get; set; }
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
        public class Stat14
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
        public class Offhand
        {
            public int id { get; set; }
            public string name { get; set; }
            public int itemLevel { get; set; }
            public Stat15[] stats { get; set; }
            public int armor { get; set; }
        }
        public class Stat15
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }
    }
}
