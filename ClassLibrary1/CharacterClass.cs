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
    public class CharacterClass : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

            [Required]
            public int id { get; set; }

            [Required]
            public string name { get; set; }
            public string powerType { get; set; }
            [Required]
            public string classDescription { get; set; }
            [Required]
            public string ClassModel { get; set; }
            [Required]
            public string ClassIcon { get; set; }
            
            

        
       
    }
}
