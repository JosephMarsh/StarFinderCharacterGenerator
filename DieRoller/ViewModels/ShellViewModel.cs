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
        
        private static Character _Global_Player;
        private static Character _Player_Instance = new Character();
        private Step1ViewModel _step1;
        private Step2ViewModel _step2;
        private Step3ViewModel _step3;
        private Step4ViewModel _step4;
        private DieRollViewModel _DieRoller;
        private IEventAggregator _events;
        //initialize value.
        private string _characterName = _Player_Instance.CharacterName;
        private string _characterRace = _Global_Player.RaceName;
        private string _characterthemeName = _Player_Instance.ThemeName;


        public ShellViewModel(Step1ViewModel step1, Step2ViewModel step2, Step3ViewModel step3, Step4ViewModel step4, DieRollViewModel dieRoller, IEventAggregator events)
        {
            _events = events;
            _step1 = step1;
            _step2 = step2;
            _step3 = step3;
            _step4 = step4;
            _DieRoller = dieRoller;

            //Allows class to listne for gobal events.
            _events.Subscribe(this);
            //Launch Step 1 User Control
            ActivateItem(_step1);
        }
        /// <summary>Singleton Object that stores global Charcter Data</summary>
        public static Character Global_Player
        {
            get
            {
                if(_Global_Player == null)
                {
                    _Global_Player = new Character();
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

        public string CharacterTheme
        {
            get
            {
                return _characterthemeName;
            }
            set
            {
                _characterthemeName = value;
                NotifyOfPropertyChange(() => CharacterTheme);
            }
        }

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

        /// <summary>lanuches Die Roller user control</summary>
        public void DieRollPage()
        {
            ActivateItem(_DieRoller);
        }

        /// <summary>lanuches Step 1 user control</summary>
        public void Step1Page()
        {
            ActivateItem(_step1);
        }

        /// <summary>lanuches Step 2 user control</summary>
        public void Step2Page()
        {
            ActivateItem(_step2);
        }

        /// <summary>lanuches Step 3 user control</summary>
        public void Step3Page()
        {
            ActivateItem(_step3);
        }

        /// <summary>lanuches Step 3 user control</summary>
        public void Step4Page()
        {
            ActivateItem(_step4);
        }

        //refreshes local fields
        private void updateStatus()
        {
            CharacterName = Global_Player.CharacterName;
            CharacterRace = Global_Player.RaceName;
            CharacterTheme = Global_Player.ThemeName;
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
