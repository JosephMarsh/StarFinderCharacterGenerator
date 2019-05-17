using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFLib;
using DieRoller.EventModels;

namespace DieRoller.ViewModels
{
    public class DieRollViewModel : Screen, IHandle<DataCommitedEvent>
    {
        //Libray data
        private static Information info = new Information();
        private static Calculators _calculator = new Calculators();
        private DiceRollMethods _dice = new DiceRollMethods();

        //Model data local scope
        private static Character _Player_Local = ShellViewModel.Global_Player;

        private int _TextBoxModPointBuy1, _TextBoxModPointBuy2, _TextBoxModPointBuy3, _TextBoxModPointBuy4, _TextBoxModPointBuy5, _TextBoxModPointBuy6;
        private int _pointBuyPoints;
        private string _infoBox1 = info.rollModepointBuy;
        private int[] _diePool = new int[24];
        private bool _isEnabledNumericUpDown = true;
        private bool _rollButtonIsEnabled;

        //Private Combobox selection Variables
        private int _comboBoxAssign1_SelectedItem = 4;
        private int _comboBoxAssign2_SelectedItem = 2;
        private int _comboBoxAssign3_SelectedItem = 1;
        private int _comboBoxAssign4_SelectedItem = 3;
        private int _comboBoxAssign5_SelectedItem = 5;
        private int _comboBoxAssign6_SelectedItem = 0;

        //private Final Ability Score variables
        private int _finalAbilityScoreStr = _Player_Local.BaseAbilityScores[4];
        private int _finalAbilityScoreDex = _Player_Local.BaseAbilityScores[2];
        private int _finalAbilityScoreCon = _Player_Local.BaseAbilityScores[1];
        private int _finalAbilityScoreInt = _Player_Local.BaseAbilityScores[3];
        private int _finalAbilityScoreWis = _Player_Local.BaseAbilityScores[5];
        private int _finalAbilityScoreCha = _Player_Local.BaseAbilityScores[0];

        //private variables for storeing Ability Scores
        private int _abilityScore1 = 10;
        private int _abilityScore2 = 10;
        private int _abilityScore3 = 10;
        private int _abilityScore4 = 10;
        private int _abilityScore5 = 10;
        private int _abilityScore6 = 10;

        //Private variables for holding final Ability Score Bonus Mods
        private int _textBoxFinalModStr = _Player_Local.BaseAbilityMods[4];
        private int _textBoxFinalModDex = _Player_Local.BaseAbilityMods[2];
        private int _textBoxFinalModCon = _Player_Local.BaseAbilityMods[1];
        private int _textBoxFinalModInt = _Player_Local.BaseAbilityMods[3];
        private int _textBoxFinalModWis = _Player_Local.BaseAbilityMods[5];
        private int _textBoxFinalModCha = _Player_Local.BaseAbilityMods[0];

        //private variables for handeling Mode Selection specific Rules
        private bool _radioButtonCore;
        private bool _radioButtonPointBuy = true; //sets default Mode
        private bool _radioButtonStandard;

        private IEventAggregator _events;

        public DieRollViewModel(IEventAggregator events)
        {
            _events = events;
        }


        /// <summary>Bound to the Standard Mode Radio Button</summary>
        public bool RaioButtonStandard
        {
            get { return _radioButtonStandard; }
            set
            {
                _radioButtonStandard = value;
                //disable Numeric Up Down pads
                IntupDownSwitch();
                NotifyOfPropertyChange(() => RaioButtonStandard);
                //reset all
                Clear();
            }
        }

        /// <summary>Bound to the Point-Buy Mode Radio Button</summary>
        public bool RadioButtonPointBuy
        {
            get { return _radioButtonPointBuy; }
            set
            {
                _radioButtonPointBuy = value;
                //enable Numeric Up Down pads 
                IntupDownSwitch();
                NotifyOfPropertyChange(() => RadioButtonPointBuy);
                //reset all
                Clear();
            }
        }

        /// <summary>Bound to the Core Mode Radio Button</summary>
        public bool RaioButtonCore
        {
            get { return _radioButtonCore; }
            set
            {
                _radioButtonCore = value;
                //disable Numeric Up Down pads
                IntupDownSwitch();
                NotifyOfPropertyChange(() => RaioButtonCore);
                //reset all
                Clear();
            }
        }
        
