﻿using DatabaseData;
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
           
            bool search = false;

            PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");

            IReadOnlyList<Person> persons = personRepository.RetrievePersons(PhoneNumber.Text.ToString(), null);
            foreach (Person p in persons)
            {
                if (p.PhoneNumber.Equals(PhoneNumber.Text, StringComparison.OrdinalIgnoreCase))
                {
                    if (FirstName.Text.Equals(p.FirstName, StringComparison.OrdinalIgnoreCase) && LastName.Text.Equals(p.LastName, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Already exists");
                        search = true;
                    }
                }
            }

            if (search == false)
            {
                CreatePersonInfo.Visibility = Visibility.Hidden;
                ConfirmInformation.Visibility = Visibility.Visible;
                PersonView person = new PersonView(FirstName.Text.ToString(), LastName.Text.ToString(), Address.Text.ToString(), PhoneNumber.Text.ToString());
                this.DataContext = person;
                ConfirmInformation.DataContext = this.DataContext;
            }
            



           
        }


        private void ClickConfirmCreate(object sender, RoutedEventArgs e)
        {
            

            if (ConfirmInformation.DataContext is PersonView)
            {
                PersonView person = ConfirmInformation.DataContext as PersonView;
                PersonRepository personRepository = new PersonRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
                personRepository.CreatePerson(person.FirstName,person.LastName,person.Address,person.PhoneNumber,1);

                
                MessageBox.Show($" Person {person.FirstName} {person.LastName} {person.PhoneNumber} created successfully");
                CreatePersonInfo.Visibility = Visibility.Visible;
                ConfirmInformation.Visibility = Visibility.Hidden;
               
                ClickBackTriggered.Invoke(this, EventArgs.Empty);
                FirstName.Text = "";
                LastName.Text = "";
                Address.Text = "";
                PhoneNumber.Text = "";
            }
           


        }

    }
}
