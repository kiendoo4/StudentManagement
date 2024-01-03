using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        ObservableCollection<MONHOC> monhocList = new ObservableCollection<MONHOC>();
        public Setting()
        {
            InitializeComponent();
            foreach (MONHOC mh in Entity.ins.MONHOCs.ToList())
            {
                if (mh.ISDELETED == false)
                    monhocList.Add(mh);
            }
            Data.ItemsSource = monhocList;
            List<THAMSO> thamsoList = Entity.ins.THAMSOes.ToList();
            for (int i = 0; i < Entity.ins.THAMSOes.Count(); i++)
            {
                if (i == 0) TTSHS.Text = thamsoList[i].GIATRI;
                if (i == 1) TTDHS.Text = thamsoList[i].GIATRI;
                if (i == 2) DSTT.Text = thamsoList[i].GIATRI;
                if (i == 3) DSTD.Text = thamsoList[i].GIATRI;
                if (i == 4) SSTD.Text = thamsoList[i].GIATRI;
                if (i == 5) DDTT.Text = thamsoList[i].GIATRI;
            }    
        }
        public Setting(bool role)
        {
            InitializeComponent();
            foreach (MONHOC mh in Entity.ins.MONHOCs.ToList())
            {
                if (mh.ISDELETED == false)
                    monhocList.Add(mh);
            }
            Data.ItemsSource = monhocList;
            List<THAMSO> thamsoList = Entity.ins.THAMSOes.ToList();
            for (int i = 0; i < Entity.ins.THAMSOes.Count(); i++)
            {
                if (i == 0) TTSHS.Text = thamsoList[i].GIATRI;
                if (i == 1) TTDHS.Text = thamsoList[i].GIATRI;
                if (i == 2) DSTT.Text = thamsoList[i].GIATRI;
                if (i == 3) DSTD.Text = thamsoList[i].GIATRI;
                if (i == 4) SSTD.Text = thamsoList[i].GIATRI;
                if (i == 5) DDTT.Text = thamsoList[i].GIATRI;
            }
            if(!role)
            {
                AddSubject.Visibility = Visibility.Hidden;
                DeleteSubject.Visibility = Visibility.Hidden;
                SaveInformation.Visibility = Visibility.Hidden;
                FixSubjectColumn.Visibility = Visibility.Hidden;
            }    
        }
        private void CheckAllMonhocsClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);

                    if (checkBox != null)
                    {
                        checkBox.IsChecked = true;
                    }
                }
            }
        }
        private void UncheckAllMonhocsClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);

                    if (checkBox != null)
                    {
                        checkBox.IsChecked = false;
                    }
                }
            }
        }
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);

                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
        private void AddSubjectButton(object sender, RoutedEventArgs e)
        {
            AddMonHocUC.Children.Clear();
            AddSubjects addSubjects = new AddSubjects(monhocList, AddorFixSubjects);
            AddMonHocUC.Children.Add(addSubjects);
            AddorFixSubjects.Text = "Thêm môn học";
        }
        private void ChangeTTMonhoc(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MONHOC dataItem = (MONHOC)button.DataContext;
            AddMonHocUC.Children.Clear();
            AddSubjects addSubjects = new AddSubjects(monhocList, dataItem, AddorFixSubjects);
            AddMonHocUC.Children.Add(addSubjects);
            AddorFixSubjects.Text = "Chỉnh sửa môn học";
        }
        private void DeleteSubjectButton(object sender, RoutedEventArgs e)
        {
            List<MONHOC> itemsToRemove = new List<MONHOC>();
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        MONHOC dmh = item as MONHOC;
                        dmh.ISDELETED = true;
                        itemsToRemove.Add(dmh);
                    }
                }
            }
            foreach (MONHOC itemToRemove in itemsToRemove)
            {
                monhocList.Remove(itemToRemove);
            }
            Entity.ins.SaveChanges();
            Data.ItemsSource = null;
            Data.ItemsSource = monhocList;
            MessageBox.Show("Đã xóa môn học thành công!", "Thông báo");
        }
        private void SaveInfo(object sender, RoutedEventArgs e)
        {
            if (ValidateThamSo())
            {
                List<THAMSO> thamsoList = Entity.ins.THAMSOes.ToList();
                for (int i = 0; i < Entity.ins.THAMSOes.Count(); i++)
                {
                    if (i == 0) thamsoList[i].GIATRI = TTSHS.Text;
                    if (i == 1) thamsoList[i].GIATRI = TTDHS.Text;
                    if (i == 2) thamsoList[i].GIATRI = DSTT.Text;
                    if (i == 3) thamsoList[i].GIATRI = DSTD.Text;
                    if (i == 4) thamsoList[i].GIATRI = SSTD.Text;
                    if (i == 5) thamsoList[i].GIATRI = DDTT.Text;
                }
                Entity.ins.SaveChanges();
                MessageBox.Show("Lưu tham số thành công!", "Thông báo");
            }
        }
        private bool IsNumeric(string input)
        {
            Regex regex = new Regex(@"^[0-9]\d*(\.\d+)?$");
            return regex.IsMatch(input);
        }
        private bool IsNumber(string input)
        {
            Regex regex = new Regex(@"^[0-9]\d*$");
            return regex.IsMatch(input);
        }
        private bool ValidateThamSo()
        {
            if(TTSHS.Text == "")
            {
                MessageBox.Show("Tuổi tối thiểu học sinh không được trống!");
                return false;
            } else
            {
                if (!IsNumber(TTSHS.Text))
                {
                    MessageBox.Show("Định dạng của tuổi tối thiểu không đúng!");
                    return false;
                }
            }
            if (TTDHS.Text == "")
            {
                MessageBox.Show("Tuổi tối đa học sinh không được trống!");
                return false;
            } else
            {
                if (!IsNumber(TTDHS.Text))
                {
                    MessageBox.Show("Định dạng của tuổi tối đa không đúng!");
                    return false;
                }
            }
            if (DSTT.Text == "")
            {
                MessageBox.Show("Điểm số tối thiểu không được trống!");
                return false;
            } else
            {
                if (!IsNumeric(DSTT.Text))
                {
                    MessageBox.Show("Định dạng của điểm số tối thiểu không đúng!");
                    return false;
                }
            }
            if (DSTD.Text == "")
            {
                MessageBox.Show("Điểm số tối đa không được trống!");
                return false;
            } else
            {
                if (!IsNumeric(DSTD.Text))
                {
                    MessageBox.Show("Định dạng của điểm số tối đa không đúng!");
                    return false;
                }
            } 
            if (SSTD.Text == "")
            {
                MessageBox.Show("Sĩ số lớp tối đa không được trống!");
                return false;
            } else
            {
                if (!IsNumber(SSTD.Text))
                {
                    MessageBox.Show("Định dạng của sĩ số lớp tối đa không đúng!");
                    return false;
                }
            }
            if (DDTT.Text == "")
            {
                MessageBox.Show("Điểm đạt tối thiểu không được trống!");
                return false;
            } else
            {
                if (!IsNumeric(DDTT.Text))
                {
                    MessageBox.Show("Định dạng của điểm đạt tối thiểu không đúng!");
                    return false;
                }
            }
            double dstt = double.Parse(DSTT.Text);
            double dstd = double.Parse(DSTD.Text);
            double ddtt = double.Parse(DDTT.Text);
            if (dstt > dstd)
            {
                MessageBox.Show("Điểm số tối thiểu không được lớn hơn điểm số tối đa!");
                return false;
            }
            if (ddtt < dstt)
            {
                MessageBox.Show("Điểm đạt tối thiểu không được nhỏ hơn điếm số tối thiểu!");
                return false;
            }
            if (ddtt > dstd)
            {
                MessageBox.Show("Điểm đạt tối thiểu không được lớn hơn điểm số tối đa!");
                return false;
            }
            int ttshs = int.Parse(TTSHS.Text);
            int ttdhs = int.Parse(TTDHS.Text);
            if (ttdhs < ttshs)
            {
                MessageBox.Show("Tuổi tối thiểu học sinh không được lớn hơn tuổi tối đa học sinh!");
                return false;
            }
            return true;
        }
    }
}
