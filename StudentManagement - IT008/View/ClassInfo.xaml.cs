using CommunityToolkit.Mvvm.Input;
using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
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
        ObservableCollection<LOP> lophocList2 = new ObservableCollection<LOP>();
        LOP info2 = new LOP();
        public ClassInfo(ObservableCollection<LOP> lophocList)
        {
            InitializeComponent();
            KhoiBox.SelectedIndex = 0;
            lophocList2 = lophocList;
            TeacherBox.Items.Clear();
            LabelToShow.Text = "Thêm lớp học";
            TeacherBox.Items.Add("");
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    TeacherBox.Items.Add(tk.GIAOVIENs.SingleOrDefault(lda => lda.USERNAME == tk.USERNAME).MAGV + "-" + tk.HOTEN);
            }
            TeacherBox.SelectedIndex = 0;
        }
        public ClassInfo(LOP info, ObservableCollection<LOP> lophocList)
        {
            InitializeComponent();
            KhoiBox.SelectedIndex = 0;
            lophocList2 = lophocList;
            info2 = info;
            LabelToShow.Text = "Chỉnh sửa lớp học";
            KhoiBox.Text = Convert.ToString(info.KHOI);
            ClassBox.Text = info.TENLOP;
            TeacherBox.Text = info.TENGV;
            //NienKhoaBox.Text = info.NAMHOC;
            KhoiBox.IsEnabled = false;
            ClassBox.IsEnabled = false;
            TeacherBox.Items.Clear();
            TeacherBox.Items.Add("");
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    TeacherBox.Items.Add(tk.GIAOVIENs.SingleOrDefault(lda => lda.USERNAME == tk.USERNAME).MAGV + "-" + tk.HOTEN);
            }
            int i = 0;
            foreach (string item in TeacherBox.Items)
            {
                if (item == "")
                {
                    if (info.TENGV == "")
                    {
                        TeacherBox.SelectedIndex = i;
                        break;
                    }
                    else
                    {
                        i++;
                        continue;
                    }
                }
                if (item.Split('-')[1] == info.TENGV)
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
            string hotengv="";
            if (TeacherBox.Text!="") hotengv = TeacherBox.Text.Split('-')[1];
            if (ValidateLop(LabelToShow.Text))
            {
                if (LabelToShow.Text == "Thêm lớp học")
                {
                    LOP newL = new LOP();
                    newL.MALOP = "L" + KhoiBox.Text + ClassBox.Text;
                    LOP existingLop = Entity.ins.LOPs.FirstOrDefault(l => l.MALOP == newL.MALOP && l.ISDELETED == true);
                    if (existingLop != null)
                    {
                        existingLop.ISDELETED = false;
                        GIAOVIEN findGV2 = new GIAOVIEN();
                        findGV2.ISDELETED = false;
                        foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
                        {
                            if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN == hotengv)
                            {
                                mal = tk.USERNAME;
                                break;
                            }
                        }
                        foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
                        {
                            if (gv.ISDELETED == false && gv.USERNAME == mal)
                            {
                                findGV2 = gv;
                                break;
                            }
                        }
                        LOPHOCTHUCTE lhtt2 = new LOPHOCTHUCTE
                        {
                            MALHTT = "LHTT" + Convert.ToString(Entity.ins.LOPHOCTHUCTEs.Count()),
                            MALOP = existingLop.MALOP,
                            MANH = "N2023",
                            MAGVCN = findGV2.MAGV,
                            ISDELETED = false
                        };
                        existingLop.LOPHOCTHUCTEs.Clear();
                        existingLop.LOPHOCTHUCTEs.Add(lhtt2);
                        try
                        {
                            Entity.ins.SaveChanges();
                            MessageBox.Show("Thêm lớp học thành công", "Thông báo");
                            lophocList2.Clear();
                            foreach (LOP lop in Entity.ins.LOPs)
                            {
                                if (lop.ISDELETED == false)
                                {
                                    lophocList2.Add(lop);
                                }
                            }
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
                        newL.TENLOP = ClassBox.Text;
                        newL.ISDELETED = false;
                        newL.KHOI = Convert.ToInt32(KhoiBox.Text);
                        foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
                        {
                            if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN == hotengv)
                            {
                                mal = tk.USERNAME;
                                break;
                            }
                        }
                        GIAOVIEN findGV = new GIAOVIEN();
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
                            MANH = "N2023",
                            MAGVCN = findGV.MAGV,
                            ISDELETED = false
                        };
                        newL.LOPHOCTHUCTEs.Add(lhtt);
                        lophocList2.Add(newL);
                        Entity.ins.LOPs.Add(newL);
                        try
                        {
                            Entity.ins.SaveChanges();
                            MessageBox.Show("Thêm lớp học thành công", "Thông báo");
                            lophocList2.Clear();
                            foreach (LOP lop in Entity.ins.LOPs)
                            {
                                if (lop.ISDELETED == false)
                                {
                                    lophocList2.Add(lop);
                                }
                            }
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
                else
                {
                    GIAOVIEN findGV2 = new GIAOVIEN();
                    foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
                    {
                        if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN == hotengv)
                        {
                            mal = tk.USERNAME;
                            break;
                        }
                    }
                    foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
                    {
                        if (gv.ISDELETED == false && gv.USERNAME == mal)
                        {
                            findGV2 = gv;
                            break;
                        }
                    }
                    LOPHOCTHUCTE lhtt2 = new LOPHOCTHUCTE
                    {
                        MALHTT = "LHTT" + Convert.ToString(Entity.ins.LOPHOCTHUCTEs.Count()),
                        MALOP = info2.MALOP,
                        MANH = "N2023",
                        MAGVCN = findGV2.MAGV,
                        ISDELETED = false
                    };
                    info2.LOPHOCTHUCTEs.Clear();
                    info2.LOPHOCTHUCTEs.Add(lhtt2);
                    try
                    {
                        Entity.ins.SaveChanges();
                        MessageBox.Show("Chỉnh sửa lớp học thành công", "Thông báo");
                        lophocList2.Clear();
                        foreach (LOP lop in Entity.ins.LOPs)
                        {
                            if (lop.ISDELETED == false)
                            {
                                lophocList2.Add(lop);
                            }
                        }
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
        private bool ValidateLop(string type)
        {
            if(KhoiBox.Text == "")
            {
                MessageBox.Show("Khối không được để trống!");
                return false;
            }
            if(ClassBox.Text == "")
            {
                MessageBox.Show("Lớp không được để trống!");
                return false;
            } else
            {
                Regex regex = new Regex(@"^A\d{1,2}$");
                if (!regex.IsMatch(ClassBox.Text))
                {
                    MessageBox.Show("Sai định dạng tên lớp");
                    return false;
                }
            }
            if (type == "Thêm lớp học")
            {
                string malop = "L" + KhoiBox.Text + ClassBox.Text;
                if (Entity.ins.LOPHOCTHUCTEs.SingleOrDefault(lda => lda.MALOP == malop && lda.LOP.ISDELETED == false) != null)
                {
                    MessageBox.Show("Mã lớp đã tồn tại, vui lòng nhập lớp khác!");
                    return false;
                }
            }
            if (TeacherBox.Text != "")
            {
                string s = TeacherBox.Text.Split('-')[0];
                if (Entity.ins.LOPHOCTHUCTEs.FirstOrDefault(lda => lda.MAGVCN == s && lda.MALOP != null && lda.LOP.ISDELETED == false) != null)
                {
                    MessageBox.Show("Giáo viên này đã được phân vào một lớp khác, vui lòng chọn lại!");
                    return false;
                }
            }
            /*if (Entity.ins.LOPHOCTHUCTEs.SingleOrDefault(lda => lda.MAGVCN == s && lda.MALOP != null) != null)
            {
                
            }*/
            return true;
        }
    }
}
