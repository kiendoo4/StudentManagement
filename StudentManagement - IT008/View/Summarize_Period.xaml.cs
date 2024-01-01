using StudentManagement___IT008.Model;
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
    public partial class Summarize_Period : UserControl
    {
        private string year;
        public Summarize_Period(string year)
        {
            this.year = year;
            List<Class> list = new List<Class>();
            List<Student> list1 = new List<Student>();
            InitializeComponent();
            changeText();
            
        }
        public void changeText()
        {
            tb_Period_2.Text = tb_Subject_Chung.Text = year;
        }
        public List<Class> tbl1()
        {
            for
        }
    }
}
