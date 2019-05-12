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
using DieRoller.ViewModels;

namespace DieRoller.Views
{
    /// <summary>
    /// Contians Controlls for Creating the Character sheet.
    /// </summary>
    public partial class Step1View : UserControl
    {
        private static PlayerCharacter _Global_Player = ShellViewModel.Global_Player;

        public Step1View()
        {
            InitializeComponent();
        }

        
        //clears text when you focus on the controll
        private void ChraracterName_GotFocus(object sender, RoutedEventArgs e)
        {
            //when user clicks in feld clear it
            ChraracterName.Text = "";
            //when user clicks in field refersh all empty fields.
            //player name
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                PlayerName.Text = _Global_Player.PlayerName;
            }
            //Concept
            if (string.IsNullOrEmpty(CharacterConcept.Text))
            {
                CharacterConcept.Text = _Global_Player.Concept;
            }
            //Notes remain empty
        }
        //clears text when you focus on the controll
        private void PlayerName_GotFocus(object sender, RoutedEventArgs e)
        {
            //when user clicks in feld clear it
            PlayerName.Text = "";
            //when user clicks in field refersh all empty fields.
            //Character name
            if (string.IsNullOrEmpty(ChraracterName.Text))
            {
                ChraracterName.Text = _Global_Player.CharacterName;
            }
            //Concept
            if (string.IsNullOrEmpty(CharacterConcept.Text))
            {
                CharacterConcept.Text = _Global_Player.Concept;
            }
            //Notes remain empty
        }
        //clears text when you focus on the controll
        private void CharacterConcept_GotFocus(object sender, RoutedEventArgs e)
        {
            //when user clicks in feld clear it
            CharacterConcept.Text = "";

            //when user clicks in field refersh all empty fields.
            //Character name
            if (string.IsNullOrEmpty(ChraracterName.Text))
            {
                ChraracterName.Text = _Global_Player.CharacterName;
            }
            //player name
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                PlayerName.Text = _Global_Player.PlayerName;
            }
            //Notes remain empty
        }

        private void PlayerNotes_GotFocus(object sender, RoutedEventArgs e)
        {
            //when user clicks in feld clear it
            PlayerNotes.Text = " ";

            //when user clicks in field refersh all empty fields.
            //character name
            if (string.IsNullOrEmpty(ChraracterName.Text))
            {
                ChraracterName.Text = _Global_Player.CharacterName;
            }
            //player name
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                PlayerName.Text = _Global_Player.PlayerName;
            }
            //Concept
            if (string.IsNullOrEmpty(CharacterConcept.Text))
            {
                CharacterConcept.Text = _Global_Player.Concept;
            }
            //Notes remain empty
        }

        private void CommitButton_GotFocus(object sender, RoutedEventArgs e)
        {
            //refresh empty fields
            //character name
            if (string.IsNullOrEmpty(ChraracterName.Text))
            {
                ChraracterName.Text = _Global_Player.CharacterName;
            }
            //player name
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                PlayerName.Text = _Global_Player.PlayerName;
            }
            //Concept
            if (string.IsNullOrEmpty(CharacterConcept.Text))
            {
                CharacterConcept.Text = _Global_Player.Concept;
            }
            //Notes remain empty
        }
    }
}
