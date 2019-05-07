using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SFLib;
using DieRoller.ViewModels;

namespace DieRoller.ViewModels 
{
    public class Step1ViewModel : Screen
    {
        private static PlayerCharacter _Global_Player = ShellViewModel.Global_Player;


        private string _chraracterName = _Global_Player.CharacterName;

        public string ChraracterName
        {
            get
            {
                return _chraracterName;
            }
            set
            {
                _chraracterName = value;
                NotifyOfPropertyChange(() => ChraracterName);
            }
        }

        public void CommitButton()
        {

            _Global_Player.CharacterName = _chraracterName;
        }

    }
}
