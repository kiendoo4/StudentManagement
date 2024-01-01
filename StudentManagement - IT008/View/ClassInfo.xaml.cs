using CommunityToolkit.Mvvm.Input;
using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for ClassInfo.xaml
    /// </summary>
    public partial class ClassInfo : UserControl
    {
        public ClassInfo()
        {
            InitializeComponent();
            TeacherBox.Items.Clear();
            LabelToShow.Text = "Thêm lớp học";
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if(tk.ISDELETED == false && tk.VAITRO == "GV")
                    TeacherBox.Items.Add(tk.HOTEN);
            }
            TeacherBox.SelectedIndex = 0;
        }
        public ClassInfo(LOP info)
        {
            InitializeComponent();
            LabelToShow.Text = "Chỉnh sửa lớp học";
            KhoiBox.Text = Convert.ToString(info.KHOI);
            ClassBox.Text = info.TENLOP;
            TeacherBox.Text = info.TENGV;
            //NienKhoaBox.Text = info.NAMHOC;
            KhoiBox.IsEnabled = false;
            ClassBox.IsEnabled = false;
            TeacherBox.Items.Clear();
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    TeacherBox.Items.Add(tk.HOTEN);
            }
            int i = 0;
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN == info.TENGV)
                {
                    TeacherBox.SelectedIndex = i;
                    break;
                }
                else i++;
            }
        }
        string mal;
        private void FinishButtonClick(object sender, RoutedEventArgs e)
        {
            if(LabelToShow.Text == "Thêm lớp học")
            {
                LOP newL = new LOP();
                newL.MALOP = "L" + KhoiBox.Text + ClassBox.Text;
                newL.TENLOP = ClassBox.Text;
                foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
                {
                    if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN == TeacherBox.Text)
                    {
                        mal = tk.USERNAME;
                        break;
                    }
                }
                GIAOVIEN findGV  = new GIAOVIEN();
                findGV.ISDELETED = false;
                foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
                {
                    if (gv.ISDELETED == false && gv.USERNAME == mal)
                    {
                        findGV = gv;
                        break;
                    }
                }

                LOPHOCTHUCTE lhtt = new LOPHOCTHUCTE
                {
                    MALHTT = "LHTT" + Convert.ToString(Entity.ins.LOPHOCTHUCTEs.Count()),
                    MALOP = newL.MALOP,
                    MANH = "NH001",
                    MAGVCN = findGV.MAGV,
                    ISDELETED = false
                };
                newL.LOPHOCTHUCTEs.Add(lhtt);
                Entity.ins.LOPs.Add(newL);
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Thêm lớp học thành công", "Thông báo");
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
