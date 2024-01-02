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
    /// Interaction logic for Home2.xaml
    /// </summary>
    public partial class Home2 : UserControl
    {
        public Home2()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public bool isLoaded = false;
        public string Lop { get; set; }
        public string Siso { get; set; }

        public string GVCN { get; set; }
        private void Button_click(object sender, RoutedEventArgs e)
        {
           
            Home1 home1 = new Home1();
            MessageBox.Show("ákfkaskass");
            
            
        }
    }
}
