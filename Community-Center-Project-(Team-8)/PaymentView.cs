using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
namespace Community_Center_Project__Team_8_
{
    public class PaymentView:INotifyPropertyChanged
    {

        private decimal _amount=0;
        public decimal Amount{ get
            {
                return _amount;
            }
            set
            {

                if (value <=0 )
                {
                    throw new ArgumentException("must be greater than zero");
                }
                else
                {
                    
                    _amount = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
                    
                }
            }

        }
        private string _reason;
        public string Reason { get
            {
                return _reason;
            }
            set
            {
                _reason = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));

            }

        }

        public int Id;

        public event PropertyChangedEventHandler PropertyChanged;

        public PaymentView(int id)
        {
            Id = id;
        }
        public bool Finalize => Amount > 0 && Reason.Length > 0;

        public void MakePayment()
        {

        }
    }
}
