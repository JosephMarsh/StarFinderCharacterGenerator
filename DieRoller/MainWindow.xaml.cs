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

namespace DieRoller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //CharacterAtributes[0].ToString();

        public MainWindow()
        {
            InitializeComponent();

            
            Information Info = new Information();
            RandomNumber RNumb = new RandomNumber();
            PlayerCharacter Player = new PlayerCharacter();
            //TextBoxFinalScoreStr.DataContext = Player;
    }

        private void RaioButtonPointBuy_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
