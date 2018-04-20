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
    public class CharacterRace : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Faction { get; set; }
        [Required]
        public string RaceName { get; set; }
        [Required]
        public string FactionLogo { get; set; }
    }
}