        /// <summary>Bound to the "God Mode" checkbox w/Caliburn</summary>
        public bool IsGodMode { get; set; }

        public bool RollButtonISEnabled
        {
            get
            {
                return _rollButtonIsEnabled;
            }
            set
            {
                _rollButtonIsEnabled = value;
                NotifyOfPropertyChange(() => RollButtonISEnabled);
            }
        }

        /// <summary>Bound to Numeric UPDown isEnabled property</summary>
        public bool IsEnabledNumericUpDown
        {
            get { return _isEnabledNumericUpDown; }
            set
            {
                _isEnabledNumericUpDown = value;
                NotifyOfPropertyChange(() => IsEnabledNumericUpDown);
            }
        }

        /// <summary>Holds Final Str Bonus mod and Updates Model</summary>
        public int TextBoxFinalModStr
        {
            get { return _textBoxFinalModStr; }
            set
            {
                _textBoxFinalModStr = value;
                _Player_Local.BaseAbilityMods[4] = value;
            }
        }

        /// <summary>Holds Final Dex Bonus mod and Updates Model</summary>
        public int TextBoxFinalModDex
        {
            get { return _textBoxFinalModDex; }
            set
            {
                _textBoxFinalModDex = value;
                _Player_Local.BaseAbilityMods[2] = value;
            }
        }

        /// <summary>Holds Final Con Bonus mod and Updates Model</summary>
        public int TextBoxFinalModCon
        {
            get { return _textBoxFinalModCon; }
            set
            {
                _textBoxFinalModCon = value;
                _Player_Local.BaseAbilityMods[1] = value;
            }
        }

        /// <summary>Holds Final Int Bonus mod and Updates Model</summary>
        public int TextBoxFinalModInt
        {
            get { return _textBoxFinalModInt; }
            set
            {
                _textBoxFinalModInt = value;
                _Player_Local.BaseAbilityMods[3] = value;
            }
        }

        /// <summary>Holds Final Wis Bonus mod and Updates Model</summary>
        public int TextBoxFinalModWis
        {
            get { return _textBoxFinalModWis; }
            set
            {
                _textBoxFinalModWis = value;
                _Player_Local.BaseAbilityMods[5] = value;
            }
        }

        /// <summary>Holds Final Cha Bonus mod and Updates Model</summary>
        public int TextBoxFinalModCha
        {
            get { return _textBoxFinalModCha; }
            set
            {
                _textBoxFinalModCha = value;
                _Player_Local.BaseAbilityMods[0] = value;
            }
        }

        /// <summary>Holds Cha Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreCha
        {
            get
            {
                return _finalAbilityScoreCha;
            }
            set
            {
                _finalAbilityScoreCha = value;
                //update Model
                _Player_Local.BaseAbilityScores[0] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModCha = _calculator.modCalc(_finalAbilityScoreCha);

                NotifyOfPropertyChange(() => FinalAbilityScoreCha);
                NotifyOfPropertyChange(() => TextBoxFinalModCha);
            }
        }

        /// <summary>Holds Wis Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreWis
        {
            get
            {
                return _finalAbilityScoreWis;
            }
            set
            {
                _finalAbilityScoreWis = value;
                //update Model
                _Player_Local.BaseAbilityScores[5] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModWis = _calculator.modCalc(_finalAbilityScoreWis);

                NotifyOfPropertyChange(() => FinalAbilityScoreWis);
                NotifyOfPropertyChange(() => TextBoxFinalModWis);
            }
        }

        /// <summary>Holds Int Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreInt
        {
            get
            {
                return _finalAbilityScoreInt;
            }
            set
            {
                _finalAbilityScoreInt = value;
                //update Model
                _Player_Local.BaseAbilityScores[3] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModInt = _calculator.modCalc(_finalAbilityScoreInt);

                NotifyOfPropertyChange(() => FinalAbilityScoreInt);
                NotifyOfPropertyChange(() => TextBoxFinalModInt);
            }
        }

        /// <summary>Holds Con Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreCon
        {
            get
            {
                return _finalAbilityScoreCon;
            }
            set
            {
                _finalAbilityScoreCon = value;
                //update Model
                _Player_Local.BaseAbilityScores[1] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModCon = _calculator.modCalc(_finalAbilityScoreCon);

                NotifyOfPropertyChange(() => FinalAbilityScoreCon);
                NotifyOfPropertyChange(() => TextBoxFinalModCon);
            }
        }

