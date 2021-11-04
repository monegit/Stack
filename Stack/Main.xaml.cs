using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Stack.Data.Export;
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
        
        public Main()
        {
            _main = this;

            InitializeComponent();

            //new ResizeHandler(asdf);
            //new Modal(StackBase);

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new MovementHandler(asdf, Canvas);
            new MovementHandler(aaa, Canvas);
            new MovementHandler(btn, Canvas);
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
/*
            adornerLayer = AdornerLayer.GetAdornerLayer(asdf);
            adornerLayer.Remove(adorner);*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 저장버튼

            foreach(FrameworkElement unit in Canvas.Children)
            {
                Debug.WriteLine($"type: {unit.GetType().Name}, top: {unit.Margin.Top}, left: {unit.Margin.Left}");
            }
            Debug.WriteLine("======");

            new Export(Canvas);
        }
    }
}
