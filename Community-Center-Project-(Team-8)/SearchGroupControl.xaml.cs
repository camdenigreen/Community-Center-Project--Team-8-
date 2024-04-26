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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseData;
using DatabaseData.IRepository;

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// Interaction logic for SearchGroupControl.xaml
    /// </summary>
    public partial class SearchGroupControl : UserControl
    {
        public SearchGroupControl()
        {
            InitializeComponent();
        }

        private void ListViewSizeChanged3Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.25;
            var col2 = 0.25;
            var col3 = 0.50;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
        }

        private void SearchByGroupIdClick(object sender, RoutedEventArgs e)
        {
            int i;
            if (Int32.TryParse(GroupIdTextBox.Text, out i))
            {
                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(i, null);
                SearchGroupListView.DataContext = groups;
            }
            else if (String.IsNullOrEmpty(GroupIdTextBox.Text))
            {
                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(null, null);
                SearchGroupListView.DataContext = groups;
            }
        }

        private void SearchByGroupNameClick(object sender, RoutedEventArgs e)
        {
            if (GroupNameTextbox.Text.Trim().Length <=50)
            {
                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(null, GroupNameTextbox.Text.Trim());
                SearchGroupListView.DataContext = groups;
            }
            else if (String.IsNullOrEmpty(GroupNameTextbox.Text))
            {
                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(null, null);
                SearchGroupListView.DataContext = groups;
            }
        }

        private void GoToGroupClick(object sender, RoutedEventArgs e)
        {
            if (SearchGroupListView.SelectedItem is Group group)
            {
                ShowGroupDisplay.DataContext = group;

                GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                IReadOnlyList<Person> peopleInGroup = groupRepository.RetrievePeopleInGroup(group.GroupId);
                ShowGroupDisplay.PeopleInGroupListView.DataContext = peopleInGroup;
                
                IReadOnlyList<Event> eventsInGroup = groupRepository.RetrieveEventsInGroup(group.GroupId);
                ShowGroupDisplay.EventsInGroupListView.DataContext = eventsInGroup;

                SearchingGrid.Visibility = Visibility.Hidden;
                ShowGroupDisplay.Visibility = Visibility.Visible;
            }
        }
    }
}
