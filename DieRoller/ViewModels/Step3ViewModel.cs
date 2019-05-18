using SFLib;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieRoller.EventModels;

namespace DieRoller.ViewModels
{
    public class Step3ViewModel : Screen, IHandle<DataCommitedEvent>
    {

        private static Character _Global_Player = ShellViewModel.Global_Player;
        private static Information _info = new Information();
        private static Themes _themes = new Themes();

        private int _selectedTheme = _Global_Player.PlayerThemeId;
        private int _selectedAbiliytScore;

        

        private string[] _themeNames = _themes.ThemeNames;
        private string[] _abilityScoreNames = _Global_Player.AbilityNames;

        private int _str = _Global_Player.AbilityScoresWithRacialMods[4];
        private int _dex = _Global_Player.AbilityScoresWithRacialMods[2];
        private int _con = _Global_Player.AbilityScoresWithRacialMods[1];
        private int _int = _Global_Player.AbilityScoresWithRacialMods[3];
        private int _wis = _Global_Player.AbilityScoresWithRacialMods[5];
        private int _cha = _Global_Player.AbilityScoresWithRacialMods[0];

        private int _strAdjust = _Global_Player.ThemeAblityScoreAdjustment[4];
        private int _dexAdjust = _Global_Player.ThemeAblityScoreAdjustment[2];
        private int _conAdjust = _Global_Player.ThemeAblityScoreAdjustment[1];
        private int _intAdjust = _Global_Player.ThemeAblityScoreAdjustment[3];
        private int _wisAdjust = _Global_Player.ThemeAblityScoreAdjustment[5];
        private int _chaAdjust = _Global_Player.ThemeAblityScoreAdjustment[0];

        private IEventAggregator _events;

        /// <summary>
        /// Constructor for View model
        /// </summary>
        /// <param name="events">accepts Event objects</param>
        public Step3ViewModel(IEventAggregator events)
        {
            _events = events;
            //Allows class to listen for gobal events.
            _events.Subscribe(this);
        }

        /// <summary>Bound to ChaAdjust IntUpDown</summary> 
        public int ChaAdjust
        {
            get
            {
                return _chaAdjust;
            }
            set
            {
                _chaAdjust = value;
                NotifyOfPropertyChange(() => ChaAdjust);
            }
        }

        /// <summary>Bound to WisAdjust IntUpDown</summary> 
        public int WisAdjust
        {
            get
            {
                return _wisAdjust;
            }
            set
            {
                _wisAdjust = value;
                NotifyOfPropertyChange(() => WisAdjust);
            }
        }

        /// <summary>Bound to IntAdjust IntUpDown</summary> 
        public int IntAdjust
        {
            get
            {
                return _intAdjust;
            }
            set
            {
                _intAdjust = value;
                NotifyOfPropertyChange(() => IntAdjust);
            }
        }

        /// <summary>Bound to ConAdjust IntUpDown</summary> 
        public int ConAdjust
        {
            get
            {
                return _conAdjust;
            }
            set
            {
                _conAdjust = value;
                NotifyOfPropertyChange(() => ConAdjust);
            }
        }

        /// <summary>Bound to DexAdjust IntUpDown</summary> 
        public int DexAdjust
        {
            get
            {
                return _dexAdjust;
            }
            set
            {
                _dexAdjust = value;
                NotifyOfPropertyChange(() => DexAdjust);
            }
        }

        /// <summary>Bound to StrAdjust IntUpDown</summary> 
        public int StrAdjust
        {
            get
            {
                return _strAdjust;
            }
            set
            {
                _strAdjust = value;
                NotifyOfPropertyChange(() => StrAdjust);
            }
        }

        /// <summary>Bound to Cha Text Box with Caliburn</summary>     
        public int Cha  
        {
            get
            {
                return _cha ;
            }
            set
            {
                _cha  = value;
                NotifyOfPropertyChange(() => Cha);
            }
        }

        /// <summary>Bound to Wis Text Box with Caliburn</summary>
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

        /// <summary>Bound to Int Text Box with Caliburn</summary>
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


        /// <summary>Bound to Con Text Box with Caliburn</summary>
        public int Con
        {
            get
            {
                return _con;
            }
            set
            {
                _con = value;
            }
        }

        /// <summary>Bound to Dex Text Box with Caliburn</summary>
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

        /// <summary>Bound to Str Text Box with Caliburn</summary>
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

        /// <summary>Read only, populates the theme selection dropdown</summary>
        public string[] ThemeNames
        {
            get
            {
                return _themeNames;
            }
        }

        /// <summary>Reade only, populates Ability ComboBox 1 with ability score names</summary>
        public string[] AbilityComboBox1
        {
            get
            {
                return _abilityScoreNames;
            }
        }

        /// <summary>stores the slected item index for the selected theme</summary>
        public int SelectedTheme
        {
            get
            {
                return _selectedTheme;
            }
            set
            {
                _selectedTheme = value;
                NotifyOfPropertyChange(() => SelectedTheme);
            }
        }

        public int AbilityComboBox1Selection
        {
            get
            {
                return _selectedAbiliytScore;
            }
            set
            {
                _selectedAbiliytScore = value;
                NotifyOfPropertyChange(() => AbilityComboBox1Selection);
            }
        }

        public void commit()
        {

        }

        public void Reset()
        {
            //reset ability scores
            Str = _Global_Player.AbilityScoresWithRacialMods[4];
            Dex = _Global_Player.AbilityScoresWithRacialMods[2];
            Con = _Global_Player.AbilityScoresWithRacialMods[1];
            Int = _Global_Player.AbilityScoresWithRacialMods[3];
            Wis = _Global_Player.AbilityScoresWithRacialMods[5];
            Cha = _Global_Player.AbilityScoresWithRacialMods[0];

            //reset selected theme
            SelectedTheme = _Global_Player.PlayerThemeId;

            //reset selection fields

        }

        //manages the stat of local fields.
        private void manageRaceSelectionFields(int themeIndex)
        {
            //check if a theme has been set
            if(themeIndex != -1)
            {
                //change ablility score adjustments 
                StrAdjust = _Global_Player.ThemeAblityScoreAdjustment[4];
                DexAdjust = _Global_Player.ThemeAblityScoreAdjustment[2];
                ConAdjust = _Global_Player.ThemeAblityScoreAdjustment[1];
                IntAdjust = _Global_Player.ThemeAblityScoreAdjustment[3];
                WisAdjust = _Global_Player.ThemeAblityScoreAdjustment[5];
                ChaAdjust = _Global_Player.ThemeAblityScoreAdjustment[0];
            }
        }


        /// <summary>
        /// Handels Global Data Commited events.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            //Refresh Stat blocks
            Reset();
        }

    }//end class
}//end namespace
