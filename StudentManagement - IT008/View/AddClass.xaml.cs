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
using System.Data.SqlClient;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddClass.xaml
    /// </summary>
    public partial class AddClass : UserControl
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=LAPTOP-9VMFMRRH\\SQLEXPRESS;Initial Catalog=QUANLYHOCSINH;Integrated Security=True;Trust Server Certificate=True";

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