        /// <summary>Holds Dex Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreDex
        {
            get
            {
                return _finalAbilityScoreDex;
            }
            set
            {
                _finalAbilityScoreDex = value;
                //update Model
                _Player_Local.BaseAbilityScores[2] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModDex = _calculator.modCalc(_finalAbilityScoreDex);

                NotifyOfPropertyChange(() => FinalAbilityScoreDex);
                NotifyOfPropertyChange(() => TextBoxFinalModDex);
            }
        }

        /// <summary>Holds Str Score points after adustments and Updates Model</summary>
        public int FinalAbilityScoreStr
        {
            get
            {
                return _finalAbilityScoreStr;
            }
            set
            {
                _finalAbilityScoreStr = value;
                //update Model
                _Player_Local.BaseAbilityScores[4] = value;
                //update Final Ability Score Bonus mod
                TextBoxFinalModStr = _calculator.modCalc(_finalAbilityScoreStr);

                NotifyOfPropertyChange(() => FinalAbilityScoreStr);
                NotifyOfPropertyChange(() => TextBoxFinalModStr);
            }
        }

        /// <summary>Holds string data for InfoBox1</summary>
        public string InfoBox1
        {
            get { return _infoBox1; }
            set
            {
                _infoBox1 = value;
                NotifyOfPropertyChange(() => InfoBox1);
            }
        }

        /// <summary>Holds Point Cost totals for Ability Scores</summary>
        public int PointBuyPoints
        {
            get
            {
                return _pointBuyPoints;
            }
            set
            {
                NotifyOfPropertyChange(() => PointBuyPoints);
            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore1
        {
            get
            {
                return _abilityScore1;
            }
            set
            {
                //validate input
                _abilityScore1 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy1 = _calculator.modCalc(_abilityScore1);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign1_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy1);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore1);
            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore2
        {
            get
            {
                return _abilityScore2;
            }
            set
            {
                //validate input
                _abilityScore2 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy2 = _calculator.modCalc(_abilityScore2);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign2_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy2);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore2);
            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore3
        {
            get
            {
                return _abilityScore3;
            }
            set
            {
                //validate input
                _abilityScore3 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy3 = _calculator.modCalc(_abilityScore3);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign3_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy3);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore3);

            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore4
        {
            get
            {
                return _abilityScore4;
            }
            set
            {
                //validate input
                _abilityScore4 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy4 = _calculator.modCalc(_abilityScore4);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign4_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy4);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore4);
            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore5
        {
            get
            {
                return _abilityScore5;
            }
            set
            {
                //Validate Input
                _abilityScore5 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy5 = _calculator.modCalc(_abilityScore5);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign5_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy5);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore5);
            }
        }

