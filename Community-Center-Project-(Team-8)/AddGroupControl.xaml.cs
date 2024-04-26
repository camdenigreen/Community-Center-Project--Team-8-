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
using Xceed.Wpf.Toolkit;

namespace Community_Center_Project__Team_8_
{
    /// <summary>
    /// Interaction logic for AddGroupControl.xaml
    /// </summary>
    public partial class AddGroupControl : UserControl
    {
        public AddGroupControl()
        {
            InitializeComponent();
            StartUpText = " ";
        }

        private string _startUpText;
        public string StartUpText
        {
            get => _startUpText;
            set
            {
                if (value != _startUpText)
                {
                    _startUpText = value;
                }
            }
        }

        public void Reset()
        {
            NameTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
        }

        private void AddGroupClick(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim() == string.Empty || NameTextBox.Text.Trim().Length > 50)
            {
                System.Windows.MessageBox.Show("Name must be not null and less than 50 characters");
                return;
            }
            GroupRepository groupRepository = new GroupRepository(@"SERVER=(localdb)\MSSQLLocalDb;DATABASE=communitycenter;INTEGRATED SECURITY=SSPI;");
            Group g = groupRepository.CreateGroup(NameTextBox.Text.Trim(), DescriptionTextBox.Text.Trim());
            if (g != null) 
            {
                Reset();
                System.Windows.MessageBox.Show("Event successfully created");
            }
        }
    }
}
