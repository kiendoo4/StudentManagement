using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddNewYear.xaml
    /// </summary>
    public partial class AddNewYear : UserControl, INotifyPropertyChanged
    {
        private DateTime today;
        public DateTime Today
        {
            get { return today; }
            set
            {
                if (today != value)
                {
                    today = value;
                    OnPropertyChanged("Today");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public AddNewYear()
        {
            InitializeComponent();
            DataContext = this;
            Today = DateTime.Today;
        }
    }
}
