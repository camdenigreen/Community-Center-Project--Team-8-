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
    /// Interaction logic for PersonGroupsControl.xaml
    /// </summary>
    public partial class PersonGroupsControl : UserControl
    {
        public PersonGroupsControl()
        {
            InitializeComponent();
        }
        public event EventHandler<PersonEventGroupEventArgs> JoinGroup;


        private void ListViewSizeChanged3Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.05;
            var col2 = 0.316;
            var col3 = 0.634;


            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;

        }

        private void ClickJoinGroup(object sender, RoutedEventArgs e)
        {
            Group group = GroupsListView.SelectedItem as Group;

            JoinGroup.Invoke(this, new PersonEventGroupEventArgs(group.GroupId, true, "group"));
            /*
            PersonView person = this.DataContext as PersonView;
            if (person.JoinGroup(group.GroupId))
            {
                MessageBox.Show($"Group {group.Name} joined");
                //refresh
            }
            else
            {
                MessageBox.Show($" Could not join Group {group.Name}");
            }*/
        }
    }
}
