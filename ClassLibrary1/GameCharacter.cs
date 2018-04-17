using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    class GameCharacter : INotifyPropertyChanged
    {

        public class Rootobject
        {
            public Character[] Characters { get; set; }
        }

        public class Character
        {
            public string Name { get; set; }
            public int Class { get; set; }
            public int Race { get; set; }
            public int Level { get; set; }
            public string Thumbnail { get; set; }
            public Spec Spec { get; set; }

            public virtual List<Character> Characters { get; set; }
            
        }

        public class Spec
        {
            public string Name { get; set; }
            public string Role { get; set; }
            public string BackgroundImage { get; set; }
            public string Icon { get; set; }
            public string Description { get; set; }
            public int Order { get; set; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
