using StudentManagement___IT008.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        ObservableCollection<LOP> lopList = new ObservableCollection<LOP>();
        public Home()
        {
            InitializeComponent();

            foreach (LOP l in Entity.ins.LOPs)
            {
                LOPHOCTHUCTE lh = Entity.ins.LOPHOCTHUCTEs.SingleOrDefault(ll => ll.MALOP == l.MALOP);
                if(lh.ISDELETED == false)
                {
                    lopList.Add(l);
                    Home2 home2 = new Home2();
                    home2.AddHandler(Home2.ButtonClickEvent, new RoutedEventHandler(Home2_ButtonClick));
                    home2.AssociatedLOP = l;
                    home2.DataContext = l;
                    lopsUI.Children.Add(home2);
                    
                }    
            }    
        }
        private void Home2_ButtonClick(object sender, RoutedEventArgs e)
        {
            Home2 home2 = sender as Home2;
            if (home2 != null)
            {
                LOP associatedLOP = home2.AssociatedLOP;
                // Now you can use 'associatedLOP' to get the LOP information
                //MessageBox.Show($"Button Clicked for LOP: {associatedLOP?.MALOP}");
                HomeCurrentUC.Children.Clear();
                ClassWelcome home1 = new ClassWelcome(associatedLOP);
                HomeCurrentUC.Children.Add(home1);
            }
        }
        
    }
}
