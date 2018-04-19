using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClassLibrary1;
namespace BlizzStatistics.App.SampleData
{
    public class SampleData
    {
        public ObservableCollection<GameCharacter> GameCharacters { get; set; }


        public SampleData()
        {
            GameCharacters = new ObservableCollection<GameCharacter>()
            {
                new GameCharacter()
                {
                    Name = "Rinnorn",
                    Class = 1,
                    Race = 1,
                    Level = 110,
                    Thumbnail = "resto",
                    GameCharacters = new List<GameCharacter>()

                },
                new GameCharacter()
                {
                    Name = "Rinnorn2",
                    Class = 1,
                    Race = 1,
                    Level = 110,
                    Thumbnail = "resto",
                    GameCharacters = new List<GameCharacter>()

                },
                new GameCharacter()
                {
                    Name = "Rinnorn3",
                    Class = 1,
                    Race = 1,
                    Level = 110,
                    Thumbnail = "resto",
                    GameCharacters = new List<GameCharacter>()

                },
                new GameCharacter()
                {
                    Name = "Rinnorn4",
                    Class = 1,
                    Race = 1,
                    Level = 110,
                    Thumbnail = "resto",
                    GameCharacters = new List<GameCharacter>()

                },
            };
        }
    }
}