        /// <summary>Holds Ability Score points Raw and updates TextBoxModPointBuy variables</summary>
        public int AbilityScore6
        {
            get
            {
                return _abilityScore6;
            }
            set
            {
                //Validate input
                _abilityScore6 = pointBuyInputValidation(value, IsGodMode);
                //update ability score bonus modifier
                TextBoxModPointBuy6 = _calculator.modCalc(_abilityScore6);
                //Calculate the cost of all ability score points and add them up
                updatePointBuyCosts();
                //notify properties if they change
                NotifyOfPropertyChange(() => ComboBoxAssign6_SelectedItem);
                NotifyOfPropertyChange(() => TextBoxModPointBuy6);
                NotifyOfPropertyChange(() => PointBuyPoints);
                NotifyOfPropertyChange(() => AbilityScore6);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy6
        {
            get { return _TextBoxModPointBuy6; }
            set
            {
                _TextBoxModPointBuy6 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy6);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy5
        {
            get { return _TextBoxModPointBuy5; }
            set
            {
                _TextBoxModPointBuy5 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy5);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy4
        {
            get { return _TextBoxModPointBuy4; }
            set
            {
                _TextBoxModPointBuy4 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy4);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy3
        {
            get { return _TextBoxModPointBuy3; }
            set
            {
                _TextBoxModPointBuy3 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy3);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy2
        {
            get { return _TextBoxModPointBuy2; }
            set
            {
                _TextBoxModPointBuy2 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy2);
            }
        }

        /// <summary>Holds Ability Score Bonus Modifires</summary>
        public int TextBoxModPointBuy1
        {
            get { return _TextBoxModPointBuy1; }
            set
            {
                _TextBoxModPointBuy1 = value;
                NotifyOfPropertyChange(() => TextBoxModPointBuy1);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign6_SelectedItem
        {
            get { return _comboBoxAssign6_SelectedItem; }
            set
            {
                _comboBoxAssign6_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign6_SelectedItem);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign5_SelectedItem
        {
            get { return _comboBoxAssign5_SelectedItem; }
            set
            {
                _comboBoxAssign5_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign5_SelectedItem);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign4_SelectedItem
        {
            get { return _comboBoxAssign4_SelectedItem; }
            set
            {
                _comboBoxAssign4_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign4_SelectedItem);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign3_SelectedItem
        {
            get { return _comboBoxAssign3_SelectedItem; }
            set
            {
                _comboBoxAssign3_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign3_SelectedItem);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign2_SelectedItem
        {
            get { return _comboBoxAssign2_SelectedItem; }
            set
            {
                _comboBoxAssign2_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign2_SelectedItem);
            }
        }

        /// <summary>Holds posistion data for selected item of combobox</summary>
        public int ComboBoxAssign1_SelectedItem
        {
            get { return _comboBoxAssign1_SelectedItem; }
            set
            {
                _comboBoxAssign1_SelectedItem = value;
                NotifyOfPropertyChange(() => ComboBoxAssign1_SelectedItem);
            }
        }

        /// <summary>String Containing the Primary Charactor Name</summary>
        public string Name
        {
            get
            {
                return _Player_Local.CharacterName;
            }
            set
            {
                _Player_Local.CharacterName = value;
            }
        }

        /// <summary>Read only String Array of atribute names full</summary>
        public string[] StatNames
        {
            get
            {
                return _Player_Local.AbilityNames;
            }
        }

        /// <summary>Int Aray containing primary charactor attributes [0-5]</summary>
        public int[] CharacterAbilitiesRaw
        {
            get
            {
                return _Player_Local.BaseAbilityScores;

            }
            set
            {
                _Player_Local.BaseAbilityScores = value;
                //notify event that property has changed.
                NotifyOfPropertyChange(() => CharacterAbilitiesRaw);
            }
        }

        //Method that Updates point-buy costs whenever an attribute is altered
        private void updatePointBuyCosts()
        {
            _pointBuyPoints = _calculator.Point_BuyCostCalc(AbilityScore1) + _calculator.Point_BuyCostCalc(AbilityScore2) +
                    _calculator.Point_BuyCostCalc(AbilityScore3) + _calculator.Point_BuyCostCalc(AbilityScore4) +
                    _calculator.Point_BuyCostCalc(AbilityScore5) + _calculator.Point_BuyCostCalc(AbilityScore6);
        }

        /// <summary>This Method is tied to FinalCommit button w/Caliburn Micro </summary>
        public void FinalCommit()
        {
            //array of selected item numbers fron ablity score name comboboxes 
            int[] abilityNameBoxes = {ComboBoxAssign1_SelectedItem, ComboBoxAssign2_SelectedItem,
                ComboBoxAssign3_SelectedItem, ComboBoxAssign4_SelectedItem, ComboBoxAssign5_SelectedItem,
            ComboBoxAssign6_SelectedItem};
            //array that represents the model object's final stats after adjustments
            int[] finalAbilityScores = { FinalAbilityScoreCha, FinalAbilityScoreCon, FinalAbilityScoreDex,
                FinalAbilityScoreInt, FinalAbilityScoreStr, FinalAbilityScoreWis};
            //array that reprents stats that are able to be ajusted by user interface.
            int[] adjustableAbilityscores = {AbilityScore1, AbilityScore2, AbilityScore3, AbilityScore4,
                AbilityScore5, AbilityScore6 };
            for (int i = 0; i < finalAbilityScores.Length; i++)
            {
                //Finds the index of ability score name and assigns the value of adjustable 
                //ablilty scores number to the correct base ability score array.  
                finalAbilityScores[i] = adjustableAbilityscores[Array.IndexOf(abilityNameBoxes, i)];
            }
            FinalAbilityScoreCha = finalAbilityScores[0];
            FinalAbilityScoreCon = finalAbilityScores[1];
            FinalAbilityScoreDex = finalAbilityScores[2];
            FinalAbilityScoreInt = finalAbilityScores[3];
            FinalAbilityScoreStr = finalAbilityScores[4];
            FinalAbilityScoreWis = finalAbilityScores[5];

            _events.PublishOnUIThread(new DataCommitedEvent());

        }//end FinalCommit

        /// <summary>This Method is tied to Clear button w/Caliburn Micro </summary>
        public void Clear()
        {
            //Set Final Scores to local settings
            FinalAbilityScoreStr = _Player_Local.BaseAbilityScores[4];
            FinalAbilityScoreDex = _Player_Local.BaseAbilityScores[2];
            FinalAbilityScoreCon = _Player_Local.BaseAbilityScores[1];
            FinalAbilityScoreInt = _Player_Local.BaseAbilityScores[3];
            FinalAbilityScoreWis = _Player_Local.BaseAbilityScores[5];
            FinalAbilityScoreCha = _Player_Local.BaseAbilityScores[0];

            //Set IntUpDown Scores to 10
            AbilityScore1 = 10;
            AbilityScore2 = 10;
            AbilityScore3 = 10;
            AbilityScore4 = 10;
            AbilityScore5 = 10;
            AbilityScore6 = 10;

            //Reset Comboboxes
            ComboBoxAssign1_SelectedItem = 4;
            ComboBoxAssign2_SelectedItem = 2;
            ComboBoxAssign3_SelectedItem = 1;
            ComboBoxAssign4_SelectedItem = 3;
            ComboBoxAssign5_SelectedItem = 5;
            ComboBoxAssign6_SelectedItem = 0;
        }
        //toggles every bit in an array of bool
        private void toggleBoolArray(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = !array[i];
            }
        }

        public void Roll()
        {
            int die = 0;
            if (RaioButtonStandard)
            {
                //populate the standard DiePool
                _dice.StandardDieRoll(_diePool);
                //each ability is populated by three die pool indexes 
                //these are tracked by "die" wich is passed by refrence to the method
                AbilityScore1 = addDiceToAbilityScore(ref die, _diePool);
                AbilityScore2 = addDiceToAbilityScore(ref die, _diePool);
                AbilityScore3 = addDiceToAbilityScore(ref die, _diePool);
                AbilityScore4 = addDiceToAbilityScore(ref die, _diePool);
                AbilityScore5 = addDiceToAbilityScore(ref die, _diePool);
                AbilityScore6 = addDiceToAbilityScore(ref die, _diePool);
            }
        }

        private void IntupDownSwitch()
        {
            if (_radioButtonCore)
            {
                IsEnabledNumericUpDown = false;
                RollButtonISEnabled = false;
            }
            if (_radioButtonPointBuy)
            {
                RollButtonISEnabled = false;
                IsEnabledNumericUpDown = true;
            }
            if (_radioButtonStandard)
            {
                RollButtonISEnabled = true;
                IsEnabledNumericUpDown = false;
            }
        }

        //Validates that Point-Buy Input valls between 7 and 18 unless godmode
        private int pointBuyInputValidation(int value, bool isGodMode = false)
        {
            if (isGodMode)
            {
                return value;
            }
            else
            {
                if (value > 18)
                {
                    value = 18;
                }
                else if (value < 7)
                {
                    value = 7;
                }
            }
            return value;
        }

        //accepts and indext int an array of ints and can roduce 24 if the boolean is activated 
        private int addDiceToAbilityScore(ref int index, int[] array, bool isFourDice = false)
        {
            int score = 0;
            if (isFourDice)
            {
                //add latter
            }
            for (int i = 0; i < 3; i++)
            {
                score += array[index];
                index++;
            }
            return score;
        }

        /// <summary>
        /// Handels Global Data Commited events from Child View Models.
        /// </summary>
        /// <param name="message">Empty Event Object</param>
        public void Handle(DataCommitedEvent message)
        {

        }
    }
}
