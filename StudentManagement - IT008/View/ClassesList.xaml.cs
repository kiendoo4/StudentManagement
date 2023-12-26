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
    /// Interaction logic for Conclusion.xaml
    /// </summary>
    public partial class ClassesList : UserControl
    {
        public ClassesList()
        {
            InitializeComponent();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        string query = "SELECT * FROM YourTable";
            //        SqlCommand command = new SqlCommand(query, connection);
            //        SqlDataReader reader = command.ExecuteReader();

            //        Data.Items.Clear(); // Đảm bảo xóa dữ liệu cũ trước khi thêm mới

            //        while (reader.Read())
            //        {
            //            // Tạo một đối tượng để lưu trữ dữ liệu từ SQL Server
            //            YourDataModel dataItem = new YourDataModel
            //            {
            //                // Gán dữ liệu từ reader vào các thuộc tính của đối tượng
            //                // Ví dụ: dataItem.Property1 = reader["Column1"];
            //                // Ví dụ: dataItem.Property2 = reader["Column2"];
            //            };

            //            // Thêm đối tượng vào DataGrid
            //            dataGrid.Items.Add(dataItem);
            //        }

            //        reader.Close();
            //        connection.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (AddClassBox.Visibility == Visibility.Visible)
            {
                AddClassBox.Visibility = Visibility.Collapsed;
            }
            else 
            {
                AddClassBox.Visibility = Visibility.Visible;
            }
            ClassInfoBox.Visibility = Visibility.Collapsed;
        }
    }
}
