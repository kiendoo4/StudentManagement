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
using System.Windows.Shapes;

namespace StudentManagement___IT008.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            bool ck = false;
            foreach (TAIKHOAN tk in Entity.ins.TAIKHOANs)
            {
                if (tk.USERNAME == Username.Text && tk.PASSWRD == Password.Password && tk.ISDELETED == false) 
                {
                    if(tk.VAITRO == "admin")
                    {
                        MainWindow main = new MainWindow(true, this);
                        main.Show();
                        ck = true;
                    }   
                    else
                    {
                        GIAOVIEN gv = Entity.ins.GIAOVIENs.SingleOrDefault(g => g.USERNAME == tk.USERNAME && g.ISDELETED == false);
                        if(gv != null)
                        {
                            MainWindow main = new MainWindow(false, this);
                            main.Show();
                            ck = true;
                        }    
                    }
                    break;
                }
            }
            if(!ck) MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Thông báo");
        }
        private void HideClick(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.MainWindow as Window;
            window.WindowState = WindowState.Minimized;
        }
        private void CloseClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
