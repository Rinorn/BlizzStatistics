using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    /// <summary>
    /// RaceClass
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class CharacterRace : INotifyPropertyChanged
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
        /// Gets or sets the faction.
        /// </summary>
        /// <value>
        /// The faction.
        /// </value>
        public string Faction { get; set; }
        /// <summary>
        /// Gets or sets the name of the race.
        /// </summary>
        /// <value>
        /// The name of the race.
        /// </value>
        [Required]
        public string RaceName { get; set; }
        /// <summary>
        /// Gets or sets the race model.
        /// </summary>
        /// <value>
        /// The race model.
        /// </value>
        [Required]
        public string RaceModel { get; set; }
        /// <summary>
        /// Gets or sets the race description.
        /// </summary>
        /// <value>
        /// The race description.
        /// </value>
        [Required]
        public string RaceDescription { get; set; }
        /// <summary>
        /// Gets or sets the faction logo.
        /// </summary>
        /// <value>
        /// The faction logo.
        /// </value>
        [Required]
        public string FactionLogo { get; set; }
    }
}
