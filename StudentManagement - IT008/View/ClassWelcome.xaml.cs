using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ClassWelcome.xaml
    /// </summary>
    public partial class ClassWelcome : UserControl
    {
        ObservableCollection<MONHOC> lopList = new ObservableCollection<MONHOC>();
        public ClassWelcome()
        {
            InitializeComponent();
        }
        public ClassWelcome(LOP lop)
        {
            InitializeComponent();
            Khoi.Text = lop.KHOI.ToString();
            Tenlop.Text = lop.TENLOP;
            SS.Text = lop.SISO;
            Gvcn.Text = lop.TENGV;
            foreach (MONHOC l in Entity.ins.MONHOCs)
            {
                if(l.ISDELETED == false)
                {
                    lopList.Add(l);
                }    
            }
            DataPCCD.ItemsSource = lopList;
        }

    }
}
