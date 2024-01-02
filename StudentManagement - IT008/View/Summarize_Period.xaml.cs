using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
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
        private List<TK_P_CHUNG> chung;
        public Summarize_Period(string year)
        {
            this.year = year;
            InitializeComponent();
            changeText();
            tbl_TK_Chung.Items.Clear();
            chung = GetTKChung();
            tbl_TK_Chung.ItemsSource = chung; 
        }
        public void changeText()
        {
            tb_Period_2.Text = tb_Subject_Chung.Text = year;
        }
        private List<TK_P_CHUNG> GetTKChung()
        {
            List<TK_P_CHUNG> ls = new List<TK_P_CHUNG>();
            int stt = 1;
            foreach(LOP l in Entity.ins.LOPs)
            {
                TK_P_CHUNG tk_lop = new TK_P_CHUNG();
                string malop = l.MALOP;
                string tenlop = l.KHOI + l.TENLOP;
                LOPHOCTHUCTE lhtt = l.LOPHOCTHUCTEs.SingleOrDefault(lda => lda.MALOP == malop);
                int siso = lhtt.HOCSINHs.Count();
                int soluongdat = 0;
                int stt_2 = 1;
                foreach(HOCSINH hs in lhtt.HOCSINHs)
                {
                    bool check = true;
                    TK_P_CHITIET tk_hs = new TK_P_CHITIET();
                    double dtb = 0;
                    if (year == "Cả năm")
                    {
                        int count = 0;
                        foreach(KQHOCKYTONGHOP kqhk in Entity.ins.KQHOCKYTONGHOPs)
                        {
                            if (count == 2) break;
                            if (kqhk.MAHS == hs.MAHS)
                            {
                                count++;
                                dtb += (double)kqhk.DTBTatCaMonHocKy;
                            }
                        }
                        dtb /= 2;
                    } else
                    {
                        KQHOCKYTONGHOP kq;
                        if (year == "Học kỳ I") kq = Entity.ins.KQHOCKYTONGHOPs.SingleOrDefault(lda => lda.MAHS == hs.MAHS && lda.MAHK == "HK001");
                        else kq = Entity.ins.KQHOCKYTONGHOPs.SingleOrDefault(lda => lda.MAHS == hs.MAHS && lda.MAHK == "HK002");

                        dtb = (double)kq.DTBTatCaMonHocKy;
                    }
                    if (dtb < 5)
                    {
                        check = false;
                    }
                    if (check) soluongdat++;
                    tk_hs = new TK_P_CHITIET { STT=stt_2, Hoten=hs.HOTENHS, Lop=tenlop, DiemTB=dtb.ToString("0.00"), Dat = check, Hang = 1};
                    tk_lop.Tk_hs.Add(tk_hs);
                    stt_2++;
                }
                tk_lop.STT = stt;
                tk_lop.Lop = tenlop;
                tk_lop.SiSo = siso;
                tk_lop.SL_Dat = soluongdat;
                tk_lop.TiLe = ((float)soluongdat / siso * 100).ToString() + "%";
                ls.Add(tk_lop);
                stt++;
            }
            return ls;
        }
        private void EditClass(object sender, RoutedEventArgs e)
        {

        }

        private void tbl_TK_Chung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbl_TK_Chung.SelectedItem != null)
            {
                int index = tbl_TK_Chung.SelectedIndex;
                TK_P_CHUNG selected = chung[index];
                tbl_TK_Cuthe.ItemsSource = selected.Tk_hs;
            }
        }
    }
}
