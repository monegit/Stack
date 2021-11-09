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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stack.UI.Modal
{
    /// <summary>
    /// ModalView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModalView : UserControl
    {
        public ModalView(Grid target)
        {
            InitializeComponent();
            target.Children.Add(this);
        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var storyboard = (Storyboard)(FindResource("PanelCloseEvent"));
            storyboard.Begin();
        }
    }
}
