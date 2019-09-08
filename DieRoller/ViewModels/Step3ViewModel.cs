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

        private int _themeID = _Global_Player.PlayerThemeId;

        private int _selectedTheme = _Global_Player.PlayerThemeId;
        private int _themeAbilityScoreIndex = _Global_Player.ThemeAbilityScoreIndex;

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

        private bool _ability1IsVisable = false;

        


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
                //check to see if a theme has been commited already
                if (_themeID > -1)
                {
                    _selectedTheme = _themeID;
                }
                return _selectedTheme;
            }
            set
            {
                _selectedTheme = value;
                //set theme ID
                ThemeID = _selectedTheme;
                //check to see if Ability score selection is required
                if (_selectedTheme == 9)
                {
                    //Show ability score dropdown
                    Ability1IsVisable = true;
                }
                else
                {
                    //hide ablility score dropdown
                    Ability1IsVisable = false;

                }
                NotifyOfPropertyChange(() => SelectedTheme);

            }
        }

        /// <summary>Int corrisponding the the selected Theme Chosen</summary>
        public int ThemeID
        {
            get
            {
                return _themeID;
            }
            set
            {
                _themeID = value;
                NotifyOfPropertyChange(() => ThemeID);
            }
        }

        /// <summary>property controls the visabiliyt of the ability score dropdown menu</summary>
        public bool Ability1IsVisable
        {
            get
            {
                return _ability1IsVisable;
            }
            set
            {
                _ability1IsVisable = value;
                NotifyOfPropertyChange(() => Ability1IsVisable);
            }
        }

        /// <summary>Stores the ability score modifyed by the theme</summary>
        public int ThemeAbilityScoreIndex
        {
            get
            {
                return _themeAbilityScoreIndex;
            }
            set
            {
                _themeAbilityScoreIndex = value;
            }
        }

        /// <summary>
        /// This Method is bound to the save button with Caliburn Micro
        /// when pressed the button updates the global object with the user's chosen values
        /// </summary>
        public void commit()
        {
            //set theme ID
            _Global_Player.PlayerThemeId = ThemeID;
            //tell anyone listening that the object was updated
            _events.PublishOnUIThread(new DataCommitedEvent());
        }

        /// <summary>
        /// bound to Clear button with Caliburn Micro
        /// </summary>
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

        //manages the state of local fields.
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

        //Method updates ablity score index when a new theme is selected
        private void updateAbilityScores(int themeIndex)
        {
            //check to see if selection is themeless
            if (themeIndex == 9)
            {
                //initialize all properties to 0
                StrAdjust = 0;
                DexAdjust = 0;
                ConAdjust = 0;
                IntAdjust = 0;
                WisAdjust = 0;
                ChaAdjust = 0;

                //update Abiliy score adjustment
                switch (ThemeAbilityScoreIndex)
                {
                    case 0:
                        ChaAdjust = 1;
                        break;
                    case 1:
                        ConAdjust = 1;
                        break;
                    case 2:
                        DexAdjust = 1;
                        break;
                    case 3:
                        IntAdjust = 1;
                        break;
                    case 4:
                        StrAdjust = 1;
                        break;
                    case 5:
                        WisAdjust = 1;
                        break;
                    default:
                        break;
                }
            }
            else
            {

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
