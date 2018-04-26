using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    /// <summary>
    /// A class for Player Classes
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class CharacterClass : INotifyPropertyChanged
    {

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
        /// Gets or sets the type of the power.
        /// </summary>
        /// <value>
        /// The type of the power.
        /// </value>
        public string PowerType { get; set; }
        /// <summary>
        /// Gets or sets the class description.
        /// </summary>
        /// <value>
        /// The class description.
        /// </value>
        [Required]
        public string ClassDescription { get; set; }
        /// <summary>
        /// Gets or sets the class model.
        /// </summary>
        /// <value>
        /// The class model.
        /// </value>
        [Required]
        public string ClassModel { get; set; }
        /// <summary>
        /// Gets or sets the class icon.
        /// </summary>
        /// <value>
        /// The class icon.
        /// </value>
        [Required]
        public string ClassIcon { get; set; }
    }
}
