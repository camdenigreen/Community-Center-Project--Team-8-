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
            //Data validation
            //Create Group
            //Reset if it worked
            Reset();
        }
    }
}
