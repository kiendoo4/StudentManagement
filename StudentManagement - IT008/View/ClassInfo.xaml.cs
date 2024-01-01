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
        public LOP info = new LOP();
        public ClassInfo()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            KhoiBox.Text = info.KHOI.ToString();
            ClassBox.Text = info.TENLOP;
            TeacherBox.Text = info.TENGV;
            NienKhoaBox.Text = info.NAMHOC;
        }
    }
}
