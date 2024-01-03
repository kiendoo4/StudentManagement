using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
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
using Excel = Microsoft.Office.Interop.Excel;

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
                if (l.ISDELETED == true) continue;
                TK_P_CHUNG tk_lop = new TK_P_CHUNG();
                string malop = l.MALOP;
                string tenlop = l.KHOI + l.TENLOP;
                LOPHOCTHUCTE lhtt = l.LOPHOCTHUCTEs.SingleOrDefault(lda => lda.MALOP == malop);
                int siso = 0;
                int soluongdat = 0;
                int stt_2 = 1;
                List<double> dtblist = new List<double>();
                foreach (HOCSINH hs in lhtt.HOCSINHs)
                {
                    if (hs.ISDELETED == true) continue;
                    siso++;
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
                    dtblist.Add(dtb);
                    if (dtb < Double.Parse(Entity.ins.THAMSOes.SingleOrDefault(lda => lda.ID == "TS006").GIATRI))
                    {
                        check = false;
                    }
                    if (check) soluongdat++;
                    tk_hs = new TK_P_CHITIET { STT=stt_2, Hoten=hs.HOTENHS, Lop=tenlop, DiemTB=dtb.ToString("0.00"), Dat = check, Hang = 1};
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
                    tk_lop.Tk_hs[i].Hang = ranklist[i]+1;
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

        private void btn_exportExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet tk_chung = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

            tk_chung.Name = "TK_Chung";
            tk_chung.Cells[1, 1] = "Báo cáo tổng kết chung cho " + year;
            tk_chung.Cells[2, 1] = "Thời gian xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Excel.Range headerrange = (Excel.Range)tk_chung.Cells[1, 1];
            headerrange.Font.Bold = true;

            for (int i = 1; i <= tbl_TK_Chung.Columns.Count; i++)
            {
                tk_chung.Cells[3, i] = tbl_TK_Chung.Columns[i - 1].Header;
            }

            for (int i = 0; i < chung.Count; i++)
            {
                tk_chung.Cells[i + 4, 1] = chung[i].STT;
                tk_chung.Cells[i + 4, 2] = chung[i].Lop;
                tk_chung.Cells[i + 4, 3] = chung[i].SiSo;
                tk_chung.Cells[i + 4, 4] = chung[i].SL_Dat;
                tk_chung.Cells[i + 4, 5] = chung[i].TiLe;
            }

            Excel.Range usedRange = tk_chung.UsedRange;
            usedRange.Columns.AutoFit();

            Excel.Worksheet tk_chitiet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

            tk_chitiet.Name = "TK_ChiTiet";
            tk_chitiet.Cells[1, 1] = "Báo cáo tổng kết chi tiết cho " + year;
            tk_chitiet.Cells[2, 1] = "Thời gian xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            headerrange = (Excel.Range)tk_chitiet.Cells[1, 1];
            headerrange.Font.Bold = true;

            var selectedItems = tbl_TK_Chung.SelectedItems;
            int line = 5;
            foreach (var selectedItem in selectedItems)
            {
                int index = tbl_TK_Chung.Items.IndexOf(selectedItem);
                

                tk_chitiet.Cells[line, 1] = "Lớp: " + chung[index].Lop;
                headerrange = (Excel.Range)tk_chitiet.Cells[line, 1];
                headerrange.Font.Bold = true;

                for (int i = 1; i <= tbl_TK_Cuthe.Columns.Count; i++)
                {
                    tk_chitiet.Cells[line+1, i] = tbl_TK_Cuthe.Columns[i - 1].Header;
                }
                List<TK_P_CHITIET> tk_hs = chung[index].Tk_hs;
                for (int i = 0; i < tk_hs.Count; i++)
                {
                    tk_chitiet.Cells[i + line + 2, 1] = tk_hs[i].STT;
                    tk_chitiet.Cells[i + line + 2, 2] = tk_hs[i].Hoten;
                    tk_chitiet.Cells[i + line + 2, 3] = tk_hs[i].Lop;
                    tk_chitiet.Cells[i + line + 2, 4] = tk_hs[i].DiemTB;
                    tk_chitiet.Cells[i + line + 2, 5] = (tk_hs[i].Dat) ? 1 : 0;
                    tk_chitiet.Cells[i + line + 2, 6] = tk_hs[i].Hang;
                }
                line += 5 + tk_hs.Count;
            }

            usedRange = tk_chitiet.UsedRange;
            usedRange.Columns.AutoFit();
        }
    }
}
