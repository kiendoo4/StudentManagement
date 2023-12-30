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
using System.Windows.Shapes;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public AddTeacher()
        {
            InitializeComponent();
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
