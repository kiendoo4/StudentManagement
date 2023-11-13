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
    /// Interaction logic for Summarize_Subject.xaml
    /// </summary>
    public partial class Summarize_Subject : UserControl
    {
        public class Class
        {
            public int STT { get; set; }
            public String Lop { get; set; }
            public int SiSo { get; set; }
            public int SL_Dat { get; set; }
            public int TiLe { get; set; }
        }
        public class Student
        {
            public int STT { get; set; }
            public String Hoten { get; set; }
            public String Lop { get; set; }
            public float DiemTB { get; set; }
            public CheckBox Dat { get; set; }
            public int Hang { get; set; }
        }
        public Summarize_Subject()
        {
            InitializeComponent();
            cb_Period.SelectedIndex = 0;
            cb_Subject.SelectedIndex = 0;
            changeText();
            List<Class> list = new List<Class> {
                new Class{STT = 1, Lop = "10A1", SiSo=33, SL_Dat=20, TiLe=70},
                new Class{STT = 2, Lop = "10A2", SiSo=33, SL_Dat=20, TiLe=70},
                new Class{STT = 3, Lop = "10A3", SiSo=33, SL_Dat=20, TiLe=70}
            };
            List<Student> list1 = new List<Student>
            {
                new Student{STT=1, Hoten="Phan Văn Mãi", Lop="10A1", DiemTB=6.77f, Dat = new CheckBox(), Hang=1 },
                new Student{STT=1, Hoten="Phan Văn Mãi", Lop="10A1", DiemTB=6.77f, Dat = new CheckBox(), Hang=1 },
                new Student{STT=1, Hoten="Phan Văn Mãi", Lop="10A1", DiemTB=6.77f, Dat = new CheckBox(), Hang=1 }
            };
            tbl_TK_Chung.ItemsSource = list;
            tbl_TK_Cuthe.ItemsSource = list1;
        }
        public void changeText()
        {
            ComboBoxItem cbi_Period = (ComboBoxItem)cb_Period.SelectedItem;
            ComboBoxItem cbi_Subject = (ComboBoxItem)cb_Subject.SelectedItem;
            tb_Subject_Chung.Text = cbi_Period.Content.ToString() + " - Môn: " + cbi_Subject.Content.ToString();
            tb_Period_2.Text = tb_Subject_Chung.Text;
        }
        private void tbx_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbx_Search.Text == "Tìm kiếm")
            {
                tbx_Search.Text = "";
                tbx_Search.Foreground = Brushes.Black;
            }
        }

        private void tbx_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_Search.Text))
            {
                tbx_Search.Text = "Tìm kiếm";
                tbx_Search.Foreground = Brushes.Gray;
            }
        }

        private void cb_Search_In_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cb_Search_In_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_Period_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Period.SelectedItem != null && cb_Subject.SelectedItem != null)
            {
                changeText();
            }
        }

        private void cb_Subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_Period.SelectedItem != null && cb_Subject.SelectedItem != null)
            {
                changeText();
            }
        }
    }
}
