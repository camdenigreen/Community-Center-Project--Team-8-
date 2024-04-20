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
    /// Interaction logic for CreatePersonControl.xaml
    /// </summary>
    public partial class CreatePersonControl : UserControl
    {
        public CreatePersonControl()
        {
            InitializeComponent();
        }

        public event EventHandler ClickBackTriggered;

       

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            //what screen should we go back to
            //the createperson info or the members page
            if(ConfirmInformation.Visibility == Visibility.Visible)
            {
                CreatePersonInfo.DataContext = ConfirmInformation.DataContext;
                CreatePersonInfo.Visibility = Visibility.Visible;
                ConfirmInformation.Visibility = Visibility.Hidden;

                PersonView person = this.DataContext as PersonView;
                MessageBox.Show(person.FirstName.Length.ToString());
                MessageBox.Show(person.LastName.Length.ToString());
                MessageBox.Show(person.PhoneNumber.Length.ToString());
                MessageBox.Show(person.FirstName.Length.ToString());

                MessageBox.Show(person.Finalize.ToString());
                
               
                
            }
            else
            {
                
               
                ClickBackTriggered.Invoke(this, EventArgs.Empty);
                CreatePersonInfo.Visibility = Visibility.Visible;
                FirstName.Text = "";
                LastName.Text = "";
                Address.Text = "";
                PhoneNumber.Text = "";


            }

        }
        private void ClickCreate(object sender, RoutedEventArgs e)
        {
            CreatePersonInfo.Visibility = Visibility.Hidden;
            ConfirmInformation.Visibility = Visibility.Visible;
            PersonView person = new PersonView(FirstName.Text.ToString(), LastName.Text.ToString(), Address.Text.ToString(), PhoneNumber.Text.ToString());
            this.DataContext = person;
            ConfirmInformation.DataContext = this.DataContext;



           
        }


        private void ClickConfirmCreate(object sender, RoutedEventArgs e)
        {
            //Create actual person in database using the textboxes
            //if the insertion is successful

            if (true)
            {
                int id = 0;
                MessageBox.Show($" Person {id.ToString()} created successfully");
                CreatePersonInfo.Visibility = Visibility.Visible;
                ConfirmInformation.Visibility = Visibility.Hidden;
               // Back.Visibility = Visibility.Hidden;
                ClickBackTriggered.Invoke(this, EventArgs.Empty);
                FirstName.Text = "";
                LastName.Text = "";
                Address.Text = "";
                PhoneNumber.Text = "";
            }
            //message successfully created
            //go back to the person lookup menu
            //display message, person already exists
            //go back to the previous page



        }

    }
}
