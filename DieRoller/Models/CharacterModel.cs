using SFLib;

namespace DieRoller.Models
{
    public class CharacterModel 
    {
        public static PlayerCharacter Character = new PlayerCharacter();  

        public string CharacterName
        {
            get
            {
                return Character.CharacterName;
            }
            set
            {
                Character.CharacterName = value;
            }
        }

    }
}
