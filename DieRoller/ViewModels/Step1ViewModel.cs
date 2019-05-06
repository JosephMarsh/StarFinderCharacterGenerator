using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SFLib;
using DieRoller.Models;

namespace DieRoller.ViewModels 
{
    public class Step1ViewModel : Screen
    {
        private static PlayerCharacter _Player = CharacterModel.Character;
        private string _characterName = _Player.CharacterName;

        public string ChraracterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                _characterName = value;
                NotifyOfPropertyChange(() => ChraracterName);
            }
        }


        public void CommitButton()
        {
            _Player.CharacterName = _characterName;
        }
    }
}
