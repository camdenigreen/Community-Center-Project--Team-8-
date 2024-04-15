using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Community_Center_Project__Team_8_
{
    public  class MainMenuButtonEventArgs
    {
        public Visibility Visibility { get; private set; }
        public MainMenuButtonEventArgs(Visibility visible)
        {
            Visibility=visible;
        }
    }
}
