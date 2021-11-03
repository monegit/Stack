using System.Windows;
using System.Windows.Controls;

namespace Stack.UI.Panel.Monitor.Unit
{
    /// <summary>
    /// Location.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Location : UserControl
    {
        public FrameworkElement Target { get; set; }
        private Thickness _thickness = new Thickness();

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

        private enum VH
        {
            Vertical = 0,
            Horizon
        }

        private Thickness ConvertThickness(double d, VH vh)
        {

            switch (vh)
            {
                case VH.Horizon:
                    _thickness.Left = d;
                    _thickness.Right = -d;
                    break;
                case VH.Vertical:
                    _thickness.Top = d;
                    _thickness.Bottom = -d;
                    break;
                default:
                    _thickness = new Thickness(0);
                    break;
            }
            
            return _thickness;
        }

        private void XAttributeChanged(object sender, TextChangedEventArgs e)
        {
            Target.Margin = ConvertThickness(X, VH.Horizon);
        }

        private void YAttributeChanged(object sender, TextChangedEventArgs e)
        {
            Target.Margin = ConvertThickness(Y, VH.Vertical);
        }
    }
}
