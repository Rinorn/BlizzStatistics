using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    /// <summary>
    /// SavedCharacter Class
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class SavedCharacter : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        
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

        public string CharacterInfo
        {
            get => $"{Name}" + Environment.NewLine + $"{ Level}  { ClassName}";
        }
        /*
        [Required]
        public int HeadSlot { get; set; }
        [Required]
        public int NeckSlot { get; set; }
        [Required]
        public int ShoulderSlot { get; set; }
        [Required]
        public int BackSlot { get; set; }
        [Required]
        public int ChestSlot { get; set; }
        [Required]
        public int WristSlot { get; set; }
        [Required]
        public int GlovesSlot { get; set; }
        [Required]
        public int BeltSlot { get; set; }
        [Required]
        public int LegsSlot { get; set; }
        [Required]
        public int FeetSlot { get; set; }
        [Required]
        public int Ring1Slot { get; set; }
        [Required]
        public int Ring2Slot { get; set; }
        [Required]
        public int Trinket1Slot { get; set; }
        [Required]
        public int Trinket2Slot { get; set; }
        [Required]
        public int MainHandSlot { get; set; }
        [Required]
        public int OffhandSlot { get; set; }
        */
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
