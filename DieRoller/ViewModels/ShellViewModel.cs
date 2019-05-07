using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFLib;
using DieRoller.Views;


namespace DieRoller.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        
        private static PlayerCharacter _Global_Player;
        private static PlayerCharacter _Player_Instance = new PlayerCharacter();

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


        //initialize value.
        private string _characterName = _Player_Instance.CharacterName;

        //Refesh data 
        

        public string ChraracterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                _characterName = value;
                NotifyOfPropertyChange(() => ChraracterName);
            }
        }



        //Page button controll Methods
        public void DieRollPage()
        {
            updateStatus();
            ActivateItem(new DieRollViewModel());
            
        }
        public void Step1Page()
        {
            updateStatus();
            ActivateItem(new Step1ViewModel());
            
        }

        private void updateStatus()
        {
            ChraracterName = Global_Player.CharacterName;
            NotifyOfPropertyChange(() => ChraracterName);
        }
    }//end class
}//end namespace
