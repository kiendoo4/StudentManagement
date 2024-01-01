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

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for AddSubjects.xaml
    /// </summary>
    public partial class AddSubjects : UserControl
    {
        bool addorchange = true;
        ObservableCollection<MONHOC> monhocList2 = new ObservableCollection<MONHOC>();
        MONHOC monhoc2 = new MONHOC();
        TextBlock textBlock2 = new TextBlock();
        public AddSubjects(ObservableCollection<MONHOC> monhocList, TextBlock textBlock)
        {
            InitializeComponent();
            monhocList2 = monhocList;
            Mamh.IsEnabled = false;
            Mamh.Text = "MH" + Convert.ToString(Entity.ins.MONHOCs.Count() + 1);
            textBlock2 = textBlock;
        }
        public AddSubjects(ObservableCollection<MONHOC> monhocList, MONHOC mh, TextBlock textBlock)
        {
            InitializeComponent();
            monhocList2 = monhocList;
            monhoc2 = mh;
            Mamh.IsEnabled = false;
            addorchange = false;
            Mamh.Text = mh.MAMH;
            Tenmh.Text = mh.TENMH;
            textBlock2 = textBlock;
        }

        private void FinishClick(object sender, RoutedEventArgs e)
        {
            if(addorchange)
            {
                MONHOC newMh = new MONHOC();
                newMh.MAMH = Mamh.Text;
                newMh.TENMH = Tenmh.Text;
                newMh.ISDELETED = false;
                Entity.ins.MONHOCs.Add(newMh);
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã thêm môn học thành công!", "Thông báo");
                    monhocList2.Clear();
                    foreach (MONHOC mh in Entity.ins.MONHOCs.ToList())
                    {
                        if (mh.ISDELETED == false)
                            monhocList2.Add(mh);
                    }
                    this.Visibility = Visibility.Collapsed;
                    textBlock2.Text = "";
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
                monhoc2.TENMH = Tenmh.Text;
                try
                {
                    Entity.ins.SaveChanges();
                    MessageBox.Show("Đã chỉnh sửa môn học thành công!", "Thông báo");
                    monhocList2.Clear();
                    foreach (MONHOC mh in Entity.ins.MONHOCs.ToList())
                    {
                        if (mh.ISDELETED == false)
                            monhocList2.Add(mh);
                    }
                    this.Visibility = Visibility.Collapsed;
                    textBlock2.Text = "";

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
