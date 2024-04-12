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

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// Interaction logic for MenuSelectControl.xaml
    /// </summary>
    public partial class MenuSelectControl : UserControl
    {
        public MenuSelectControl()
        {
            InitializeComponent();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            AggregatedQueryDisplay.Visibility = Visibility.Hidden;
            AggregatedQueryDisplay.Reset();
            EventDisplay.Visibility = Visibility.Hidden;
            ControlsGrid.Visibility = Visibility.Hidden;
            MenuSelectButtonGrid.Visibility = Visibility.Visible;
        }

        private void AggregatedQueryControlClick(object sender, RoutedEventArgs e)
        {
            MenuSelectButtonGrid.Visibility = Visibility.Hidden;
            ControlsGrid.Visibility = Visibility.Visible;
            AggregatedQueryDisplay.Visibility = Visibility.Visible;
        }

        private void EventControlClick(object sender, RoutedEventArgs e)
        {
            MenuSelectButtonGrid.Visibility = Visibility.Hidden;
            ControlsGrid.Visibility = Visibility.Visible;
            EventDisplay.Visibility = Visibility.Visible;
        }

    }
}
