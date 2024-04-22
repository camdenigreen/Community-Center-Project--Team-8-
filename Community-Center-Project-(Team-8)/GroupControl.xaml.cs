using DatabaseData;
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
    /// Interaction logic for GroupControl.xaml
    /// </summary>
    public partial class GroupControl : UserControl
    {
        public GroupControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            ButtonDisplay.Visibility = Visibility.Visible;
            AddGroupDisplay.Visibility = Visibility.Collapsed;
            GroupControlsDisplay.Visibility = Visibility.Hidden;
            SearchGroupDisplay.Visibility = Visibility.Collapsed;
            SearchGroupDisplay.ShowGroupDisplay.Visibility = Visibility.Hidden;
            AddGroupDisplay.Reset();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void AddGroupClick(object sender, RoutedEventArgs e)
        {
            ButtonDisplay.Visibility = Visibility.Hidden;
            GroupControlsDisplay.Visibility = Visibility.Visible;
            AddGroupDisplay.Visibility = Visibility.Visible;
            AddGroupDisplay.DescriptionTextBox.Text = "";
        }

        private void SearchGroupClick(object sender, RoutedEventArgs e)
        {
            
            ButtonDisplay.Visibility = Visibility.Hidden;
            GroupControlsDisplay.Visibility = Visibility.Visible;
            SearchGroupDisplay.Visibility = Visibility.Visible;
            SearchGroupDisplay.SearchingGrid.Visibility = Visibility.Visible;
            GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Group> groups = groupRepository.RetrieveGroups(null, null);
            SearchGroupDisplay.SearchGroupListView.DataContext = groups;
        }
    }
}
