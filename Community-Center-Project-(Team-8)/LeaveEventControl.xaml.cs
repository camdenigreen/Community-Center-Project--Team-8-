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

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// Interaction logic for LeaveEventControl.xaml
    /// </summary>
    public partial class LeaveEventControl : UserControl
    {
        public LeaveEventControl()
        {
            InitializeComponent();
        }

        public event EventHandler<PersonEventGroupEventArgs> LeftEvent;

        private void ClickLeaveEvent(object sender, RoutedEventArgs e)
        {
            Event even = this.DataContext as Event;
            int id = even.EventId;
            MessageBox.Show("Left Event #" + id);
            LeftEvent.Invoke(this, new PersonEventGroupEventArgs(even.EventId, false, "event",even));
        }
    }
}
