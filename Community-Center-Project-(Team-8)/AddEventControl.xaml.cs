using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using DatabaseData;

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
            if (NameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Event must have a name.");
                return;
            }
            if (OrganizerTextBox.Text == string.Empty)
            {
                MessageBox.Show("Event must have an organizer.");
                return;
            }
            DateTime dateTime = DateTime.Now;
            if (DateTimePicker.Text == string.Empty)
            {
                MessageBox.Show("Event must have an date.");
                return;
            }
            decimal charge;
            if (ChargeTextBox.Text == string.Empty)
            {
                charge = 0;
            }
            else if (!decimal.TryParse(ChargeTextBox.Text, out charge))
            {
                MessageBox.Show("Charge is valid");
            }
            if (NameTextBox.Text.Trim().Length > 50)
            {
                MessageBox.Show("Name must be less than 50 characters");
                return;
            }
            if (OrganizerTextBox.Text.Trim().Length > 50)
            {
                MessageBox.Show("Organizer must be less than 50 characters");
                return;
            }
            int groupid;
            int? groupID;
            if (GroupIDTextBox.Text.Trim() == string.Empty)
            {
                groupID = null;
            }
            else if (!int.TryParse(GroupIDTextBox.Text.Trim(), out groupid))
            {
                MessageBox.Show("Group ID must be an integer");
                return;
            }
            else
            {
                groupID = groupid;
                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(groupID, null);
                if (groups.Count != 1)
                {
                    MessageBox.Show("Group ID does not reference existing group.");
                    return;
                }
            }
            EventRepository eventRepository = new EventRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            DateTime yeah = (DateTime)DateTimePicker.Value;
            IReadOnlyList<Event> matchingEvents = eventRepository.RetrieveEvents(null, NameTextBox.Text.Trim());
            foreach (Event ee in  matchingEvents)
            {
                if (NameTextBox.Text.Trim().Equals(ee.Name, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Event with this name already exists.");
                    return;
                }
            }

            Event createdEvent = eventRepository.CreateEvent(NameTextBox.Text.Trim(),
                groupID,
                DescriptionTextBox.Text.Trim(),
                OrganizerTextBox.Text.Trim(),
                yeah, 
                charge);
            if (createdEvent != null) 
            {
                MessageBox.Show("Event successfully created");
                Reset();
            }


        }
    }
}