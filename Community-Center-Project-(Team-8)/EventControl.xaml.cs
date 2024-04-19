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
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        public EventControl()
        {
            InitializeComponent();
        }

        public void Reset() 
        {
            ButtonDisplay.Visibility = Visibility.Visible;
            AddEventDisplay.Visibility = Visibility.Collapsed;
            EventControlsDisplay.Visibility = Visibility.Hidden;
            SearchEventDisplay.Visibility = Visibility.Collapsed;
            SearchEventDisplay.ShowEventDisplay.Visibility = Visibility.Hidden;
            AddEventDisplay.Reset();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void AddEventClick(object sender, RoutedEventArgs e)
        {
            ButtonDisplay.Visibility = Visibility.Hidden;
            EventControlsDisplay.Visibility = Visibility.Visible;
            AddEventDisplay.Visibility = Visibility.Visible;

            AddEventDisplay.DescriptionTextBox.Text = "";
        }

        private void SearchEventClick(object sender, RoutedEventArgs e)
        {
            ButtonDisplay.Visibility = Visibility.Hidden;
            EventControlsDisplay.Visibility = Visibility.Visible;
            SearchEventDisplay.Visibility = Visibility.Visible;
            SearchEventDisplay.SearchingGrid.Visibility = Visibility.Visible;
        }
    }
}
