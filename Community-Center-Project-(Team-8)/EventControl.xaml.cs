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
            AddEventDisplay.Visibility = Visibility.Hidden;
            EventControlsDisplay.Visibility = Visibility.Hidden;
            AddEventDisplay.Reset();
        }
        private void AddEventClick(object sender, RoutedEventArgs e)
        {
            ButtonDisplay.Visibility = Visibility.Hidden;
            EventControlsDisplay.Visibility = Visibility.Visible;
            AddEventDisplay.Visibility = Visibility.Visible;

            AddEventDisplay.DescriptionTextBox.Text = "";
        }
    }
}
