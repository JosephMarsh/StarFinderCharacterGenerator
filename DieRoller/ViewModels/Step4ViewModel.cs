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

        /// <summary>
        /// an array of character classes.
        /// </summary>
        public PlayerClass[] classes = { _Envoy,_Mech,_Mystic,_Operative, _Solarian, _Soldier, _Technomancer };

        private string[] _classNames = _PlayerClass.classNames;
        private int _selectedClass = _Global_Player.ClassID1;
        private int _firstClassLevel = _Global_Player.Class1Level;
        private int _secondClassLevel = _Global_Player.Class2Level;

        /// <summary>Stores the number of leveles in the secondary class</summary>
        public int SecondClassLevel
        {
            get
            {
                return _secondClassLevel;
            }
            set
            {
                _secondClassLevel = value;
                multiclassBallancer();
                NotifyOfPropertyChange(() => SecondClassLevel);
            }
        }

        /// <summary>Stores the number of leveles in the primary class</summary>
        public int FirstClassLevel
        {
            get
            {
                return _firstClassLevel;
            }
            set
            {
                _firstClassLevel = value;
                multiclassBallancer();
                NotifyOfPropertyChange(() => FirstClassLevel);
            }
        }

        private bool _isMulticlass = false;

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
                NotifyOfPropertyChange(() => SelectedClass);
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
                _isMulticlass = value;
                multiclassBallancer();
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

        private void multiclassBallancer()
        {
            //conditions for only Multiclass
            if (IsMulticlass)
            {
                //second Class can't be less than one
                if (SecondClassLevel < 1)
                {
                    SecondClassLevel = 1;
                }

                //firt class can't be more than 19
                if (FirstClassLevel > 19)
                {
                    FirstClassLevel = 19;
                }

                //don't let the user add more than 20 levles total
                if (FirstClassLevel + SecondClassLevel > 20)
                {
                     
                    SecondClassLevel = 20 - FirstClassLevel;
                }
            }
            //condtions for only not mutliclass
            else
            {
                if (SecondClassLevel != 0)
                {
                    SecondClassLevel = 0;
                }

                if(FirstClassLevel > 20)
                {
                    FirstClassLevel = 20;
                }
            }

            //First class can never be less than one under any condtions
            if (FirstClassLevel < 1)
            {
                FirstClassLevel = 1;
            }

            
        }

        /// <summary>
        /// bound to Clear button with Caliburn Micro
        /// </summary>
        public void Reset()
        {

        }

        /// <summary>
        /// Handels Global Data Commited events.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {
            //Reset choices
            Reset();
        }
    }
}
