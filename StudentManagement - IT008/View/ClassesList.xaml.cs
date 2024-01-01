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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassInfo classInfo = new ClassInfo();
            NewLopHocUC.Children.Clear();
            NewLopHocUC.Children.Add(classInfo);

        }


        private void EditClass(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            LOP dataItem = (LOP)button.DataContext;
            ClassInfo classInfo = new ClassInfo(dataItem);
            NewLopHocUC.Children.Clear();
            NewLopHocUC.Children.Add(classInfo);
        }
    }
}
