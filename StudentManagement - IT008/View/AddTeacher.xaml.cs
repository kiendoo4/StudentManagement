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

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        List<string> gioitinhList = new List<string>
        {
            "Nam",
            "Nữ"
        };
        public AddTeacher()
        {
            InitializeComponent();
            LabelToShow.Text = "Thêm giáo viên";
            foreach (string gt in gioitinhList)
            {
                Gioitinh.Items.Add(new ComboBoxItem { Content = gt });
            }
            foreach (MONHOC mh in Entity.ins.MONHOCs)
            {
                Monday.Items.Add(mh.TENMH);
            }    
            Gioitinh.SelectedIndex = 0;
            Monday.SelectedIndex = 0;
        }
        public AddTeacher(TAIKHOAN fixTK)
        {
            InitializeComponent();
            LabelToShow.Text = "Chỉnh sửa giáo viên";
            Username.IsEnabled = false;
            foreach (string gt in gioitinhList)
            {
                Gioitinh.Items.Add(new ComboBoxItem { Content = gt });
            }
            foreach (MONHOC mh in Entity.ins.MONHOCs)
            {
                Monday.Items.Add(mh.TENMH);
            }
            Gioitinh.SelectedIndex = 0;
            Monday.SelectedIndex = 0;
            Hoten.Text = fixTK.HOTEN;
            Ngsinh.SelectedDate = DateTime.Parse(fixTK.NGSINHSHOW);
            Email.Text = fixTK.EMAIL;
            Dchi.Text = fixTK.DCHI;
            Username.Text = fixTK.USERNAME;
            Password.Text = fixTK.PASSWRD;
            Hocvi.Text = fixTK.HOCVI;
            if (fixTK.GIOITINHSHOW == "Nam")
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

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (LabelToShow.Text == "Thêm giáo viên")
            {
                TAIKHOAN gv = new TAIKHOAN
                {
                    HOTEN = Hoten.Text,
                    NGSINH = DateTime.Parse(Ngsinh.Text),
                    EMAIL = Email.Text,
                    DCHI = Dchi.Text,
                    ISDELETED = false,
                    GIOITINH = ((Gioitinh.Text == "Nam") ? true : false),
                    USERNAME = Username.Text,
                    PASSWRD = Password.Text,
                    VAITRO = "GV"
                };
                GIAOVIEN newgv = new GIAOVIEN
                {
                    MAGV = Magv.Text,
                    USERNAME = Username.Text,
                    HOCVI = Hocvi.Text
                };
                KHANANGGIANGDAY ab = Entity.ins.KHANANGGIANGDAYs.SingleOrDefault(c => c.MAMH == Monday.Text);
                newgv.KHANANGGIANGDAYs.Add(ab);
                gv.GIAOVIENs.Add(newgv);
                Entity.ins.TAIKHOANs.Add(gv);
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
