using SFLib;
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

namespace DieRoller.Views
{
    /// <summary>
    /// Interaction logic for Step2View.xaml
    /// </summary>
    public partial class Step2View : UserControl
    {
        private string _raceName;
        public Step2View()
        {
            InitializeComponent();
        }

        private void RaceName_GotFocus(object sender, RoutedEventArgs e)
        {
            _raceName = RaceName.Text;
            RaceName.Text = "";
        }

        private void RaceName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RaceName.Text))
            {
                RaceName.Text = _raceName;
            }
        }
    }
}
