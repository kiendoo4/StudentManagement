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
    public partial class Summarize_Subject : UserControl
    {
        private string year;
        private string subject;
        private List<TK_P_CHUNG> chung;
        public Summarize_Subject(string year, string subject)
        {
            this.year = year;
            this.subject = subject;
            InitializeComponent();
            changeText();
            tbl_TK_Chung.Items.Clear();
            chung = GetTKChung();
            tbl_TK_Chung.ItemsSource = chung;
        }
        public void changeText()
        {
            tb_Period_2.Text = tb_Subject_Chung.Text = year + " - Môn: " + subject;
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
        private List<TK_P_CHUNG> GetTKChung()
        {
            List<TK_P_CHUNG> ls = new List<TK_P_CHUNG>();
            int stt = 1;
            string mamh = Entity.ins.MONHOCs.SingleOrDefault(lda => lda.TENMH == subject).MAMH;
            foreach (LOP l in Entity.ins.LOPs)
            {
                TK_P_CHUNG tk_lop = new TK_P_CHUNG();
                string malop = l.MALOP;
                string tenlop = l.KHOI + l.TENLOP;
                LOPHOCTHUCTE lhtt = l.LOPHOCTHUCTEs.SingleOrDefault(lda => lda.MALOP == malop);
                int siso = lhtt.HOCSINHs.Count();
                int soluongdat = 0;
                int stt_2 = 1;
                List<double> dtblist = new List<double>();
                foreach (HOCSINH hs in lhtt.HOCSINHs)
                {
                    bool check = true;
                    TK_P_CHITIET tk_hs = new TK_P_CHITIET();
                    double dtb = 0;
                    if (year == "Cả năm")
                    {
                        int count = 0;
                        foreach (KQHOCKYMONHOC kqhk in Entity.ins.KQHOCKYMONHOCs)
                        {
                            if (count == 2) break;
                            if (kqhk.MAMH == mamh && kqhk.MAHS == hs.MAHS)
                            {
                                count++;
                                dtb += (double)kqhk.DTBMonHocKy;
                            }
                        }
                        dtb /= 2;
                    }
                    else
                    {
                        KQHOCKYMONHOC kq;
                        if (year == "Học kỳ I") kq = Entity.ins.KQHOCKYMONHOCs.SingleOrDefault(lda => lda.MAHS == hs.MAHS && lda.MAMH == mamh && lda.MAHK == "HK001");
                        else kq = Entity.ins.KQHOCKYMONHOCs.SingleOrDefault(lda => lda.MAHS == hs.MAHS && lda.MAMH == mamh && lda.MAHK == "HK002");

                        dtb = (double)kq.DTBMonHocKy;
                    }
                    dtblist.Add(dtb);
                    if (dtb < Double.Parse(Entity.ins.THAMSOes.SingleOrDefault(lda => lda.ID == "TS006").GIATRI))
                    {
                        check = false;
                    }
                    if (check) soluongdat++;
                    tk_hs = new TK_P_CHITIET { STT = stt_2, Hoten = hs.HOTENHS, Lop = tenlop, DiemTB = dtb.ToString("0.00"), Dat = check, Hang = 1 };
                    tk_lop.Tk_hs.Add(tk_hs);
                    stt_2++;
                }
                var sortedlist = dtblist.Select((value, index) => new { Value = value, OriginalIndex = index })
                                  .OrderByDescending(pair => pair.Value)
                                  .Select((pair, sortedIndex) => new { pair.Value, pair.OriginalIndex, SortedIndex = sortedIndex })
                                  .ToList();
                List<int> ranklist = sortedlist.OrderBy(pair => pair.OriginalIndex).Select(pair => pair.SortedIndex).ToList();
                for (int i = 0; i < ranklist.Count; i++)
                {
                    tk_lop.Tk_hs[i].Hang = ranklist[i] + 1;
                }
                tk_lop.STT = stt;
                tk_lop.Lop = tenlop;
                tk_lop.SiSo = siso;
                tk_lop.SL_Dat = soluongdat;
                tk_lop.TiLe = ((float)soluongdat / siso * 100).ToString("0") + "%";
                ls.Add(tk_lop);
                stt++;
            }
            return ls;
        }
    }
}
