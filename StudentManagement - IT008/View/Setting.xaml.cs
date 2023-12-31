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
            AddSubjects addSubjects = new AddSubjects(monhocList);
            AddMonHocUC.Children.Add(addSubjects);
            AddorFixSubjects.Text = "Thêm môn học";

        }
        private void ChangeTTMonhoc(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MONHOC dataItem = (MONHOC)button.DataContext;
            AddMonHocUC.Children.Clear();
            AddSubjects addSubjects = new AddSubjects(monhocList, dataItem);
            AddMonHocUC.Children.Add(addSubjects);
            AddorFixSubjects.Text = "Chỉnh sửa môn học";
        }
        private void DeleteSubjectButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
