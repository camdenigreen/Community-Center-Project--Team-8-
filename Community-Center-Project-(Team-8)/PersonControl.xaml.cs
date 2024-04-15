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
        }
        private UserControl prev_screen;

        
        public event EventHandler ClickBackTriggered;

       

        private void ClickUpdateInfo(object sender, RoutedEventArgs e)
        {

            prev_screen = UpdatePersonDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            UpdatePersonDisplay.Visibility = Visibility.Visible;
            UpdatePersonDisplay.DataContext = this.DataContext;

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
            
            EventPersonDisplay.DataContext = this.DataContext;

        }
        private void ClickJoinGroup(object sender, RoutedEventArgs e)
        {
            prev_screen =GroupsPersonDisplay ;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            GroupsPersonDisplay.Visibility = Visibility.Visible;
            GroupsPersonDisplay.DataContext = this.DataContext;
        }
        private void ClickMakePayment(object sender, RoutedEventArgs e)
        {
            prev_screen = PaymentDisplay;
            PersonDisplay.Visibility = Visibility.Hidden;
            ViewModifyPerson.Visibility = Visibility.Visible;
            PaymentDisplay.Visibility = Visibility.Visible;
            PaymentDisplay.DataContext = this.DataContext;

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

        }

        private void ClickLeaveGroup(object sender, RoutedEventArgs e)
        {
          // person = MembersListView.SelectedItem as Person;
        }

        private void ClickLeaveEvent(object sender, RoutedEventArgs e)
        {
            // person = MembersListView.SelectedItem as Person;
        }



    }
}
