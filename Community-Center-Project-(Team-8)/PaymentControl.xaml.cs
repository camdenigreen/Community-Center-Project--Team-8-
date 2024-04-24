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
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }
        public event EventHandler<PaymentEventArgs> MakePayment;
        private void ClickFinalize(object sender, RoutedEventArgs e)
        {
            //PersonView person = this.DataContext as PersonView;
            //person.MakePayment(decimal.Parse(AmountBox.Text));
            PaymentView pay = this.DataContext as PaymentView;
            DateTime time = pay.MakePayment();
            MessageBox.Show("Payment Complete");
            
           

                MakePayment.Invoke(this, new PaymentEventArgs(Reason.Text.ToString(),pay.Amount, time));
           
        
        }
    }
}
