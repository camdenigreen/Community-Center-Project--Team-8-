using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using DatabaseData.Models;

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// Interaction logic for AggregatedQueryControl.xaml
    /// </summary>
    public partial class AggregatedQueryControl : UserControl
    {
        public AggregatedQueryControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            ButtonGrid.Visibility = Visibility.Visible;
            ListViewDockPanel.Visibility = Visibility.Hidden;
            NegativeBalanceListView.Visibility = Visibility.Collapsed;
            UpcomingEventsListView.Visibility = Visibility.Collapsed;
            PastEventsListView.Visibility = Visibility.Collapsed;
            ActiveGroupsListView.Visibility = Visibility.Collapsed;
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void NegativeBalanceClick(object sender, RoutedEventArgs e)
        {
            ButtonGrid.Visibility = Visibility.Hidden;
            ListViewDockPanel.Visibility = Visibility.Visible;
            NegativeBalanceListView.Visibility = Visibility.Visible;

            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<PersonBalance> people = personRepository.RetrieveNegativeBalances();
            NegativeBalanceListView.DataContext = people;
        }

       

        private void UpcomingEventsClick(object sender, RoutedEventArgs e)
        {
            ButtonGrid.Visibility = Visibility.Hidden;
            ListViewDockPanel.Visibility = Visibility.Visible;
            UpcomingEventsListView.Visibility = Visibility.Visible;

            EventRepository eventRepository = new EventRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<EventRegistrants> events = eventRepository.RetrieveEventAttendence();
            UpcomingEventsListView.DataContext = events;
        }

        private void PastEventsClick(object sender, RoutedEventArgs e)
        {
            ButtonGrid.Visibility = Visibility.Hidden;
            ListViewDockPanel.Visibility = Visibility.Visible;
            PastEventsListView.Visibility = Visibility.Visible;

        }

        private void GroupActiveMembersClick(object sender, RoutedEventArgs e)
        {
            ButtonGrid.Visibility = Visibility.Hidden;
            ListViewDockPanel.Visibility = Visibility.Visible;
            ActiveGroupsListView.Visibility = Visibility.Visible;

        }


        private void ListViewSizeChanged5Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.05;
            var col2 = 0.2375;
            var col3 = 0.2375;
            var col4 = 0.2375;
            var col5 = 0.2375;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
        }

        private void ListViewSizeChanged4Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.05;
            var col2 = 0.316;
            var col3 = 0.316;
            var col4 = 0.316;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
        }

        private void ListViewSizeChanged9Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.05;
            var col2 = 0.178125;
            var col3 = 0.178125;
            var col4 = .0989583;
            var col5 = .0989583;
            var col6 = .0989583;
            var col7 = .0989583;
            var col8 = .0989583;
            var col9 = .0989583;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
            gView.Columns[6].Width = workingWidth * col7;
            gView.Columns[7].Width = workingWidth * col8;
            gView.Columns[8].Width = workingWidth * col9;

        }

    }
}
