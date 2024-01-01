using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Ranking_Period.xaml
    /// </summary>
    public partial class Ranking_Period : UserControl
    {
        public Ranking_Period()
        {
            InitializeComponent();
            Ranking.ItemsSource = Entity.ins.HOCSINHs;
        }
    }
}
