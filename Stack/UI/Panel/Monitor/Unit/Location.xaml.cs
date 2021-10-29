using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Stack.UI.Panel.Monitor.Unit
{
    /// <summary>
    /// Location.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Location : UserControl
    {
        public FrameworkElement Target { get; set; }

        #region DependencyProperty
        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            "X", typeof(double), typeof(Location), new PropertyMetadata(default(double)));

        public double X
        {
            get => (double)GetValue(XProperty);
            set => SetValue(XProperty, value);
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
            "Y", typeof(double), typeof(Location), new PropertyMetadata(default(double)));

        public double Y
        {
            get => (double)GetValue(YProperty);
            set => SetValue(YProperty, value);
        }
        #endregion

        public Location()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void XAttributeChanged(object sender, TextChangedEventArgs e)
        {
            Target.Margin = new Thickness(
                X,
                Target.Margin.Top,
                -X,
                Target.Margin.Bottom);
        }

        private void YAttributeChanged(object sender, TextChangedEventArgs e)
        {
            Target.Margin = new Thickness(
                Target.Margin.Left,
                Y,
                Target.Margin.Right,
                -Y);
        }
    }
}
