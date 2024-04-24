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
    /// Interaction logic for PersonLookupControl.xaml
    /// </summary>
    public partial class PersonLookupControl : UserControl
    {


        public PersonLookupControl()
        {
            InitializeComponent();
            PersonDisplay.ClickBackTriggered += ReturnToMembers;
            CreatePersonDisplay.ClickBackTriggered += ReturnToMembers;



        /*    List<Person> members = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person(i, "Tinaye", "Kutesa", "1602 Hillcrest Drive", "785-31717");

                members.Add(person);
            }
            MembersListView.DataContext = members;*/
            
           
        }

        public event EventHandler<MainMenuButtonEventArgs> SwitchButton;

        

        private UserControl prev_screen;
        


        private void DisplayPerson(object sender, AccessPersonEventArgs e)
        {
           
            PersonDisplay.Visibility = Visibility.Visible;
            prev_screen = PersonDisplay;

            PersonDisplay.DataContext = e.Person;
            //PersonDisplay.DataContext=new MockPerson(e.Person);
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

        public void ClickSelectPerson(object sender, RoutedEventArgs e)
        {
            Person person;
            if (MembersListView.SelectedItem is Person)
            {
                person = MembersListView.SelectedItem as Person;

                MembersDisplay.Visibility = Visibility.Hidden;
             

                SwitchButton.Invoke(this, new MainMenuButtonEventArgs(Visibility.Hidden));
                PersonControlGrid.Visibility = Visibility.Visible;
                PersonDisplay.Visibility = Visibility.Visible;
                prev_screen = PersonDisplay;
                PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
               
                PersonDisplay.DataContext = new PersonView(person);
              


            }
        }
        
            protected void ReturnToMembers(object sender,EventArgs e)
         {

            PersonDisplay.Visibility = Visibility.Hidden;
            prev_screen.Visibility = Visibility.Hidden;
            PersonControlGrid.Visibility = Visibility.Hidden;
            MembersDisplay.Visibility = Visibility.Visible;
            SwitchButton.Invoke(this, new MainMenuButtonEventArgs(Visibility.Visible));
            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            IReadOnlyList<Person> people = personRepository.RetrievePersons();
            MembersListView.DataContext = people;
            MembersListView.Items.Refresh();
            
        }

        private void ClickCreatePerson(object sender,RoutedEventArgs e)
        {
            MembersDisplay.Visibility = Visibility.Hidden;

          


            SwitchButton.Invoke(this, new MainMenuButtonEventArgs(Visibility.Hidden));
            PersonControlGrid.Visibility = Visibility.Visible;
            PersonDisplay.Visibility = Visibility.Hidden;
            CreatePersonDisplay.Visibility = Visibility.Visible;
            prev_screen = CreatePersonDisplay;
    
            CreatePersonDisplay.DataContext = new UpdatePersonView();
           
           

        }

        private void SearchByFirstNameClick(object sender,RoutedEventArgs e)
        {

        }
        private void SearchByLastNameClick(object sender, RoutedEventArgs e)
        {

        }












    }
}
