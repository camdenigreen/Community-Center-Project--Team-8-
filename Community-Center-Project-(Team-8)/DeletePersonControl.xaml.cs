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
    /// Interaction logic for DeletePersonControl.xaml
    /// </summary>
    public partial class DeletePersonControl : UserControl
    {
        public DeletePersonControl()
        {
            InitializeComponent();
        }

        public event EventHandler DeletedPerson;

        private void ClickDelete(object sender, RoutedEventArgs e)
        {
            PersonView person = this.DataContext as PersonView;
            person.Delete();
            int id = person.Id;
            MessageBox.Show("SuccessfullyDeleted # " + id.ToString());
            //go back to members screen
            DeletedPerson.Invoke(this, EventArgs.Empty);
        }
    }
}
