using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
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
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
            


            public string PowerType { get; set; }
            [Required]
            public string ClassDescription { get; set; }
            [Required]
            public string ClassModel { get; set; }
            [Required]
            public string ClassIcon { get; set; }
            
            

        
       
    }
}
