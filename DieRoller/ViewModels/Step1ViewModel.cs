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
        private Information info = new Information();
        private string _playerName = _Global_Player.PlayerName;
        private string _chraracterName = _Global_Player.CharacterName;
        private string _characterConcept = _Global_Player.Concept;
        private string _playerNotes = _Global_Player.Step1Notes;

        public string InfoBox1
        {
            get
            {
                return info.step1;
            }
        }

        public string PlayerNotes
        {
            get
            {
                return _playerNotes;
            }
            set
            {
                _playerNotes = value;
            }
        }



        /// <summary>local scope only Bound to View Contol of the same name</summary>
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

        /// <summary>local scope only Bound to View Contol of the same name</summary>
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                NotifyOfPropertyChange(() => PlayerName);
            }
        }

        /// <summary>local scope only Bound to View Contol of the same name</summary>
        public string CharacterConcept
        {
            get
            {
                return _characterConcept;
            }
            set
            {
                _characterConcept = value;
                NotifyOfPropertyChange(() => CharacterConcept);
            }
        }

        /// <summary>
        /// Upldates Global Variables
        /// </summary>
        public void CommitButton()
        {

            _Global_Player.CharacterName = _chraracterName;
            _Global_Player.PlayerName = _playerName;
            _Global_Player.Concept = _characterConcept;

            if (_playerNotes == "Use this area to save notes about your Character" || string.IsNullOrEmpty(_playerNotes))
            {
                //do nothing
            }
            else
            {
                _Global_Player.Step1Notes = PlayerNotes;
            }
        }

    }
}
