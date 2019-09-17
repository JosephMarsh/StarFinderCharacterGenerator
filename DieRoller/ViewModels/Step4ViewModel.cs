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
    public class Step4ViewModel : Screen, IHandle<DataCommitedEvent>
    {
        //singleton model opbject
        private static Character _Global_Player = ShellViewModel.Global_Player;
        //info class
        private static Information _info = new Information();
        //instaciate event aggregation
        private IEventAggregator _events;

        //character Classes Data
        private static PlayerClass _PlayerClass = new PlayerClass();
        private static EnvoyClass _Envoy = new EnvoyClass();
        private static MechClass _Mech = new MechClass();
        private static MysticClass _Mystic = new MysticClass();
        private static OperativeClass _Operative = new OperativeClass();
        private static SolarianClass _Solarian = new SolarianClass();
        private static SoldierClass _Soldier = new SoldierClass();
        private static TechnomancerClass _Technomancer = new TechnomancerClass();


        private string[] _primaryAbilityScores = _PlayerClass.KeyAbilityScores;
        private string[] _classNames = _PlayerClass.classNames;
        private string _primaryAbilityScoreDisplay = "";
        private int _selectedClass = _Global_Player.ClassID1;
        private int _selectedClass2 = _Global_Player.ClassID2;
        private int _firstClassLevel = _Global_Player.Class1Level;
        private int _secondClassLevel = _Global_Player.Class2Level;

        private bool _isMulticlass = _Global_Player.IsMultiClass;

        /// <summary> Read only Bound to PrimaryAbilityScoreDisplay with caliburn micro </summary>
        public string PrimaryAbilityScoreDisplay
        {
            get
            {
                return _primaryAbilityScoreDisplay;
            }
            set
            {
                _primaryAbilityScoreDisplay = value;
                NotifyOfPropertyChange(() => PrimaryAbilityScoreDisplay);
            }
        }

        /// <summary>Stores the number of leveles in the secondary class</summary>
        public int Class2Level
        {
            get
            {
                return _secondClassLevel;
            }
            set
            {
                _secondClassLevel = value;
                multiclassLevelValidation();
                NotifyOfPropertyChange(() => Class2Level);
            }
        }

        /// <summary>Stores the number of leveles in the primary class</summary>
        public int Class1Level
        {
            get
            {
                return _firstClassLevel;
            }
            set
            {
                _firstClassLevel = value;
                multiclassLevelValidation();
                NotifyOfPropertyChange(() => Class1Level);
            }
        }

        /// <summary> bound to index of primary class drop down</summary>
        public int SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                if (SelectedClass2 == value && value != -1)
                {
                    SelectedClass2 = -1;
                }

                generatePrimaryAbilityScores();
                NotifyOfPropertyChange(() => SelectedClass);
            }
        }

        /// <summary> bound to index of primary class drop down</summary>
        public int SelectedClass2
        {
            get
            {
                return _selectedClass2;
            }
            set
            {
                _selectedClass2 = value;
                if (SelectedClass == value)
                {
                    SelectedClass = -1;
                }
                generatePrimaryAbilityScores();
                NotifyOfPropertyChange(() => SelectedClass2);
            }
        }

        /// <summary>Bound to the value of the mutliclass checkbox</summary>
        public bool IsMulticlass
        {
            get
            {
                return _isMulticlass;
            }
            set
            {
                //blank secondary class out
                if (value == false )
                {
                    SelectedClass2 = -1;
                }
                _isMulticlass = value;
                multiclassLevelValidation();
                generatePrimaryAbilityScores();
                NotifyOfPropertyChange(() => IsMulticlass);
            }
        }

        /// <summary> Read only array of character class names</summary>
        public string[] ClassNames
        {
            get
            {
                return _classNames;
            }
        }

        public Step4ViewModel(IEventAggregator events)
        {
            _events = events;
            //Allows class to listen for gobal events.
            _events.Subscribe(this);
        }

        // This method is designed to maintain a 20 level cap on multiclassing
        private void multiclassLevelValidation()
        {
            //conditions for only Multiclass
            if (IsMulticlass)
            {
                //second Class can't be less than one
                if (Class2Level < 1)
                {
                    Class2Level = 1;
                }

                //first class can't be more than 19
                if (Class1Level > 19)
                {
                    Class1Level = 19;
                }

                //don't let the user add more than 20 levels total
                if (Class1Level + Class2Level > 20)
                {
                     
                    Class2Level = 20 - Class1Level;
                }
            }
            //condtions for single class
            else
            {
                //set class to to 0
                if (Class2Level != 0)
                {
                    Class2Level = 0;
                }
                //Cap class 1 at 20
                if(Class1Level > 20)
                {
                    Class1Level = 20;
                }
            }//end if

            //First class can never be less than one under any condtions
            if (Class1Level < 1)
            {
                Class1Level = 1;
            }
        }//end multiclassBallancer

        /// <summary>
        /// bound to Clear button with Caliburn Micro
        /// </summary>
        public void Reset()
        {
            Class1Level = _Global_Player.Class1Level;
            Class2Level = _Global_Player.Class2Level;

            IsMulticlass = _Global_Player.IsMultiClass;

            SelectedClass = _Global_Player.ClassID1;
            SelectedClass2 = _Global_Player.ClassID2;
        }

        public void Commit()
        {
            _Global_Player.ClassID1 = SelectedClass;
            _Global_Player.Class1Level = Class1Level;

            _Global_Player.IsMultiClass = IsMulticlass;

            _Global_Player.ClassID2 = SelectedClass2;
            _Global_Player.Class2Level = Class2Level;
        }

        private void generatePrimaryAbilityScores()
        {
            if (SelectedClass == -1)
            {
                PrimaryAbilityScoreDisplay = "";
            }
            else
            {
                PrimaryAbilityScoreDisplay = _primaryAbilityScores[SelectedClass];
            }

            if (IsMulticlass && SelectedClass2 != -1)
            {
                PrimaryAbilityScoreDisplay += " and " + _primaryAbilityScores[SelectedClass2];
            }
        }

        /// <summary>Handels Global Data Commited events.</summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            //Reset choices
            Reset();
        }
    }
}
