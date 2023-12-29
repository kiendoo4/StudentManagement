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
using System.Windows.Shapes;
using Xamarin.Forms.PlatformConfiguration;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        List<string> danTocList = new List<string>
            {
                "Kinh",
                "Tày",
                "Thái",
                "Mường",
                "Mông",
                "Dao",
                "Nùng",
                "H'Mông",
                "Gia Rai",
                "Ngái",
                "Ê Đê",
                "Ba Na",
                "Xơ Đăng",
                "Chăm",
                "Cơ Ho",
                "Ra Glai",
                "Co Tu",
                "Ta Oi",
                "Bru-Vân Kiều",
                "Giáy",
                "Lao",
                "Chu Ru",
                "Lự",
                "Lô Lô",
                "Mạ",
                "Pu Péo",
                "Xinh Mun",
                "Konkơlor",
                "Kháng",
                "Chứt",
                "La Chi",
                "La Ha",
                "La Hu",
                "La Li",
                "Pu Xe",
                "Ro Mam",
                "Chơ Ro",
                "La Vân",
                "K'Ho",
                "Cơ Lao",
                "Bố Y",
                "La Chi",
                "Lự",
                "Lô Lô",
                "M'nông",
                "Brâu",
                "Ơ Đu",
                "Xinh Mun",
                "Giẻ Triêng",
                "Cơ Tu",
                "Gie-Trieng",
                "Ta Oi",
                "Chơ Ro",
                "Sán Dìu",
                "Chứt",
                "Mạ",
                "Thổ"
            };
        List<string> tonGiaoList = new List<string>
            {
                "Không",
                "Phật giáo",
                "Thiên Chúa giáo",
                "Hồi giáo",
                "Cao Đài",
                "Tin lành",
                "Hòa Hảo",
                "Công giáo",
                "Khác"
        };
        List<string> gioitinhList = new List<string>
        {
            "Nam",
            "Nữ"
        };
        public AddStudent()
        {
            InitializeComponent();
            LabelToShow.Text = "Thêm học sinh";
            Mahs.Text = "HS" + Convert.ToString(Entity.ins.HOCSINHs.ToList().Count + 1);
            Mahs.IsEnabled = false;
            foreach (string danToc in danTocList)
            {
                Dantoc.Items.Add(new ComboBoxItem { Content = danToc });
            }
            foreach (string tonGiao in tonGiaoList)
            {
                Tongiao.Items.Add(new ComboBoxItem { Content = tonGiao });
            }
            foreach (string gt in gioitinhList)
            {
                Gioitinh.Items.Add(new ComboBoxItem { Content = gt });
            }
            Dantoc.SelectedIndex = 0;
            Tongiao.SelectedIndex = 0;
            Gioitinh.SelectedIndex = 0;
        }
        HOCSINH fixHS = new HOCSINH();
        public AddStudent(HOCSINH hocsinh)
        {
            fixHS = hocsinh;
            InitializeComponent();
            LabelToShow.Text = "Chỉnh sửa học sinh";
            CMND.Text = hocsinh.CCCD;
            Hoten.Text = hocsinh.HOTENHS;
            Ngsinh.SelectedDate = DateTime.Parse(hocsinh.NGSINHSHOW);
            Email.Text = hocsinh.EMAIL;
            Dchi.Text = hocsinh.DCHI;
            Lop.Text = hocsinh.LOP;
            Mahs.Text = hocsinh.MAHS;
            Mahs.IsEnabled = false;
            Sdt.Text = hocsinh.SDT;
            
            int i = 0, j = 0;
            foreach (string danToc in danTocList)
            {
                Dantoc.Items.Add(new ComboBoxItem { Content = danToc });
            }
            foreach (string tonGiao in tonGiaoList)
            {
                Tongiao.Items.Add(new ComboBoxItem { Content = tonGiao });
            }
            foreach (string gt in gioitinhList)
            {
                Gioitinh.Items.Add(new ComboBoxItem { Content = gt });
            }
            foreach (string danToc in danTocList)
            {
                if (danToc == hocsinh.DANTOC)
                {
                    Dantoc.SelectedIndex = i;
                    break;
                }
                else i++;
            }
            foreach (string tonGiao in tonGiaoList)
            {
                if (tonGiao == hocsinh.TONGIAO)
                {
                    Tongiao.SelectedIndex = j;
                    break;
                }
                else j++;
            }
            if (hocsinh.GIOITINHSHOW == "Nam")
                Gioitinh.SelectedIndex = 0;
            else
            {
                Gioitinh.SelectedIndex = 1;
            }    
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void FinishButon_Click(object sender, RoutedEventArgs e)
        {
            if (LabelToShow.Text == "Thêm học sinh")
            {
                HOCSINH hocsinh = new HOCSINH
                {
                    CCCD = CMND.Text,
                    HOTENHS = Hoten.Text,
                    NGSINH = DateTime.Parse(Ngsinh.Text),
                    EMAIL = Email.Text,
                    DCHI = Dchi.Text,
                    DANTOC = Dantoc.Text,
                    TONGIAO = Tongiao.Text,
                    MAHS = Mahs.Text,
                    ISDELETED = false,
                    SDT = Sdt.Text,
                    GIOITINH = ((Gioitinh.Text == "Nam") ? true : false)
                };
                LOPHOCTHUCTE existingLopHoc = Entity.ins.LOPHOCTHUCTEs.SingleOrDefault(lop => lop.MALOP == Lop.Text);
                hocsinh.LOPHOCTHUCTEs.Add(existingLopHoc);
                Entity.ins.HOCSINHs.Add(hocsinh);
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã thêm học sinh thành công!", "Thông báo");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
            else
            {
                fixHS.CCCD = CMND.Text;
                fixHS.HOTENHS = Hoten.Text;
                fixHS.NGSINH = DateTime.Parse(Ngsinh.Text);
                fixHS.EMAIL = Email.Text;
                fixHS.DCHI = Dchi.Text;
                fixHS.DANTOC = Dantoc.Text;
                fixHS.TONGIAO = Tongiao.Text;
                fixHS.SDT = Sdt.Text;
                LOPHOCTHUCTE newLopHoc = Entity.ins.LOPHOCTHUCTEs.SingleOrDefault(lop => lop.MALOP == Lop.Text);
                fixHS.LOPHOCTHUCTEs.Clear();
                fixHS.LOPHOCTHUCTEs.Add(newLopHoc);
                Entity.ins.SaveChanges();
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã chỉnh sửa học sinh thành công!", "Thông báo");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }    
        }
        
    }
}
