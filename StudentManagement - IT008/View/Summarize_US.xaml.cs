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
    /// Interaction logic for Summarize_US.xaml
    /// </summary>
    public partial class Summarize_US : UserControl
    {
        public Summarize_US()
        {
            InitializeComponent();
            cb_Subject.Items.Clear();
            cb_Subject.ItemsSource = Subjects();
            cb_Period.SelectedIndex = 0;
            cb_Subject.SelectedIndex = 0;
            ReportType.SelectedIndex = 0;
            ComboBoxItem cbi_Period = (ComboBoxItem)cb_Period.SelectedItem;
            string subject = (string)cb_Subject.SelectedItem;
            Summarize_Subject subjectList = new Summarize_Subject(cbi_Period.Content.ToString(), subject);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(subjectList);
        }
        private List<string> Subjects()
        {
            List<string> subjects = new List<string>();
            foreach (MONHOC mh in Entity.ins.MONHOCs)
            {
                subjects.Add(mh.TENMH.ToString());
            }
            return subjects;
        }
        private void btn_hoantat_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi_Period = (ComboBoxItem)cb_Period.SelectedItem;
            string subject = (string)cb_Subject.SelectedItem;
            switch (ReportType.SelectedIndex)
            {
                case 0:
                    Summarize_Subject subjectList = new Summarize_Subject(cbi_Period.Content.ToString(), subject);
                    CurrentUC.Children.Clear();
                    CurrentUC.Children.Add(subjectList);
                    break;
                case 1:
                    Summarize_Period periodList = new Summarize_Period(cbi_Period.Content.ToString());
                    CurrentUC.Children.Clear();
                    CurrentUC.Children.Add(periodList);
                    break;
                case 2:
                    if (cbi_Period.Content.ToString() == "Cả năm")
                    {
                        MessageBox.Show("Vui lòng chọn học kỳ", "Thông báo");
                        break;
                    }
                    else
                    {
                        Ranking_Period ranking_Period = new Ranking_Period(cbi_Period.Content.ToString());
                        CurrentUC.Children.Clear();
                        CurrentUC.Children.Add(ranking_Period);
                        break;
                    }
                case 3:
                    Ranking_Summary summaryList = new Ranking_Summary();
                    CurrentUC.Children.Clear();
                    CurrentUC.Children.Add(summaryList);
                    break;
            }

        }

        private void SummaryChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ReportType.SelectedIndex)
            {
                case 0:
                    cb_Period.Visibility = Visibility.Visible;
                    cb_Subject.Visibility = Visibility.Visible;
                    break;
                case 1:
                    cb_Period.Visibility = Visibility.Visible;
                    cb_Subject.Visibility = Visibility.Visible;
                    break;
                case 2:
                    cb_Period.Visibility = Visibility.Visible;
                    cb_Subject.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    cb_Period.Visibility = Visibility.Collapsed;
                    cb_Subject.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
