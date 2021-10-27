using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Stack.Handler.Movement;
using Stack.UI.Modal;

namespace Stack
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {
        private static Main _main;
        internal static Main Instance { get => _main; }
        private AdornerLayer adornerLayer;
        Adorner adorner;
        
        public Main()
        {
            _main = this;

            InitializeComponent();

            //new ResizeHandler(asdf);
            new MovementHandler(asdf, Canvas);
            //new Modal(StackBase);
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adornerLayer = AdornerLayer.GetAdornerLayer(asdf);
            adornerLayer.Add(new ResizeHandler(asdf));
            adorner = adornerLayer.GetAdorners(asdf)[0];
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {

            adornerLayer = AdornerLayer.GetAdornerLayer(asdf);
            adornerLayer.Remove(adorner);
            MessageBox.Show("dd");
        }
    }
}
