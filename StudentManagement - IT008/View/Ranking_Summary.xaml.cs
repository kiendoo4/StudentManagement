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
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for Ranking_Summary.xaml
    /// </summary>
    public partial class Ranking_Summary : UserControl
    {
        string className;
        public Ranking_Summary(string className)
        {
            InitializeComponent();
            this.className = className;
            tb_HK.Text = className;
            LoadData();
        }

        ObservableCollection<KQNAMHOC> kq_chosen = new ObservableCollection<KQNAMHOC>();
        public void LoadData()
        {
            foreach (KQNAMHOC kq in Entity.ins.KQNAMHOCs.ToList())
            {
                HOCSINH hs = new HOCSINH();
                foreach (HOCSINH hs2 in Entity.ins.HOCSINHs)
                {
                    if (hs2.MAHS == kq.MAHS) { hs = hs2; break; }
                }
                LOPHOCTHUCTE lhtt = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lh in Entity.ins.LOPHOCTHUCTEs.ToList())
                {
                    if (lh.HOCSINHs.Contains(hs)) { lhtt = lh; break; }
                }
                if (lhtt != null)
                {
                    string temp = lhtt.MALOP;
                    if (temp == null) continue;
                    if (temp.Contains(className)) kq_chosen.Add(kq);
                }
            }
            Ranking.ItemsSource = kq_chosen;
        }

        private void LoadSelection(object sender, SelectionChangedEventArgs e)
        {
            if (Ranking.SelectedItem != null)
            {
                KQNAMHOC obj = kq_chosen[Ranking.SelectedIndex];
                ObservableCollection<DIEMTRUNGBINHMONHOCNAMHOC> kq_hs = new ObservableCollection<DIEMTRUNGBINHMONHOCNAMHOC>();
                foreach (DIEMTRUNGBINHMONHOCNAMHOC kq in Entity.ins.DIEMTRUNGBINHMONHOCNAMHOCs.ToList())
                {
                    if (kq.MAHS == obj.MAHS)
                    {
                        kq_hs.Add(kq);
                    }
                }
                RankCuThe.ItemsSource = kq_hs;
            }
        }
        private void btn_exportExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet tk_chung = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

            tk_chung.Name = "TK_Chung";
            tk_chung.Cells[1, 1] = "Báo cáo tổng kết xếp loại học sinh lớp " + className;
            tk_chung.Cells[2, 1] = "Thời gian xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Excel.Range headerrange = (Excel.Range)tk_chung.Cells[1, 1];
            headerrange.Font.Bold = true;

            for (int i = 1; i <= Ranking.Columns.Count; i++)
            {
                tk_chung.Cells[3, i] = Ranking.Columns[i - 1].Header;
            }

            for (int i = 0; i < kq_chosen.Count; i++)
            {
                tk_chung.Cells[i + 4, 1] = kq_chosen[i].STT;
                tk_chung.Cells[i + 4, 2] = kq_chosen[i].HOTEN;
                tk_chung.Cells[i + 4, 3] = kq_chosen[i].DTBNamHoc;
                tk_chung.Cells[i + 4, 4] = kq_chosen[i].HOCLUC.TenHocLuc;
                tk_chung.Cells[i + 4, 5] = kq_chosen[i].HANHKIEM.TenHanhKiem;
            }
            Excel.Range usedRange = tk_chung.UsedRange;
            usedRange.Columns.AutoFit();

            Excel.Worksheet tk_chitiet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

            tk_chitiet.Name = "TK_ChiTiet";
            tk_chitiet.Cells[1, 1] = "Báo cáo tổng kết xếp loại học sinh lớp " + className;
            tk_chitiet.Cells[2, 1] = "Thời gian xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            headerrange = (Excel.Range)tk_chitiet.Cells[1, 1];
            headerrange.Font.Bold = true;

            var selectedItems = Ranking.SelectedItems;
            int line = 5;
            foreach (var selectedItem in selectedItems)
            {
                int index = Ranking.Items.IndexOf(selectedItem);
                KQNAMHOC obj = kq_chosen[index];
                ObservableCollection<DIEMTRUNGBINHMONHOCNAMHOC> kq_hs = new ObservableCollection<DIEMTRUNGBINHMONHOCNAMHOC>();
                foreach (DIEMTRUNGBINHMONHOCNAMHOC kq in Entity.ins.DIEMTRUNGBINHMONHOCNAMHOCs.ToList())
                {
                    if (kq.MAHS == obj.MAHS)
                    {
                        kq_hs.Add(kq);
                    }
                }

                tk_chitiet.Cells[line, 1] = "Học sinh: " + obj.HOCSINH.HOTENHS + ", Mã HS: " + obj.MAHS;
                headerrange = (Excel.Range)tk_chitiet.Cells[line, 1];
                headerrange.Font.Bold = true;

                for (int i = 1; i <= RankCuThe.Columns.Count; i++)
                {
                    tk_chitiet.Cells[line + 1, i] = RankCuThe.Columns[i - 1].Header;
                }
                ObservableCollection<DIEMTRUNGBINHMONHOCNAMHOC> tk_hs = kq_hs;
                for (int i = 0; i < tk_hs.Count; i++)
                {
                    tk_chitiet.Cells[i + line + 2, 1] = tk_hs[i].tenMH;
                    tk_chitiet.Cells[i + line + 2, 2] = tk_hs[i].DTBMonHocNamHoc;
                }
                line += 5 + tk_hs.Count;
            }
            usedRange = tk_chitiet.UsedRange;
            usedRange.Columns.AutoFit();
        }
    }
}
