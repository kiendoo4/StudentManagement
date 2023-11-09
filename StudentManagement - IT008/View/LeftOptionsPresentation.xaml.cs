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
    /// Interaction logic for LeftOptionsPresentation.xaml
    /// </summary>
    public partial class LeftOptionsPresentation : UserControl
    {
        public LeftOptionsPresentation()
        {
            InitializeComponent();
            
        }
        public string InnerText
        {
            get { return TB.Text; }
            set { TB.Text = value; }
        }
        public static readonly DependencyProperty InnerImageSourceProperty = DependencyProperty.Register(
            "InnerImageSource", typeof(string), typeof(LeftOptionsPresentation), new PropertyMetadata(null, OnInnerImageSourceChanged));

        public string InnerImageSource
        {
            get { return (string)GetValue(InnerImageSourceProperty); }
            set { SetValue(InnerImageSourceProperty, value); }
        }

        private static void OnInnerImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LeftOptionsPresentation)d;
            control.UpdateImage();
        }

        private void UpdateImage()
        {
            if (!string.IsNullOrEmpty(InnerImageSource))
            {
                ImageSymbol.Source = new BitmapImage(new Uri(InnerImageSource, UriKind.RelativeOrAbsolute));
            }
            else
            {
                ImageSymbol.Source = null;
            }
        }
    }
}
