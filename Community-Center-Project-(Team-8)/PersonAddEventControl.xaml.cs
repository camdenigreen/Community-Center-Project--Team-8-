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
    /// Interaction logic for PersonAddEventControl.xaml
    /// </summary>
    public partial class PersonAddEventControl : UserControl
    {
        public PersonAddEventControl()
        {
            InitializeComponent();
        }
        //show all upcoming events

/*
        private void ListViewSizeChanged7Column(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.05;
            var col2 = 0.1583;
            var col3 = 0.1583;
            var col4 = .1583;
            var col5 = .1583;
            var col6 = .237567;
            var col7 = .1583;
            var col8 = .079166;
           

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
            gView.Columns[6].Width = workingWidth * col7;
            gView.Columns[7].Width = workingWidth * col8;
        }
*/
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

        private void ClickAddEvent(object sender, RoutedEventArgs e)
        {
            //all events that a person is not in 

        }
    }
}
