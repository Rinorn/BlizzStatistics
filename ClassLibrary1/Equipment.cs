using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    public class Equipment : INotifyPropertyChanged
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Slot { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public int Ilvl { get; set; }
        [Required]
        public int ArmorType { get; set; }
        public int MainStat { get; set; }
        public int Stamina { get; set; }
        public int Mastery { get; set; }
        public int Versatility { get; set; }
        public int Crit { get; set; }
        public int Haste { get; set; }
        public int Leech { get; set; }
        public int Armor { get; set; }
        public string ConvertedArmor => $" Armor {Armor}";
        public string ConvertedIlvl => $"Item Level {Ilvl}";
        public int RestrictedToClass { get; set; }
        public string[] RestrictedToStat { get; set; }
        public string EquipmentEffect { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
