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
    /// Interaction logic for Home2.xaml
    /// </summary>
    public partial class Home2 : UserControl
    {
        public Home2()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent ButtonClickEvent = EventManager.RegisterRoutedEvent(
            "ButtonClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Home2)
        );
        public event RoutedEventHandler ButtonClick
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }
        private void RaiseButtonClickEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ButtonClickEvent);
            RaiseEvent(args);
        }
        private void Button_click(object sender, RoutedEventArgs e)
        {
            RaiseButtonClickEvent();
        }
        public LOP AssociatedLOP { get; set; }

    }
}
