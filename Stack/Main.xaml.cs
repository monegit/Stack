using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Stack.Handler.Movement;

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

            new MovementHandler(asdf, Canvas);
        }
    }
}
