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
    /// Interaction logic for UpdatePersonControl.xaml
    /// </summary>
    public partial class UpdatePersonControl : UserControl
    {
        public UpdatePersonControl()
        {
            InitializeComponent();
        }
        public event EventHandler UpdatedInfo;
        private void ClickUpdate(object sender, RoutedEventArgs e)
        {
            //attempt to insert into database;


            //PersonView person = DataContext as PersonView;

            // this.DataContext = new UpdatePersonView();
            UpdatePersonView person = this.DataContext as UpdatePersonView;

           if( person.UpdateInfo())
            {

                MessageBox.Show($"Information updated");
                UpdatedInfo.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show($"Failed, person already exists");
            }
        }
    }
}
