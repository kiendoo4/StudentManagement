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
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class TeachersList : UserControl
    {
        ObservableCollection<TAIKHOAN> taikhoanList = new ObservableCollection<TAIKHOAN>();
        public TeachersList()
        {
            InitializeComponent();
            FindTK.SelectedIndex = 0;
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs.ToList())
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    taikhoanList.Add(tk);
            }
            Data.ItemsSource = taikhoanList;
        }

        private void AddTeacherButton(object sender, RoutedEventArgs e)
        {
            AddTeacher addTeacher = new AddTeacher();
            addTeacher.ShowDialog();
            taikhoanList = new ObservableCollection<TAIKHOAN>();
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs.ToList())
            {
                if (tk.ISDELETED == false && tk.VAITRO == "GV")
                    taikhoanList.Add(tk);
            }
            Data.ItemsSource = taikhoanList;
        }
        private void CheckTeacherClick(object sender, RoutedEventArgs e)
        {

        }
        private void CheckAllTeachersClick(object sender, RoutedEventArgs e)
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
        private void UncheckAllTeachersClick(object sender, RoutedEventArgs e)
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
        private void ChangeTTGiaoVien(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            TAIKHOAN dataItem = (TAIKHOAN)button.DataContext;
            AddTeacher changeTTStudent = new AddTeacher(dataItem);
            changeTTStudent.ShowDialog();
            Data.ItemsSource = null;
            Data.ItemsSource = taikhoanList;
        }
        private void DeleteTeacherClick(object sender, RoutedEventArgs e)
        {
            List<TAIKHOAN> itemsToRemove = new List<TAIKHOAN>();
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        TAIKHOAN tk = item as TAIKHOAN;
                        tk.ISDELETED = true;
                        itemsToRemove.Add(tk);
                    }
                }
            }
            foreach (TAIKHOAN itemToRemove in itemsToRemove)
            {
                taikhoanList.Remove(itemToRemove);
            }
            Entity.ins.SaveChanges();
            Data.ItemsSource = null;
            Data.ItemsSource = taikhoanList;
            MessageBox.Show("Đã xóa giáo viên thành công!", "Thông báo");
        }
        private void FindTK_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            TextBox inputTextBox = (TextBox)sender;
            string findContent = inputTextBox.Text;
            taikhoanList = new ObservableCollection<TAIKHOAN>();
            if (FindTK.SelectedIndex == 0)
            {
                foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs.ToList())
                {
                    if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.HOTEN.ToLower().Contains(findContent.ToLower()))
                        taikhoanList.Add(tk);
                }
            }
            else
            {
                foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs.ToList())
                {
                    if (tk.ISDELETED == false && tk.VAITRO == "GV" && tk.USERNAME.ToLower().Contains(findContent.ToLower()))
                        taikhoanList.Add(tk);
                }
            }
            if (Data != null)
            {
                Data.ItemsSource = null;
                Data.ItemsSource = taikhoanList;
            }
        }
    }
}
