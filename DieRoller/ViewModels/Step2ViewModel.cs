using Caliburn.Micro;
using DieRoller.EventModels;
using SFLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieRoller.ViewModels
{
    public class Step2ViewModel : Screen, IHandle<DataCommitedEvent>
    {
        private static PlayerCharacter _Global_Player = ShellViewModel.Global_Player;
        private Information info = new Information();

        //Initialize Values
        private int _str = _Global_Player.AbilityScores[5];
        private int _dex = _Global_Player.AbilityScores[2];
        private int _con = _Global_Player.AbilityScores[1];
        private int _int = _Global_Player.AbilityScores[3];
        private int _wis = _Global_Player.AbilityScores[5];
        private int _cha = _Global_Player.AbilityScores[0];

        private IEventAggregator _events;

        public Step2ViewModel(IEventAggregator events)
        {
            _events = events;
            //Allows class to listen for gobal events.
            _events.Subscribe(this);
        }

        /// <summary>value bound to Str Textbox with Caliburn Micro</summary>
        public int Str
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
                NotifyOfPropertyChange(() => Str);
            }
        }

        /// <summary>value bound to Dex Textbox with Caliburn Micro</summary>
        public int Dex
        {
            get
            {
                return _dex;
            }
            set
            {
                _dex = value;
                NotifyOfPropertyChange(() => Dex);
            }
        }

        /// <summary>value bound to Con Textbox with Caliburn Micro</summary>
        public int Con
        {
            get
            {
                return _con;
            }
            set
            {
                _con = value;
                NotifyOfPropertyChange(() => Con);
            }
        }

        /// <summary>value bound to Int Textbox with Caliburn Micro</summary>
        public int Int
        {
            get
            {
                return _int;
            }
            set
            {
                _int = value;
                NotifyOfPropertyChange(() => Int);
            }
        }

        /// <summary>value bound to Wis Textbox with Caliburn Micro</summary>
        public int Wis
        {
            get
            {
                return _wis;
            }
            set
            {
                _wis = value;
                NotifyOfPropertyChange(() => Wis);
            }
        }

        /// <summary>value bound to Cha Textbox with Caliburn Micro</summary>
        public int Cha
        {
            get
            {
                return _cha;
            }
            set
            {
                _cha = value;
                NotifyOfPropertyChange(() => Cha);  
            }
        }

        private void _updateStatus()
        {
            Str = _Global_Player.AbilityScores[5];
            Dex = _Global_Player.AbilityScores[2];
            Con = _Global_Player.AbilityScores[1];
            Int = _Global_Player.AbilityScores[3];
            Wis = _Global_Player.AbilityScores[5];
            Cha = _Global_Player.AbilityScores[0];

    }


        /// <summary>
        /// Handels Global Data Commited events.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            _updateStatus();
        }

    }
}
