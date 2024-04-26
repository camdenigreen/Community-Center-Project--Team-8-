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
    /// Interaction logic for PersonControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {
            InitializeComponent();
            DeletePersonDisplay.DeletedPerson += ClickBack;
            LeaveGroupDisplay.LeftGroup += UpdateGroupsEvents;
            LeaveEventDisplay.LeftEvent += UpdateGroupsEvents;
            GroupsPersonDisplay.JoinGroup += UpdateGroupsEvents;
            UpdatePersonDisplay.UpdatedInfo += UpdateInformation;
            PaymentDisplay.MakePayment += UpdateBalance;
            EventPersonDisplay.JoinEvent += UpdateGroupsEvents;

        }

        private void UpdateBalance(object sender, PaymentEventArgs e)
        {

            PersonView person = this.DataContext as PersonView;
            person.MakePayment(e.Amount,e.Reason,e.Time);
            //person.CalcBalance();
            TransactionsPersonDisplay.TransactionsListView.Items.Refresh();
            ClickBack(sender, new RoutedEventArgs());
            


        }
        private void UpdateInformation(object sender, EventArgs e)
        {
            PersonView person = this.DataContext as PersonView;
            string first = UpdatePersonDisplay.FirstName.Text.ToString();
            string last = UpdatePersonDisplay.LastName.Text.ToString();
            string address = UpdatePersonDisplay.Address.Text.ToString();
            string number = UpdatePersonDisplay.PhoneNumber.Text.ToString();
            person.UpdateInfo(first, last, number, address);



            prev_screen.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Hidden;
            PersonDisplay.Visibility = Visibility.Visible;

        }
        private void UpdateGroupsEvents(object sender, PersonEventGroupEventArgs e)
        {
            PersonView person = this.DataContext as PersonView;

            if (e.Type == "group")
            {
                if (e.Action == true)
                {
                    person.JoinGroup(e.Id,e.Group);
                    
                    GroupsPersonDisplay.GroupsListView.Items.Refresh();
                    MyGroups.Items.Refresh();

                }
                else
                {
                    person.LeaveGroup(e.Id,e.Group);
                    GroupsPersonDisplay.GroupsListView.Items.Refresh();
                    MyGroups.Items.Refresh();
                }
            }
            else if(e.Type == "event")
            {
                if (e.Action == true)
                {
                    person.JoinEvent(e.Id,e.Event);
                    MyEvents.Items.Refresh();
                    EventPersonDisplay.EventsListView.Items.Refresh();
                    TransactionsPersonDisplay.TransactionsListView.Items.Refresh();

                }
                else
                {
                    person.LeaveEvent(e.Id,e.Event);
                    MyEvents.Items.Refresh();
                    EventPersonDisplay.EventsListView.Items.Refresh();
                    TransactionsPersonDisplay.TransactionsListView.Items.Refresh();

                }

            }
            
            prev_screen.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Hidden;
            PersonDisplay.Visibility = Visibility.Visible;

        }

        private void ClickBack(object sender, EventArgs e)
        {

            prev_screen.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Hidden;
            PersonDisplay.Visibility = Visibility.Visible;
            ClickBackTriggered.Invoke(this, EventArgs.Empty);
            //rerun querries

        }

        private UserControl prev_screen;

        
        public event EventHandler ClickBackTriggered;

       

        private void ClickUpdateInfo(object sender, RoutedEventArgs e)
        {

            prev_screen = UpdatePersonDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            UpdatePersonDisplay.Visibility = Visibility.Visible;
            PersonView person = DataContext as PersonView;
            UpdatePersonDisplay.DataContext = new UpdatePersonView(person);

        }

        public void ClickBack(object sender, RoutedEventArgs e)
        {
            if (PersonDisplay.Visibility == Visibility.Visible)
            {
                ClickBackTriggered.Invoke(this, EventArgs.Empty);
            }
            else
            {
                prev_screen.Visibility = Visibility.Hidden;
                ViewModifyPerson.Visibility = Visibility.Hidden;
                PersonDisplay.Visibility = Visibility.Visible;
            }          
            
        }
        private void ClickAddEvent(object sender, RoutedEventArgs e)
        {
            prev_screen = EventPersonDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            EventPersonDisplay.Visibility = Visibility.Visible;
            PersonView person = this.DataContext as PersonView;
            EventPersonDisplay.DataContext = person;

        }
        private void ClickJoinGroup(object sender, RoutedEventArgs e)
        {
            prev_screen =GroupsPersonDisplay ;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            GroupsPersonDisplay.Visibility = Visibility.Visible;
            GroupsPersonDisplay.DataContext = this.DataContext;
            PersonView person = this.DataContext as PersonView; 
            GroupsPersonDisplay.DataContext = person;
        }
        private void ClickMakePayment(object sender, RoutedEventArgs e)
        {
            prev_screen = PaymentDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            PaymentDisplay.Visibility = Visibility.Visible;
           
            PersonView person = DataContext as PersonView;

            PaymentDisplay.DataContext = new PaymentView(person.Id);
        }
        private void ClickViewTransactions(object sender, RoutedEventArgs e)
        {
            prev_screen = TransactionsPersonDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            TransactionsPersonDisplay.Visibility = Visibility.Visible;
            
            TransactionsPersonDisplay.DataContext = this.DataContext;

        }
        private void ClickDeletePerson(object sender, RoutedEventArgs e)
        {
            prev_screen = DeletePersonDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            DeletePersonDisplay.Visibility = Visibility.Visible;
            DeletePersonDisplay.DataContext = this.DataContext;
        }

        private void ClickLeaveGroup(object sender, RoutedEventArgs e)
        {
          
            if (MyGroups.SelectedItem is Group)
            {
                prev_screen = LeaveGroupDisplay;
                PersonDisplay.Visibility = Visibility.Hidden;
                ViewModifyPerson.Visibility = Visibility.Visible;
                LeaveGroupDisplay.Visibility = Visibility.Visible;
                LeaveGroupDisplay.DataContext = MyGroups.SelectedItem;
            }

        }

            private void ClickLeaveEvent(object sender, RoutedEventArgs e)
        {
            
            if (MyEvents.SelectedItem is Event)
            {
                prev_screen = LeaveEventDisplay;
                PersonDisplay.Visibility = Visibility.Hidden;
                ViewModifyPerson.Visibility = Visibility.Visible;
                LeaveEventDisplay.Visibility = Visibility.Visible;
                LeaveEventDisplay.DataContext = MyEvents.SelectedItem;
            }
        }

    }
}
