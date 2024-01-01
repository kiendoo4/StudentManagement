using CommunityToolkit.Mvvm.ComponentModel;
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
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class Overview : UserControl
    {
        ObservableCollection<HOCSINH> hocsinhList = new ObservableCollection<HOCSINH>();
        ObservableCollection<LOP> lopList = new ObservableCollection<LOP>();
        ObservableCollection<TAIKHOAN> taikhoanList = new ObservableCollection<TAIKHOAN>();
        ObservableCollection<NAMHOC> namhocList = new ObservableCollection<NAMHOC>();
        public Overview()
        {
            InitializeComponent();
            SetupData();
            SLL.Text = Convert.ToString(lopList.Count);
            SLHS.Text = Convert.ToString(hocsinhList.Count);
            SLGV.Text = Convert.ToString(taikhoanList.Count);
            SubscribeToCollectionChangedEvents();
        }
        private void SetupData()
        {
            // Your data initialization logic here

            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    taikhoanList.Add(tk);
            }

            foreach (NAMHOC namhoc in Entity.ins.NAMHOCs)
            {
                CurrentYear.Items.Add(namhoc.TENNAMHOC);
                namhocList.Add(namhoc);
            }

            foreach (HOCSINH hs in Entity.ins.HOCSINHs)
            {
                if (hs.ISDELETED == false)
                {
                    hocsinhList.Add(hs);
                }
            }

            foreach (LOP l in Entity.ins.LOPs)
            {
                if (l.ISDELETED == false)
                {
                    lopList.Add(l);
                }
            }
        }
        private void TaikhoanList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            taikhoanList.Clear();
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    taikhoanList.Add(tk);
            }
            SLGV.Text = Convert.ToString(taikhoanList.Count);
        }
        private void NamhocList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CurrentYear.Items.Clear();
            foreach (NAMHOC namhoc in Entity.ins.NAMHOCs)
            {
                CurrentYear.Items.Add(namhoc.TENNAMHOC);
                namhocList.Add(namhoc);
            }
        }
        private void HocsinhList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            hocsinhList.Clear();
            foreach (HOCSINH hs in Entity.ins.HOCSINHs)
            {
                if (hs.ISDELETED == false)
                {
                    hocsinhList.Add(hs);
                }
            }
            SLHS.Text = Convert.ToString(hocsinhList.Count);
            MessageBox.Show(SLHS.Text);
        }

        private void LopList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lopList.Clear();
            foreach (LOP l in Entity.ins.LOPs)
            {
                if (l.ISDELETED == false)
                {
                    lopList.Add(l);
                }
            }
            SLL.Text = Convert.ToString(lopList.Count);
        }

        private void SubscribeToCollectionChangedEvents()
        {
            taikhoanList.CollectionChanged += TaikhoanList_CollectionChanged;
            namhocList.CollectionChanged += NamhocList_CollectionChanged;
            hocsinhList.CollectionChanged += HocsinhList_CollectionChanged;
            lopList.CollectionChanged += LopList_CollectionChanged;
        }
    }
}
