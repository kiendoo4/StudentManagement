using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement___IT008.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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


namespace StudentManagement___IT008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentYear { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //AddUserControlToGrid();
            leftGroup.StudentScreenButton.ButtonClick += StudentScreenUserControl_ButtonClick;
            leftGroup.TeacherScreenButton.ButtonClick += TeacherScreenButton_ButtonClick;
            leftGroup.SettingButton.ButtonClick += SettingButton_ButtonClick;
            leftGroup.ClassScreenButton.ButtonClick += ClassScreenButton_ButtonClick;
            leftGroup.ResultScreenButton.ButtonClick += ResultScreenButton_ButtonClick;
            leftGroup.HomeScreenButton.ButtonClick += HomeScreenButton_ButtonClick;
            currentYear = overview.CurrentYear.ToString();
        }
        public MainWindow(bool role, LoginView loginView)
        {
            InitializeComponent();
            loginView.Close();
            if (role == true)
            {
                leftGroup.StudentScreenButton.ButtonClick += StudentScreenUserControl_ButtonClick;
                leftGroup.TeacherScreenButton.ButtonClick += TeacherScreenButton_ButtonClick;
                leftGroup.SettingButton.ButtonClick += SettingButton_ButtonClick;
                leftGroup.ClassScreenButton.ButtonClick += ClassScreenButton_ButtonClick;
                leftGroup.ResultScreenButton.ButtonClick += ResultScreenButton_ButtonClick;
                leftGroup.HomeScreenButton.ButtonClick += HomeScreenButton_ButtonClick;
                currentYear = overview.CurrentYear.ToString();
            }
            else
            {
                leftGroup.StudentScreenButton.ButtonClick += StudentScreenUserControl_ButtonClick;
                leftGroup.TeacherScreenButton.ButtonClick += TeacherScreenButtonNotAdmin_ButtonClick;
                leftGroup.SettingButton.ButtonClick += SettingButtonNotAdmin_ButtonClick;
                leftGroup.ClassScreenButton.ButtonClick += ClassScreenButtonNotAdmin_ButtonClick;
                leftGroup.ResultScreenButton.ButtonClick += ResultScreenButton_ButtonClick;
                leftGroup.HomeScreenButton.ButtonClick += HomeScreenButton_ButtonClick;
                currentYear = overview.CurrentYear.ToString();
            }
            
        }
        private void HomeScreenButton_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            Home home = new Home(); 
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(home);
        }

        private void ResultScreenButton_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            Summarize_US periodList = new Summarize_US();
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(periodList);
        }

        private void ClassScreenButton_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            ClassesList classesList = new ClassesList(true);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(classesList);
        }
        private void ClassScreenButtonNotAdmin_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            ClassesList classesList = new ClassesList(false);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(classesList);
        }
        private void SettingButton_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            Setting setting = new Setting(true);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(setting);
        }
        private void SettingButtonNotAdmin_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.SettingButton.IsButtonPressed = true;
            Setting setting = new Setting(false);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(setting);
        }

        private void TeacherScreenButton_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.StudentScreenButton.IsButtonPressed = true;
            TeachersList teachersList = new TeachersList(true);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(teachersList);
        }
        private void TeacherScreenButtonNotAdmin_ButtonClick(object sender, EventArgs e)
        {
            leftGroup.StudentScreenButton.IsButtonPressed = true;
            TeachersList teachersList = new TeachersList(false);
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(teachersList);
        }
        private void StudentScreenUserControl_ButtonClick(object sender, System.EventArgs e)
        {
            // Set the button state in the InnerUserControl
            leftGroup.StudentScreenButton.IsButtonPressed = true;
            StudentsList studentsList = new StudentsList();
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(studentsList);
        }
        //private void AddUserControlToGrid()
        //{
        //    // Create an instance of your UserControl
        //    StudentsList studentsList = new StudentsList();
        //    TeachersList teachersList = new TeachersList();
        //    CurrentUC.Children.Clear();
        //    CurrentUC.Children.Add(studentsList);
        //    //if (leftGroup.StudentScreenButton.ButtonClick)
        //    //{
        //    //    MessageBox.Show("bruh");
        //    //    CurrentUC.Children.Clear();
        //    //    CurrentUC.Children.Add(studentsList);
        //    //}
        //    //else if (leftGroup.TeacherScreenButton.ButtonClick)
        //    //{
        //    //    CurrentUC.Children.Clear();
        //    //    CurrentUC.Children.Add(teachersList);
        //    //}
        //}
        private void HideClick(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow as Window;
            window.WindowState = WindowState.Minimized;
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


        private void AddNamHoc(object sender, RoutedEventArgs e)
        {
            AddNewYear addNewYear = new AddNewYear();
            CurrentUC.Children.Clear();
            CurrentUC.Children.Add(addNewYear);
        }
        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView(this);
            loginView.Show();
        }
    }
}
