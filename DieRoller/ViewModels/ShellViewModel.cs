using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFLib;
using DieRoller.Views;
using DieRoller.Models;

namespace DieRoller.ViewModels
{
    public class ShellViewModel : Conductor<object>
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
                _Player.CharacterName = value;
                NotifyOfPropertyChange(() => ChraracterName);
            }
        }


        //Page button controll Methods
        public void DieRollPage()
        {
            ActivateItem(new DieRollViewModel());
        }
        public void Step1Page()
        {
            ActivateItem(new Step1ViewModel());
        }

    }//end class
}//end namespace
