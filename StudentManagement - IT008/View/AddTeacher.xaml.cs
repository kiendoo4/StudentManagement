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
            Magv.Text = "GV" + Convert.ToString(Entity.ins.GIAOVIENs.Count() + 1);
            Magv.IsEnabled = false;
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
        TAIKHOAN fixTK = new TAIKHOAN();
        public AddTeacher(TAIKHOAN TK)
        {
            InitializeComponent();
            fixTK = TK;
            LabelToShow.Text = "Chỉnh sửa giáo viên";
            Username.IsEnabled = false;
            int j = 0;
            foreach (string gt in gioitinhList)
            {
                Gioitinh.Items.Add(new ComboBoxItem { Content = gt });
            }
            foreach (MONHOC mh in Entity.ins.MONHOCs)
            {
                Monday.Items.Add(mh.TENMH);
            }
            if (fixTK.GIOITINHSHOW == "Nam")
                Gioitinh.SelectedIndex = 0;
            else
            {
                Gioitinh.SelectedIndex = 1;
            }
            GIAOVIEN existinggv2 = Entity.ins.GIAOVIENs.SingleOrDefault(gv => gv.USERNAME == TK.USERNAME);
            KHANANGGIANGDAY existingKN = existinggv2.KHANANGGIANGDAYs.SingleOrDefault(kn => kn.MAGV == existinggv2.MAGV && kn.ISDELETED == false);
            foreach (MONHOC mh in Entity.ins.MONHOCs)
            {
                if (mh.TENMH == existingKN.MONHOC.TENMH)
                {
                    Monday.SelectedIndex = j;
                    break;
                }
                else j++;
            }
            Gioitinh.SelectedIndex = 0;
            Hoten.Text = fixTK.HOTEN;
            Ngsinh.SelectedDate = DateTime.Parse(fixTK.NGSINHSHOW);
            Email.Text = fixTK.EMAIL;
            Dchi.Text = fixTK.DCHI;
            Username.Text = fixTK.USERNAME;
            Password.Text = fixTK.PASSWRD;
            Hocvi.Text = fixTK.HOCVI;
            foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
            {
                if (gv.USERNAME == fixTK.USERNAME)
                {
                    Magv.Text = gv.MAGV;
                    break;
                }
            }
            Magv.IsEnabled = false;
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
                KHANANGGIANGDAY newknnd = new KHANANGGIANGDAY();
                foreach (MONHOC mh in Entity.ins.MONHOCs)
                {
                    if (mh.TENMH == Monday.Text)
                    {
                        newknnd.MAMH = mh.MAMH;
                        newknnd.MONHOC = mh;
                        newknnd.MAGV = newgv.MAGV;
                        newknnd.GIAOVIEN = newgv;
                        newknnd.ISDELETED = false;
                        newgv.KHANANGGIANGDAYs.Add(newknnd);
                        break;
                    }
                }
                gv.GIAOVIENs.Add(newgv);
                Entity.ins.TAIKHOANs.Add(gv);
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã thêm giáo viên thành công!", "Thông báo");
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
                fixTK.HOTEN = Hoten.Text;
                fixTK.NGSINH = DateTime.Parse(Ngsinh.Text);
                fixTK.VAITRO = "GV";
                fixTK.USERNAME = Username.Text;
                fixTK.PASSWRD = Password.Text;
                fixTK.DCHI = Dchi.Text;
                fixTK.EMAIL = Email.Text;
                fixTK.GIOITINH = ((Gioitinh.Text == "Nam") ? true : false);               
                GIAOVIEN existinggv = Entity.ins.GIAOVIENs.SingleOrDefault(gv => gv.USERNAME == Username.Text);
                existinggv.HOCVI = Hocvi.Text;
                KHANANGGIANGDAY existingkn = existinggv.KHANANGGIANGDAYs.SingleOrDefault(gv => gv.MAGV == Magv.Text);
                existinggv.KHANANGGIANGDAYs.Remove(existingkn);
                KHANANGGIANGDAY newknnd = new KHANANGGIANGDAY();
                foreach (MONHOC mh in Entity.ins.MONHOCs)
                {
                    if (mh.TENMH == Monday.Text)
                    {
                        newknnd.MAMH = mh.MAMH;
                        newknnd.MONHOC = mh;
                        newknnd.MAGV = existinggv.MAGV;
                        newknnd.GIAOVIEN = existinggv;
                        newknnd.ISDELETED = false;
                        existinggv.KHANANGGIANGDAYs.Add(newknnd);
                        break;
                    }
                }
                
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã chỉnh sửa giáo viên thành công!", "Thông báo");
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
