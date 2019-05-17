using SFLib;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieRoller.ViewModels
{
    public class Step3ViewModel : Screen
    {

        private static Character _Global_Player = ShellViewModel.Global_Player;
        private static Information _info = new Information();
        private static Themes _themes = new Themes();

        private int _selectedTheme = _Global_Player.PlayerThemeId;


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

    }//end class
}//end namespace
