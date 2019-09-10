using Caliburn.Micro;
using DieRoller.EventModels;
using SFLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DieRoller.ViewModels
{
    public class Step2ViewModel : Screen, IHandle<DataCommitedEvent>
    {
        private static Character _Global_Player = ShellViewModel.Global_Player;
        private static Information _info = new Information();

        //ability scores after adjustments
        private int _str = _Global_Player.AbilityScoresWithTheme[4];
        private int _dex = _Global_Player.AbilityScoresWithTheme[2];
        private int _con = _Global_Player.AbilityScoresWithTheme[1];
        private int _int = _Global_Player.AbilityScoresWithTheme[3];
        private int _wis = _Global_Player.AbilityScoresWithTheme[5];
        private int _cha = _Global_Player.AbilityScoresWithTheme[0];

        //ability score adjustments
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
        private int[] _racialClassSkills = _Global_Player.RacialClassSkillIndexes;
        private string[] _raceNames = _Global_Player.RaceNames;
        private int _selectedRace = -1;
        private string _raceName = _Global_Player.RaceName;
        private bool _isGodMode = _Global_Player.RaceUsesGodMode;

        //info box stuff
        private string[] _raceInfo = _info.RaceDiscriptions;
        private string _infoBox1 = _info.step2;

        //populate comboboxes
        private string[] _bonusComboBox1 = _Global_Player.skillNames;
        private string[] _bonusComboBox2 = _Global_Player.skillNames;
        private string[] _bonusComboBox3 = _Global_Player.skillNames;
        private string[] _abilityComboBox1 = _Global_Player.AbilityNames;

        //store combobox selections
        private int _bonusComboBox1Selection = _Global_Player.RacialClassSkillIndexes[0];
        private int _bonusComboBox2Selection = _Global_Player.RacialClassSkillIndexes[1];
        private int _bonusComboBox3Selection = _Global_Player.RacialClassSkillIndexes[2];
        private int _abilityComboBox1Selection = _Global_Player.OtherRaceChosenAbilityscore;

        //store cotrol visability
        private bool _controlBonus1IsVisable = false;
        private bool _controlBonus2IsVisable = false;
        private bool _controlBonus3IsVisable = false;
        private bool _controlAbility1IsVisable = false;
        private bool _godModeIsVisable = false;

        //strore cotrolability
        private bool _skill1IsEnabled = true;
        private bool _skill2IsEnabled = true;
        private bool _skill3IsEnabled = true;
        private bool _raceNameIsEnabled = false;
        private bool _canCommit = false;

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
                if (IsGodMode)
                {
                    Str = _Global_Player.AbilityScoresWithTheme[4] + StrAdjust;
                }
                
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
                
                if (IsGodMode)
                {
                    Dex = _Global_Player.AbilityScoresWithTheme[2] + DexAdjust;
                }
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
                if (IsGodMode)
                {
                    Con = _Global_Player.AbilityScoresWithTheme[1] + ConAdjust;
                }
                
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
                if (IsGodMode)
                {
                    Int = _Global_Player.AbilityScoresWithTheme[3] + IntAdjust;
                }
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
                if (IsGodMode)
                {
                    Wis = _Global_Player.AbilityScoresWithTheme[5] + _wisAdjust;
                }
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
                if (IsGodMode)
                {
                    Cha = _Global_Player.AbilityScoresWithTheme[0] + _chaAdjust;
                }
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

        /// <summary>value bound to Ability Border with Caliburn Micro</summary>
        public bool ControlAbility1IsVisable
        {
            get
            {
                return _controlAbility1IsVisable;
            }
            set
            {
                _controlAbility1IsVisable = value;
                NotifyOfPropertyChange(() => ControlAbility1IsVisable);
            }
        }

        public bool GodModeIsVisable
        {
            get
            {
                return _godModeIsVisable;
            }
            set
            {
                _godModeIsVisable = value;
                NotifyOfPropertyChange(() => GodModeIsVisable);
            }
        }

        public bool IsGodMode
        {
            get
            {
                return _isGodMode;
            }
            set
            {
                _isGodMode = value;
                if (_isGodMode)
                {
                    AbilityComboBox1Selection = -1;
                    ControlAbility1IsVisable = false;
                }

                if(!_isGodMode && _selectedRace == 8)
                {
                    AbilityComboBox1Selection = _Global_Player.OtherRaceChosenAbilityscore;
                    ControlAbility1IsVisable = true;
                }
                CanCommit();
                NotifyOfPropertyChange(() => IsGodMode);
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

        /// <summary>value bound to Skill Combobox Item Source</summary>
        public string[] AbilityComboBox1
        {
            get
            {
                return _abilityComboBox1;
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
                //check if other skills are the same
                if (BonusComboBox1Selection != -1 && BonusComboBox1Selection == value)
                {
                    //reset combobox
                    BonusComboBox1Selection = -1;
                }
                if (BonusComboBox2Selection != -1 && BonusComboBox2Selection == value)
                {
                    //reset combobox
                    BonusComboBox2Selection = -1;
                }
                _bonusComboBox3Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox3Selection);
                CanCommit();
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
                //check if other skills are the same
                if (BonusComboBox1Selection != -1 && BonusComboBox1Selection == value )
                {
                    //reset combobox
                    BonusComboBox1Selection = -1;
                }
                if (BonusComboBox3Selection != -1 && BonusComboBox3Selection == value)
                {
                    //reset combobox
                    BonusComboBox3Selection = -1;
                }
                _bonusComboBox2Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox2Selection);
                CanCommit();
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
                //check if other skills are the same
                if (BonusComboBox2Selection != -1 && BonusComboBox2Selection == value)
                {
                    //reset combobox
                    BonusComboBox2Selection = -1;
                }
                if (BonusComboBox3Selection != -1 && BonusComboBox3Selection == value)
                {
                    //reset combobox
                    BonusComboBox3Selection = -1;
                }
                _bonusComboBox1Selection = value;
                NotifyOfPropertyChange(() => BonusComboBox1Selection);
                CanCommit();
            }
        }

        /// <summary>value bound to Skill Combobox Item Selection</summary>
        public int AbilityComboBox1Selection
        {
            get
            {
                return _abilityComboBox1Selection;
            }
            set
            {
                _abilityComboBox1Selection = value;
                updateAbilityScores(_selectedRace);
                NotifyOfPropertyChange(() => AbilityComboBox1Selection);
                CanCommit();
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

        /// <summary>Value enables and disables the Text Box for race name</summary>
        public bool RaceNameIsEnabled
        {
            get
            {
                return _raceNameIsEnabled;
            }
            set
            {
                _raceNameIsEnabled = value;
                NotifyOfPropertyChange(() => RaceNameIsEnabled);
            }
        }

        /// <summary>Value enables and disables the The Commit Button</summary>
        public bool CanCommitButton
        {
            get
            {
                return _canCommit;
            }
            set
            {
                _canCommit = value;
                NotifyOfPropertyChange(() => CanCommitButton);
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
            set
            {
                _raceNames = value;
                NotifyOfPropertyChange(() => RaceNames);
            }
        }

        public string RaceName
        {
            get
            {
                return _raceName;
            }
            set
            {
                _raceName = value;
                NotifyOfPropertyChange(() => RaceName);
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
                

                //if this is set to custom race check for godmode on Global
                if (value == 8)
                {
                    IsGodMode = _Global_Player.RaceUsesGodMode;
                }
                else
                {
                    IsGodMode = false;
                }

                //update Race Name Text box
                if (value != -1 && value != 8)
                {
                    RaceName = _raceNames[value];
                }

                //update fields.
                manageRaceSelectionFields(_selectedRace);
                CanCommit();
                NotifyOfPropertyChange(() => RaceName);
                NotifyOfPropertyChange(() => SelectedRace);
            }
        }

        /// <summary>
        /// bound to Clear button with Caliburn Micro
        /// </summary>
        public void Reset()
        {
            SelectedRace = _Global_Player.CharacterRaceId;

            manageRaceSelectionFields(SelectedRace);

            IsGodMode = _Global_Player.RaceUsesGodMode;
            RaceName = _Global_Player.RaceName;

            Str = _Global_Player.AbilityScoresWithTheme[4];
            Dex = _Global_Player.AbilityScoresWithTheme[2];
            Con = _Global_Player.AbilityScoresWithTheme[1];
            Int = _Global_Player.AbilityScoresWithTheme[3];
            Wis = _Global_Player.AbilityScoresWithTheme[5];
            Cha = _Global_Player.AbilityScoresWithTheme[0];

            //check to see if the race was not set or was set to custom
            if (SelectedRace == -1 || (SelectedRace == 8 && IsGodMode))
            {
                StrAdjust = _Global_Player.RacialAbilityScoreAdjustment[4];
                DexAdjust = _Global_Player.RacialAbilityScoreAdjustment[2];
                ConAdjust = _Global_Player.RacialAbilityScoreAdjustment[1];
                IntAdjust = _Global_Player.RacialAbilityScoreAdjustment[3];
                WisAdjust = _Global_Player.RacialAbilityScoreAdjustment[5];
                ChaAdjust = _Global_Player.RacialAbilityScoreAdjustment[0];
            }
            //else it was set to something specific
            else
            {
                //grabs the value from 2D array of ability scores based on selected race
                StrAdjust = _Global_Player.RaceMods[SelectedRace][4];
                DexAdjust = _Global_Player.RaceMods[SelectedRace][2];
                ConAdjust = _Global_Player.RaceMods[SelectedRace][1];
                IntAdjust = _Global_Player.RaceMods[SelectedRace][3];
                WisAdjust = _Global_Player.RaceMods[SelectedRace][5];
                ChaAdjust = _Global_Player.RaceMods[SelectedRace][0];
            }//end if

            BonusComboBox1Selection = _Global_Player.RacialClassSkillIndexes[0];
            BonusComboBox2Selection = _Global_Player.RacialClassSkillIndexes[1];
            BonusComboBox3Selection = _Global_Player.RacialClassSkillIndexes[2];
            AbilityComboBox1Selection = _Global_Player.OtherRaceChosenAbilityscore;
        }//end Reset

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

            //reset ability socore comboBox
            AbilityComboBox1Selection = -1;

            //check if player selected "other"
            if(raceIndex == 8)
            {
                RaceNameIsEnabled = true;
                GodModeIsVisable = true;
            }
            else
            {
                GodModeIsVisable = false;
                RaceNameIsEnabled = false;
            }

            //check of RacialBonusKills Array has a value
            if (_Global_Player.GetsRacialClassSkills(raceIndex) != null)
            {
                //assign the value locally
                int[] _racialBonusSkills = _Global_Player.GetsRacialClassSkills(raceIndex);

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

                //show or hide and update Ability Score dropdown
                if(raceIndex == 1)//human
                {
                    ControlAbility1IsVisable = true;
                }
                else if (raceIndex == 8)//other
                {
                    ControlAbility1IsVisable = true;
                }
                else //everything else
                {
                    ControlAbility1IsVisable = false;
                }//end inner if

                //make sure Ability comboBox has been reset to -1
                AbilityComboBox1Selection = -1;

                //properties cannot be passed by value so update them manually.
                Skill1IsEnabled = isEnabled[0];
                Skill2IsEnabled = isEnabled[1];
                Skill3IsEnabled = isEnabled[2];
                BonusComboBox1Selection = skillBoxSelectedIndex[0];
                BonusComboBox2Selection = skillBoxSelectedIndex[1];
                BonusComboBox3Selection = skillBoxSelectedIndex[2];
                ControlBonus1IsVisable = isVisable[0];
                ControlBonus2IsVisable = isVisable[1];
                ControlBonus3IsVisable = isVisable[2];
                //update ability scores displayed
                updateAbilityScores(raceIndex);

                //update Info box
                //check to see if default is selected
                if (raceIndex > -1)
                {
                    //display race info
                    TextBoxInfo1 = _raceInfo[raceIndex];
                }
                else
                {
                    //display default page info
                    TextBoxInfo1 = _info.step2;
                }//end inner if
            }//end if
        }//end manageRaceSelection

        /// <summary>
        /// This method controls if the Commit button is enabled or not
        /// check the status of combo boxes to see if they are enable and if there is an item selected or not
        /// </summary>
        /// <returns>true if contditions are met</returns>
        public bool CanCommit()
        {
            //create an array of active contols
            bool[] activeControls = { ControlBonus1IsVisable, ControlBonus2IsVisable, ControlBonus3IsVisable, ControlAbility1IsVisable , true};
            //create an array of contol values
            int[] controlSelections = { BonusComboBox1Selection, BonusComboBox2Selection, BonusComboBox3Selection, AbilityComboBox1Selection , SelectedRace};
            //create an array to store the results of testresults for each contol
            bool[] passFail = new bool[5];
            for (int i = 0; i < activeControls.Length; i++)
            {
                //check of the control is active
                if (activeControls[i])
                {
                    //fail if it's set to default
                    if(controlSelections[i] == -1)
                    {
                        passFail[i] = false;
                    }
                    else
                    {
                        passFail[i] = true;
                    }
                }
                else
                {
                    //inactive control passes automanticly
                    passFail[i] = true;
                }
            }
            CanCommitButton =  !(passFail.Contains(false));
            return CanCommitButton;
        }

        /// <summary>
        /// This Method is bound to the commit button with Caliburn Micro
        /// when pressed the button updates the global object with the user's chosen values
        /// </summary>
        public void Commit()
        {
            //update the global character object
            _Global_Player.CharacterRaceId = SelectedRace;
            _Global_Player.RaceName = RaceName;
            _Global_Player.RaceUsesGodMode = IsGodMode;
            //store ability score adjustments
            _Global_Player.RacialAbilityScoreAdjustment[4] = StrAdjust;
            _Global_Player.RacialAbilityScoreAdjustment[2] = DexAdjust;
            _Global_Player.RacialAbilityScoreAdjustment[1] = ConAdjust;
            _Global_Player.RacialAbilityScoreAdjustment[3] = IntAdjust;
            _Global_Player.RacialAbilityScoreAdjustment[5] = WisAdjust;
            _Global_Player.RacialAbilityScoreAdjustment[0] = ChaAdjust;
            //store Skill adjustments
            _Global_Player.RacialClassSkillIndexes[0] = BonusComboBox1Selection;
            _Global_Player.RacialClassSkillIndexes[1] = BonusComboBox2Selection;
            _Global_Player.RacialClassSkillIndexes[2] = BonusComboBox3Selection;
            _Global_Player.OtherRaceChosenAbilityscore = AbilityComboBox1Selection;
            //tell anyone listening that the object was updated
            _events.PublishOnUIThread(new DataCommitedEvent());
        }

        private void updateAbilityScores(int raceIndex)
        {
            //update ability Score adjustments
            if (raceIndex != -1 && !IsGodMode)
            {
                StrAdjust = _Global_Player.RaceMods[raceIndex][4];
                DexAdjust = _Global_Player.RaceMods[raceIndex][2];
                ConAdjust = _Global_Player.RaceMods[raceIndex][1];
                IntAdjust = _Global_Player.RaceMods[raceIndex][3];
                WisAdjust = _Global_Player.RaceMods[raceIndex][5];
                ChaAdjust = _Global_Player.RaceMods[raceIndex][0];
            }

            //adjust Displayed ability scores according to chosen race
            Str = _Global_Player.AbilityScoresWithTheme[4] + StrAdjust;
            Dex = _Global_Player.AbilityScoresWithTheme[2] + DexAdjust;
            Con = _Global_Player.AbilityScoresWithTheme[1] + ConAdjust;
            Int = _Global_Player.AbilityScoresWithTheme[3] + IntAdjust;
            Wis = _Global_Player.AbilityScoresWithTheme[5] + WisAdjust;
            Cha = _Global_Player.AbilityScoresWithTheme[0] + ChaAdjust;

            //check if ability score dropdown has a value.
            if(AbilityComboBox1Selection != -1)
            {
                switch (AbilityComboBox1Selection)
                {
                    case 0:
                        ChaAdjust = 2;
                        Cha = _Global_Player.AbilityScoresWithTheme[0] + ChaAdjust;
                        break;
                    case 1:
                        ConAdjust = 2;
                        Con = _Global_Player.AbilityScoresWithTheme[1] + ConAdjust;
                        break;
                    case 2:
                        DexAdjust = 2;
                        Dex = _Global_Player.AbilityScoresWithTheme[2] + DexAdjust;
                        break;
                    case 3:
                        IntAdjust = 2;
                        Int = _Global_Player.AbilityScoresWithTheme[3] + IntAdjust;
                        break;
                    case 4:
                        StrAdjust = 2;
                        Str = _Global_Player.AbilityScoresWithTheme[4] + StrAdjust;
                        break;
                    case 5:
                        WisAdjust = 2;
                        Wis = _Global_Player.AbilityScoresWithTheme[5] + WisAdjust;
                        break;
                    default:
                        break;
                }
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

    }
}
