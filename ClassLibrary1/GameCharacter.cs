using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    public class GameCharacter : INotifyPropertyChanged
    {

        protected bool SetField<T>(ref T field, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        public int Class { get; set; }
        public int Race { get; set; }
        public int Level { get; set; }
        public string Thumbnail { get; set; }

        [Required]
        private string _Name;


        public string Name
        {
            get { return Name; }
            set
            {
                if (SetField(ref _Name, value))
                {

                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        public class Rootobject
        {
            public Character[] Characters { get; set; }
        }

        public class Character: INotifyPropertyChanged
        {
            public string Name { get; set; }
            public int Class { get; set; }
            public int Race { get; set; }
            public int Level { get; set; }
            public string Thumbnail { get; set; }
            //public Spec Spec { get; set; }
            public virtual List<Character> Characters { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged1([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
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

        public virtual List<GameCharacter> GameCharacters { get; set; }

        public bool IsValid { get => !string.IsNullOrEmpty(Name); }
    }
}
