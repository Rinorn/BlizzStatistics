using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Equipment
    {
        [Key]
        public int AppDbEquiomentId { get; set; }
        [Required]
        public int BlizzardItemId{ get; set; }
        [Required]
        public string Slot { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public int Ilvl { get; set; }
        [Required]
        public string ArmorType { get; set; }
        public Stat[] Stats { get; set; }
        
    }
}
