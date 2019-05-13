using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFLib;
using DieRoller.Views;
using DieRoller.EventModels;

namespace DieRoller.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<DataCommitedEvent>
    {
        
        private static PlayerCharacter _Global_Player;
        private static PlayerCharacter _Player_Instance = new PlayerCharacter();
        private Step1ViewModel _step1;
        private Step2ViewModel _step2;
        private DieRollViewModel _DieRoller;
        private IEventAggregator _events;
        //initialize value.
        private string _characterName = _Player_Instance.CharacterName;
        private string _characterRace = _Global_Player.RaceName;

        public string CharacterRace
        {
            get
            {
                return _characterRace;
            }
            set
            {
                _characterRace = value;
                NotifyOfPropertyChange(() => CharacterRace);
            }
        }


        public ShellViewModel(Step1ViewModel step1, Step2ViewModel step2, DieRollViewModel dieRoller, IEventAggregator events)
        {
            _events = events;
            _step1 = step1;
            _step2 = step2;
            _DieRoller = dieRoller;

            //Allows class to listne for gobal events.
            _events.Subscribe(this);
            //Launch Step 1 User Control
            ActivateItem(_step1);
        }
        /// <summary>Singleton Object that stores global Charcter Data</summary>
        public static PlayerCharacter Global_Player
        {
            get
            {
                if(_Global_Player == null)
                {
                    _Global_Player = new PlayerCharacter();
                }
                return _Global_Player;
                
            }
        }

        

        //Refesh data 
        /// <summary>updates local variable/summary>
        public string CharacterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                _characterName = value;
                NotifyOfPropertyChange(() => CharacterName);
            }
        }

        /// <summary>lanuches Die Roller user control</summary>
        public void DieRollPage()
        {
            ActivateItem(_DieRoller);
        }

        /// <summary>lanuches step 1 user control</summary>
        public void Step1Page()
        {
            ActivateItem(_step1);
        }

        /// <summary>lanuches step 2 user control</summary>
        public void Step2Page()
        {
            ActivateItem(_step2);
        }

        //refreshes local fields
        private void updateStatus()
        {
            CharacterName = Global_Player.CharacterName;
            CharacterRace = Global_Player.RaceName;
        }

        /// <summary>
        /// Handels Global Data Commited events from Child View Models.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            updateStatus();
        }
    }//end class
}//end namespace
