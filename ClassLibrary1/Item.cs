using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Item
    {   
        [Required]
        public string Slot { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Itemlvl { get; set; }
        [Required]
        public string ItemIcon { get; set; }
        public int MainStat { get; set; }
        
        public int CritStat { get; set; }
        public int HasteStat { get; set; }
        public int MasteryStat { get; set; }
        public int VersatilityStat { get; set; }
        public int StaminaStat { get; set; }
        public int ArmorStat { get; set; }

    }
}
