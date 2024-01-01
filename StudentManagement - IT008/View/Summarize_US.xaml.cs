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
    /// Interaction logic for Summarize_US.xaml
    /// </summary>
    public partial class Summarize_US : UserControl
    {
        public Summarize_US()
        {
            InitializeComponent();
            cb_Period.SelectedIndex = 0;
            cb_Subject.SelectedIndex = 0;
            ReportType.SelectedIndex = 0;
            ComboBoxItem cbi_Period = (ComboBoxItem)cb_Period.SelectedItem;
            Summarize_Period periodList = new Summarize_Period(cbi_Period.Content.ToString());
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(periodList);
        }

        private void btn_hoantat_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi_Period = (ComboBoxItem)cb_Period.SelectedItem;
            ComboBoxItem cbi_Subject = (ComboBoxItem)cb_Subject.SelectedItem;
            switch (ReportType.SelectedIndex)
            {
                case 0:
                    Summarize_Subject subjectList = new Summarize_Subject();
                    CurrentUC.Children.Clear();
                    CurrentUC.Children.Add(subjectList);
                    break;
                case 1:
                    Summarize_Period periodList = new Summarize_Period(cbi_Period.Content.ToString());
                    CurrentUC.Children.Clear();
                    CurrentUC.Children.Add(periodList);
                    break;
            }

        }
    }
}
