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
    /// Interaction logic for LeaveGroup.xaml
    /// </summary>
    public partial class LeaveGroup : UserControl
    {
        public LeaveGroup()
        {
            InitializeComponent();
        }

        public event EventHandler<PersonEventGroupEventArgs> LeftGroup;

        private void ClickLeaveGroup(object sender,RoutedEventArgs e)
        {
            //MessageBox.Show("left Group");
            Group group = this.DataContext as Group;
            int id = group.GroupId;
            LeftGroup.Invoke(this, new PersonEventGroupEventArgs(group.GroupId,false,"group"));
            MessageBox.Show("Left Group #" + id);
           
        }
    }
}
