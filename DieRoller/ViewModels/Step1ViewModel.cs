using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SFLib;
using DieRoller.ViewModels;
using DieRoller.EventModels;

namespace DieRoller.ViewModels 
{
    public class Step1ViewModel : Screen, IHandle<DataCommitedEvent>
    {
        private static PlayerCharacter _Global_Player = ShellViewModel.Global_Player;
        private Information info = new Information();
        private string _playerName = _Global_Player.PlayerName;
        private string _chraracterName = _Global_Player.CharacterName;
        private string _characterConcept = _Global_Player.Concept;
        private string _playerNotes = _Global_Player.Step1Notes;
        private IEventAggregator _events;

        public Step1ViewModel(IEventAggregator events)
        {
            _events = events;
            //Allows class to listen for gobal events.
            _events.Subscribe(this);
        }

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
            //Commit local text fields to the Global Character object 
            _Global_Player.CharacterName = _chraracterName;
            _Global_Player.PlayerName = _playerName;
            _Global_Player.Concept = _characterConcept;
            //make sure not to update global Character object with Instruction text or empty string data.
            if (_playerNotes == "Use this area to save notes about your Character" || string.IsNullOrWhiteSpace(_playerNotes))
            {
                //do not update notes...
            }
            else
            {
                //update notes in Global Character object
                _Global_Player.Step1Notes = PlayerNotes;
            }

            //broadcasts update event to other classes
            _events.PublishOnUIThread(new DataCommitedEvent());
        }//end CommitButton

        /// <summary>
        /// Handels Global Data Commited events from Child View Models.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {

        }

    }//end class
}//end namespace
