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
using System.Data.SqlClient;
using StudentManagement___IT008.Model;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddClass.xaml
    /// </summary>
    public partial class AddClass : UserControl
    {
        public event EventHandler DoneClick;
        public AddClass()
        {
            InitializeComponent();
            foreach(GIAOVIEN gv in Entity.ins.GIAOVIENs)
            {
                ChooseTeacher.Items.Add(new ComboBoxItem { Content = gv.MAGV });
            }
            foreach (NAMHOC nh in Entity.ins.NAMHOCs)
            {
                NienKhoa.Items.Add(new ComboBoxItem { Content = nh.TENNAMHOC });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string check = ("L" + ChooseGrade.Text + ClassName.Text);
            int flag = 0;
            foreach (LOP lopCheck in Entity.ins.LOPs)
            {
                if (lopCheck.MALOP == check)
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                LOP lop = new LOP()
                {
                    MALOP = ("L" + ChooseGrade.Text + ClassName.Text),
                    KHOI = Convert.ToInt32(ChooseGrade.Text),
                    TENLOP = ClassName.Text,
                    ISDELETED = false
                };
                Entity.ins.LOPs.Add(lop);
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã thêm lớp học thành công!", "Thông báo");
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
            string maNamHoc = "";
            foreach(NAMHOC nh in Entity.ins.NAMHOCs)
            {
                if (nh.TENNAMHOC == NienKhoa.Text)
                {
                    maNamHoc = nh.MANH; break;
                }
            }
            LOPHOCTHUCTE loptt = new LOPHOCTHUCTE()
            {
                MALHTT = "LHTT" + (Entity.ins.LOPHOCTHUCTEs.Count() + 1).ToString("D3"),
                MALOP = check,
                MANH = maNamHoc,
                MAGVCN = ChooseTeacher.Text,
                ISDELETED = false
            };
            Entity.ins.LOPHOCTHUCTEs.Add(loptt);
            try
            {
                Entity.ins.SaveChanges();
                MessageBox.Show("Đã thêm lớp học thực tế thành công!", "Thông báo");
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
            DoneClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
