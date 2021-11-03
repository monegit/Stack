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

namespace Stack.UI.Model
{
    /// <summary>
    /// Atom.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Image : UserControl
    {
        public Image()
        {
            InitializeComponent();
        }

        private void img1_Drop_1(object sender, DragEventArgs e)
        {
            var a = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            img1.Source = new BitmapImage(new Uri(a[0], UriKind.Absolute));
        }

    }
}
