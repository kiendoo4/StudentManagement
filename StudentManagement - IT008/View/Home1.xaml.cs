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

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for Home1.xaml
    /// </summary>
    public partial class Home1 : UserControl
    {
        public Home1()
        {
            InitializeComponent();
        }

        private void TroLai(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            currentUC.Children.Clear();
            currentUC.Children.Add(home);
        }
    }
}
