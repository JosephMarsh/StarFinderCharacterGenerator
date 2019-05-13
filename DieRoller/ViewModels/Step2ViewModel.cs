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
        private static Information _info = new Information();

        //Initialize Values
        private int _str = _Global_Player.AbilityScores[4];
        private int _dex = _Global_Player.AbilityScores[2];
        private int _con = _Global_Player.AbilityScores[1];
        private int _int = _Global_Player.AbilityScores[3];
        private int _wis = _Global_Player.AbilityScores[5];
        private int _cha = _Global_Player.AbilityScores[0];

        private int _strAdjust = _Global_Player.RacialAbilityScoreAdjustment[4];
        private int _dexAdjust = _Global_Player.RacialAbilityScoreAdjustment[2];
        private int _conAdjust = _Global_Player.RacialAbilityScoreAdjustment[1];
        private int _intAdjust = _Global_Player.RacialAbilityScoreAdjustment[3];
        private int _wisAdjust = _Global_Player.RacialAbilityScoreAdjustment[5];
        private int _chaAdjust = _Global_Player.RacialAbilityScoreAdjustment[0];

        //stores chosen raceID of player defualt returns -1
        private int _raceID = _Global_Player.CharacterRaceId;

        //default is  {0, 0, 0, 0, 0, 0}
        private static int[] _currentRaceAbilityScoreAdjusment = _Global_Player.RacialAbilityScoreAdjustment;

        private string[] _raceNames = _Global_Player.raceNames;
        private int _selectedRace = -1;

        private string _infoBox1 = _info.step2;

        private string[] _bonusComboBox1 = _Global_Player.skillNames;
        private string[] _bonusComboBox2 = _Global_Player.skillNames;
        private string[] _bonusComboBox3 = _Global_Player.skillNames;

        private int _bonusComboBox1Selection = -1;
        private int _bonusComboBox2Selection = -1;
        private int _bonusComboBox3Selection = -1;

        private bool _controlBonus1IsVisable = false;
        private bool _controlBonus2IsVisable = false;
        private bool _controlBonus3IsVisable = false;

        private bool _skill1IsEnabled = true;
        private bool _skill2IsEnabled = true;
        private bool _skill3IsEnabled = true;

        private IEventAggregator _events;

        /// <summary>
        /// Constructor for View model
        /// </summary>
        /// <param name="events">accepts Event objects</param>
        public Step2ViewModel(IEventAggregator events)
        {
            _events = events;
            //Allows class to listen for gobal events.
            _events.Subscribe(this);
        }

        /// <summary>value bound to Str Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Dex Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Con Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Int Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Wis Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Cha Textbox with Caliburn Micro</summary>
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

        /// <summary>value bound to Skill Border with Caliburn Micro</summary>
        public bool ControlBonus1IsVisable
        {
            get
            {
                return _controlBonus1IsVisable;
            }
            set
            {
                _controlBonus1IsVisable = value;
                NotifyOfPropertyChange(() => ControlBonus1IsVisable);
            }
        }

        /// <summary>value bound to Skill Border with Caliburn Micro</summary>
        public bool ControlBonus2IsVisable
        {
            get
            {
                return _controlBonus2IsVisable;
            }
            set
            {
                _controlBonus2IsVisable = value;
                NotifyOfPropertyChange(() => ControlBonus2IsVisable);
            }
        }

        /// <summary>value bound to Skill Border with Caliburn Micro</summary>
        public bool ControlBonus3IsVisable
        {
            get
            {
                return _controlBonus3IsVisable;
            }
            set
            {
                _controlBonus3IsVisable = value;
                NotifyOfPropertyChange(() => ControlBonus3IsVisable);
            }
        }

        /// <summary>value bound to Skill Combobox  Item Source</summary>
        public string[] BonusComboBox1
        {
            get
            {
                return _bonusComboBox1;
            }
        }

        /// <summary>value bound to Skill Combobox  Item Source</summary>
        public string[] BonusComboBox2
        {
            get
            {
                return _bonusComboBox2;
            }
        }

        /// <summary>value bound to Skill Combobox Item Source</summary>
        public string[] BonusComboBox3
        {
            get
            {
                return _bonusComboBox3;
            }
        }

        /// <summary>value bound to Skill Combobox Item Selection</summary>
        public int BonusComboBox3Selection
        {
            get
            {
                return _bonusComboBox3Selection;
            }
            set
            {
                _bonusComboBox3Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox3Selection);
            }
        }

        /// <summary>value bound to Skill Combobox Item Selection</summary>
        public int BonusComboBox2Selection
        {
            get
            {
                return _bonusComboBox2Selection;
            }
            set
            {
                _bonusComboBox2Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox2Selection);
            }
        }

        /// <summary>value bound to Skill Combobox Item Selection</summary>
        public int BonusComboBox1Selection
        {
            get
            {
                return _bonusComboBox1Selection;
            }
            set
            {
                _bonusComboBox1Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox1Selection);
            }
        }

        /// <summary>Value enables and disables Skill Selection Combobox</summary>
        public bool Skill1IsEnabled
        {
            get
            {
                return _skill1IsEnabled;
            }
            set
            {
                _skill1IsEnabled = value;
                NotifyOfPropertyChange(() => Skill1IsEnabled);
            }
        }

        /// <summary>Value enables and disables Skill Selection Combobox</summary>
        public bool Skill2IsEnabled
        {
            get
            {
                return _skill2IsEnabled;
            }
            set
            {
                _skill2IsEnabled = value;
                NotifyOfPropertyChange(() => Skill2IsEnabled);
            }
        }

        /// <summary>Value enables and disables Skill Selection Combobox</summary>
        public bool Skill3IsEnabled
        {
            get
            {
                return _skill3IsEnabled;
            }
            set
            {
                _skill3IsEnabled = value;
                NotifyOfPropertyChange(() => Skill3IsEnabled);
            }
        }

        /// <summary>Value Bound to the information text box by Caliburn Micro</summary>
        public string TextBoxInfo1
        {
            get
            {
                return _infoBox1;
            }
            set
            {
                _infoBox1 = value;
                NotifyOfPropertyChange(() => TextBoxInfo1);
            }
        }

        /// <summary>Value Bound to the Race names Combobox</summary>
        public string[] RaceNames
        {
            get
            {
                return _raceNames;
            }
        }

        /// <summary>Value Bound to the Race names Combobox's selected Item</summary>
        public int SelectedRace
        {
            get
            {
                //Check to see if a race has been commited.
                if (_raceID > -1)
                {
                    _selectedRace = _raceID;
                }
                return _selectedRace;
            }
            set
            {
                _selectedRace = value;
                //update fields.
                manageRaceSelectionFields(_selectedRace);
                NotifyOfPropertyChange(() => SelectedRace);
                
            }
        }

        //used to refresh stats when there is a global change
        private void _updateStatus()
        {
            Str = _Global_Player.AbilityScores[4] ;
            Dex = _Global_Player.AbilityScores[2] ;
            Con = _Global_Player.AbilityScores[1] ;
            Int = _Global_Player.AbilityScores[3] ;
            Wis = _Global_Player.AbilityScores[5] ;
            Cha = _Global_Player.AbilityScores[0] ;
        }

        /// <summary>
        /// This method handels updating required fileds when a race is slected.
        /// </summary>
        /// <param name="raceIndex"></param>
        private void manageRaceSelectionFields(int raceIndex)
        {
            //create an array of combobox selections
            int[] skillBoxSelectedIndex = new int[3];
            //create an array to enable ComboBoxes
            bool[] isEnabled = new bool[3];
            //create an array to set visability toggles
            bool[] isVisable = new bool[3];

            //check of RacialBonusKills Array has a value
            if (_Global_Player.RacialBonusSkills(raceIndex) != null)
            {
                //assign the value locally
                int[] _racialBonusSkills = _Global_Player.RacialBonusSkills(raceIndex);

                //loop through the arrays.
                for (int i = 0; i < _racialBonusSkills.Length; i++)
                {
                    //check to see if there is no bounus skill
                    if(_racialBonusSkills[i] == -1)
                    {
                        //reset combo box posistion to default
                        skillBoxSelectedIndex[i] = -1;
                        //disable combo box
                        isEnabled[i] = false;
                        //hide Contol set.
                        isVisable[i] = false;
                    }
                    //check to see if skill is a wild card
                    else if (_racialBonusSkills[i] == 99)
                    {
                        //reset combo box posistion to default
                        skillBoxSelectedIndex[i] = -1;
                        //enable the user to select any skill
                        isEnabled[i] = true;
                        //Make sure the control is visable
                        isVisable[i] = true;
                    }
                    //Set Racial Skill Bonus.
                    else
                    {
                        //set combo box posistion to reflect racial bonus skill
                        skillBoxSelectedIndex[i] = _racialBonusSkills[i];
                        //prevent user from changing the skill
                        isEnabled[i] = false;
                        //Make sure the control is visable
                        isVisable[i] = true;
                    }//end inner if
                }//end for

                //properties cannot be passed by value so update the manually.
                Skill1IsEnabled = isEnabled[0];
                Skill2IsEnabled = isEnabled[1];
                Skill3IsEnabled = isEnabled[2];
                BonusComboBox1Selection = skillBoxSelectedIndex[0];
                BonusComboBox2Selection = skillBoxSelectedIndex[1];
                BonusComboBox3Selection = skillBoxSelectedIndex[2];
                ControlBonus1IsVisable = isVisable[0];
                ControlBonus2IsVisable = isVisable[1];
                ControlBonus3IsVisable = isVisable[2];

                //update ability Score adjustments
                if(raceIndex != -1)
                {
                    StrAdjust = _Global_Player.RaceMods[raceIndex][4];
                    DexAdjust = _Global_Player.RaceMods[raceIndex][2];
                    ConAdjust = _Global_Player.RaceMods[raceIndex][1];
                    IntAdjust = _Global_Player.RaceMods[raceIndex][3];
                    WisAdjust = _Global_Player.RaceMods[raceIndex][5];
                    ChaAdjust = _Global_Player.RaceMods[raceIndex][0];
                }

            }//end if

        }//end manageRaceSelection

        /// <summary>
        /// Handels Global Data Commited events.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            //Refresh Stat blocks
            _updateStatus();
        }

    }
}
