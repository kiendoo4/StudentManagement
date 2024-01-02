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
    /// Interaction logic for Conclusion.xaml
    /// </summary>
    public partial class ClassesList : UserControl
    {
        ObservableCollection<LOP> lophocList = new ObservableCollection<LOP>();
        public ClassesList()
        {
            InitializeComponent();
            foreach (LOP lh in Entity.ins.LOPs.ToList())
            {
                if (lh.ISDELETED == false)
                    lophocList.Add(lh);
            }
            Data.ItemsSource = lophocList;
        }
        public ClassesList(bool role)
        {
            InitializeComponent();
            foreach (LOP lh in Entity.ins.LOPs.ToList())
            {
                if (lh.ISDELETED == false)
                    lophocList.Add(lh);
            }
            Data.ItemsSource = lophocList;
            if(!role)
            {
                DeleteButton.Visibility = Visibility.Hidden;
                btAdd.Visibility = Visibility.Hidden;
                Fixing.Visibility = Visibility.Hidden;
            }    
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassInfo classInfo = new ClassInfo(lophocList);
            NewLopHocUC.Children.Clear();
            NewLopHocUC.Children.Add(classInfo);

        }

        private void CheckAllLopsClick(object sender, RoutedEventArgs e)
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
        private void UncheckAllLopsClick(object sender, RoutedEventArgs e)
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
        private void EditClass(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            LOP dataItem = (LOP)button.DataContext;
            ClassInfo classInfo = new ClassInfo(dataItem, lophocList);
            NewLopHocUC.Children.Clear();
            NewLopHocUC.Children.Add(classInfo);
        }
        string findtk;
        private void FindCL_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            TextBox inputTextBox = (TextBox)sender;
            string findContent = inputTextBox.Text;
            lophocList = new ObservableCollection<LOP>();
            if (ChoosingSearch.SelectedIndex == 0)
            {
                foreach (LOP l in Entity.ins.LOPs.ToList())
                {
                    if (l.ISDELETED == false && l.MALOP.ToLower().Contains(findContent.ToLower()))
                        lophocList.Add(l);
                }
            }
            else
            {
                foreach (LOP l in Entity.ins.LOPs.ToList())
                {
                    if (l.TENGV != null)
                    {
                        if (l.ISDELETED == false && l.TENGV.ToLower().Contains(findContent.ToLower()))
                            lophocList.Add(l);
                    }
                    else
                    {
                        if (l.ISDELETED == false)
                            lophocList.Add(l);
                    }    
                }
            }
            if (Data != null)
            {
                Data.ItemsSource = null;
                Data.ItemsSource = lophocList;
            }
        }

        private void EraseClass(object sender, RoutedEventArgs e)
        {
            List<LOP> itemsToRemove = new List<LOP>();
            foreach (var item in Data.Items)
            {
                var row = Data.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    CheckBox checkBox = FindVisualChild<CheckBox>(row);
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        LOP l = item as LOP;
                        l.ISDELETED = true;
                        itemsToRemove.Add(l);
                    }
                }
            }
            foreach (LOP itemToRemove in itemsToRemove)
            {
                lophocList.Remove(itemToRemove);
            }
            Entity.ins.SaveChanges();
            Data.ItemsSource = null;
            Data.ItemsSource = lophocList;
            MessageBox.Show("Đã xóa lớp học thành công!", "Thông báo");
        }
    }
}
