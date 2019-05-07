using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SFLib;

namespace DieRoller.Views
{
    /// <summary>
    /// Interaction logic for Step1View.xaml
    /// </summary>
    public partial class Step1View : UserControl
    {
        
        public Step1View()
        {
            InitializeComponent();
        }

        
        //clears text when you focus on the controll
        private void ChraracterName_GotFocus(object sender, RoutedEventArgs e)
        {
            ChraracterName.Text = "";
        }
        //clears text when you focus on the controll
        private void PlayerName_GotFocus(object sender, RoutedEventArgs e)
        {
            PlayerName.Text = "";
        }
        //clears text when you focus on the controll
        private void CharacterConcept_GotFocus(object sender, RoutedEventArgs e)
        {
            CharacterConcept.Text = "";
        }

        private void PlayerNotes_GotFocus(object sender, RoutedEventArgs e)
        {
            PlayerNotes.Text = " ";
        }
    }
}
