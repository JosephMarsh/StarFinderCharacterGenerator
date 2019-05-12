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
    /// Interaction logic for DieRollView.xaml
    /// </summary>
    public partial class DieRollView : UserControl
    {

        private static Information info = new Information();

        //Feed each description string into an array so that the selected item number -
        //(ability score name) match up with the description of that ablity score.
        private string[] abilityScoreDescriptions = { info.charismaStat, info.consitutionStat,
            info.dexterityStat, info.intellienceStat, info.strengthStat, info.wisdomStat };

        public DieRollView()
        {
            InitializeComponent();
        }
        private void AbilityScoreNameChanged(object sender, SelectionChangedEventArgs e)
        {
            //ability score validation.
            comboButtonsMatchValidation();
        }

        /// <summary>Method that Validates that all ability score combo boxes contain a unique Ability score selection.</summary>
        protected void comboButtonsMatchValidation()
        {
            //creat an array of selected indexes for ability score name combo boxes.
            int[] comboBoxSelectedInexes = { ComboBoxAssign1.SelectedIndex, ComboBoxAssign2.SelectedIndex, ComboBoxAssign3.SelectedIndex, ComboBoxAssign4.SelectedIndex, ComboBoxAssign5.SelectedIndex, ComboBoxAssign6.SelectedIndex };

            //check if the number of distict items in the array match the lenght of the array
            //in other words make sure none of the selected itmes match
            if (comboBoxSelectedInexes.Distinct().Count() == comboBoxSelectedInexes.Count())
            {
                //if true (non of the items match) enable commit and hide error
                FinalCommit.IsEnabled = true;
                AbilityNameMatchesErrorMsg.Visibility = Visibility.Hidden;
            }
            else
            {
                //if false disable button and show error
                FinalCommit.IsEnabled = false;
                AbilityNameMatchesErrorMsg.Visibility = Visibility.Visible;
            }
        }//end comboButtonsMatchValidation


        
        private void IntUpDown1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign1.SelectedIndex];
        }

        private void IntUpDown2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign2.SelectedIndex];
        }

        private void IntUpDown3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign3.SelectedIndex];
        }

        private void IntUpDown4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign4.SelectedIndex];
        }

        private void IntUpDown5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign5.SelectedIndex];
        }

        private void IntUpDown6_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Update info box based on related stat selected in Combobox
            TextBoxInfo1.Text = abilityScoreDescriptions[ComboBoxAssign6.SelectedIndex];
        }

        private void RaioButtonCore_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxInfo1.Text = info.rollModeCore;
        }

        private void RaioButtonStandard_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxInfo1.Text = info.rollModeStandard;
        }

        private void RaioButtonPointBuy_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxInfo1.Text = info.rollModepointBuy;
        }

        private void IsGodMode_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxInfo1.Text = info.rollModeGod;
        }
    }
}
