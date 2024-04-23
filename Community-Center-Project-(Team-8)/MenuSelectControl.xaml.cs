using DatabaseData.Models;
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
using DatabaseData;
using System.Net;


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
            MembersDisplay.SwitchButton += ManageMainMenuButton;
          
           
        }

        private UserControl prev_screen;
  
        private void ManageMainMenuButton(object sender,MainMenuButtonEventArgs e)
        {
            BackGrid.Visibility = e.Visibility;
        }




        protected void BackClick(object sender, RoutedEventArgs e)
        {
            AggregatedQueryDisplay.Visibility = Visibility.Hidden;
            AggregatedQueryDisplay.Reset();
            EventDisplay.Visibility = Visibility.Hidden;
            EventDisplay.Reset();
            GroupDisplay.Visibility = Visibility.Hidden;
            GroupDisplay.Reset();
            ControlsGrid.Visibility = Visibility.Hidden;
            MembersDisplay.Visibility = Visibility.Hidden;
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

        private void GroupControlClick(object sender, RoutedEventArgs e)
        {
            MenuSelectButtonGrid.Visibility = Visibility.Hidden;
            ControlsGrid.Visibility = Visibility.Visible;
            GroupDisplay.Visibility = Visibility.Visible;
        }
        private void MemberLookupClick(object sender, RoutedEventArgs e)
        {
            MenuSelectButtonGrid.Visibility = Visibility.Hidden;
            ControlsGrid.Visibility = Visibility.Visible;
            MembersDisplay.Visibility = Visibility.Visible;
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Person> people = personRepository.RetrievePersons();
            MembersDisplay.MembersListView.DataContext = people;



        }

    }
}
