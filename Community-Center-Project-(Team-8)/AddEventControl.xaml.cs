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
    /// Interaction logic for AddEventControl.xaml
    /// </summary>
    public partial class AddEventControl : UserControl
    {
        public AddEventControl()
        {
            InitializeComponent();

            //validate information
            //enable button when only stuff are all fixed
            //attempt to add event
            //get message from the database whether it is successful 
            //success message, show event, then back button.
            //property changed for array of events
            DescriptionTextBox.DataContext = this;
            StartUpText = " ";
        }

        private string _startUpText;
        public string StartUpText
        {
            get => _startUpText;
            set
            {
                if (value != _startUpText)
                {
                    _startUpText = value;
                }
            }
        }

        public void Reset()
        {
            NameTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            GroupIDTextBox.Text = string.Empty;
            OrganizerTextBox.Text = string.Empty;
            ChargeTextBox.Text = string.Empty;
            DateTimePicker.Text = string.Empty;
        }

        private void CreateEventClick(object sender, RoutedEventArgs e)
        {
            //Data validation
            //Create event
            //Reset if it worked
            Reset();
        }
    }
}