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
    /// Interaction logic for Ranking_Period.xaml
    /// </summary>
    public partial class Ranking_Period : UserControl
    {
        private string period;
        public Ranking_Period(string period)
        {
            InitializeComponent();
            this.period = period;
            changeLabel();
            LoadData();
        }

        ObservableCollection<KQHOCKYTONGHOP> kq_chosen = new ObservableCollection<KQHOCKYTONGHOP>();

        public void LoadData()
        {
            string maHK = "";
            if (period == "Học kỳ I") maHK = "HK001";
            else maHK = "HK002";
            int count = 0;
            foreach (KQHOCKYTONGHOP kq in Entity.ins.KQHOCKYTONGHOPs.ToList())
            {
                if (kq.MAHK == maHK)
                {
                    kq_chosen.Add(kq);
                }
            }
            Ranking.ItemsSource = kq_chosen;
        }

        public void changeLabel()
        {
            tb_HK.Text = ChiTietHS.Text = this.period;
        }

        private void LoadSelection(object sender, SelectionChangedEventArgs e)
        {
            if (Ranking.SelectedItem != null)
            {
                KQHOCKYTONGHOP obj = kq_chosen[Ranking.SelectedIndex];
                ObservableCollection<KQHOCKYMONHOC> kq_hs = new ObservableCollection<KQHOCKYMONHOC>();
                foreach (KQHOCKYMONHOC kq in Entity.ins.KQHOCKYMONHOCs.ToList())
                {
                    if (kq.MAHS == obj.MAHS && kq.MAHK == obj.MAHK)
                    {
                        kq_hs.Add(kq);
                    }
                }
                RankCuThe.ItemsSource = kq_hs;
            }
        }
    }
}
