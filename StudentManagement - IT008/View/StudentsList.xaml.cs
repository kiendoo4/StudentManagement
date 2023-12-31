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
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : UserControl
    {
        ObservableCollection<HOCSINH> hocsinhList = new ObservableCollection<HOCSINH>();
        public StudentsList()
        {
            InitializeComponent();
            FindST.SelectedIndex = 0;
            foreach (HOCSINH hs in Entity.ins.HOCSINHs.ToList())
            {
                if (hs.ISDELETED == false)
                    hocsinhList.Add(hs);
            }    
            Data.ItemsSource = hocsinhList;
        }
        private void ChangeTTHocSinh(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            HOCSINH dataItem = (HOCSINH)button.DataContext;
            AddStudent changeTTStudent = new AddStudent(dataItem);
            changeTTStudent.ShowDialog();
            Data.ItemsSource = null;
            Data.ItemsSource = hocsinhList;
        }
        private void CheckStudentClick(object sender, RoutedEventArgs e)
        {

        }
        private void CheckAllStudentsClick(object sender, RoutedEventArgs e)
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
        private void UncheckAllStudentsClick(object sender, RoutedEventArgs e)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
            Data.ItemsSource = null;
            hocsinhList = new ObservableCollection<HOCSINH>();
            foreach (HOCSINH hs in Entity.ins.HOCSINHs.ToList())
            {
                if (hs.ISDELETED == false)
                    hocsinhList.Add(hs);
            }
            Data.ItemsSource = hocsinhList;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<HOCSINH> itemsToRemove = new List<HOCSINH>();
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        HOCSINH hocSinh = item as HOCSINH;
                        hocSinh.ISDELETED = true;
                        itemsToRemove.Add(hocSinh);
                    }
                }
            }
            foreach (HOCSINH itemToRemove in itemsToRemove)
            {
                hocsinhList.Remove(itemToRemove);
            }
            Entity.ins.SaveChanges();
            Data.ItemsSource = null;
            Data.ItemsSource = hocsinhList;
            MessageBox.Show("Đã xóa học sinh thành công!", "Thông báo");
        }
        private void FindST_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            TextBox inputTextBox = (TextBox)sender;
            string findContent = inputTextBox.Text;
            hocsinhList = new ObservableCollection<HOCSINH>();
            if (FindST.SelectedIndex == 0)
            {
                foreach (HOCSINH hs in Entity.ins.HOCSINHs.ToList())
                {
                    if (hs.ISDELETED == false && hs.HOTENHS.ToLower().Contains(findContent.ToLower()))
                        hocsinhList.Add(hs);
                }
            }
            else
            {
                foreach (HOCSINH hs in Entity.ins.HOCSINHs.ToList())
                {
                    if (hs.ISDELETED == false && hs.CCCD.ToLower().Contains(findContent.ToLower()))
                        hocsinhList.Add(hs);
                }
            }
            if (Data != null)
            {
                Data.ItemsSource = null;
                Data.ItemsSource = hocsinhList;
            }
        }
    }
}
