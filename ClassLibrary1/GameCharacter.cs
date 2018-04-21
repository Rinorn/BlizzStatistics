using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ClassLibrary1.Annotations;

namespace ClassLibrary1
{
    public class GameCharacter : INotifyPropertyChanged
    {   
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string Server { get; set; }
        [Required]
        public string Class { get; set; }

        [Required]
        public string CurrentMainStat { get; set; }
        [Required]
        public string CurrentPowerStat { get; set; }
        [Required]
        public string CurrentCritStat { get; set; }
        [Required]
        public string CurrentHasteStat { get; set; }
        [Required]
        public string CurrentMasteryStat { get; set; }
        [Required]
        public string CurrentVersatilityStat { get; set; }
        [Required]
        public string CurrentHealthPointStat { get; set; }
        [Required]
        public string CurrentStaminaStat { get; set; }

        public string OptimizedMainStat { get; set; }
        public string OptimizedPowerStat { get; set; }
        public string OptimizedCritStat { get; set; }
        public string OptimizedHasteStat { get; set; }
        public string OptimizedMasteryStat { get; set; }
        public string OptimizedVersatilityStat { get; set; }
        public string OptimizedHealthPointStat { get; set; }
        public string OptimizedStaminaStat { get; set; }

        
        public Item CurrentHeadSlot { get; set; }
        
        public Item CurrentNeckSlot { get; set; }
       
        public Item CurrentShoulderSlot { get; set; }
       
        public Item CurrentBackSlot { get; set; }
       
        public Item CurrentChestSlot { get; set; }
        
        public Item CurrentBracerSlot { get; set; }
       
        public Item CurrentRingSlot1 { get; set; }
        
        public Item CurrentTrinketSlot1 { get; set; }
        
        public Item CurrentGlovesSlot { get; set; }
        
        public Item CurrentBeltslot { get; set; }
       
        public Item CurrentLegsSlot { get; set; }
      
        public Item CurrentFeetSlot { get; set; }
        
        public Item CurrentRingSlot2 { get; set; }
        
        public Item CurrentTrinketSlot2 { get; set; }
        
        public Item CurrentMainHandSlot { get; set; }
        
        public Item CurrentOffHandSlot { get; set; }

        public Item OptimizedHeadSlot { get; set; }
        public Item OptimizedNeckSlot { get; set; }
        public Item OptimizedShoulderSlot { get; set; }
        public Item OptimizedBackSlot { get; set; }
        public Item OptimizedChestSlot { get; set; }
        public Item OptimizedBracerSlot { get; set; }
        public Item OptimizedRingSlot1 { get; set; }
        public Item OptimizedTrinketSlot1 { get; set; }
        public Item OptimizedGlovesSlot { get; set; }
        public Item OptimizedBeltslot { get; set; }
        public Item OptimizedLegsSlot { get; set; }
        public Item OptimizedFeetSlot { get; set; }
        public Item OptimizedRingSlot2 { get; set; }
        public Item OptimizedTrinketSlot2 { get; set; }
        public Item OptimizedMainHandSlot { get; set; }
        public Item OptimizedOffHandSlot { get; set; }

        public virtual List<Item> CurrentItems { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
