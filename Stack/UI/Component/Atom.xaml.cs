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

namespace Stack.UI.Component
{
    /// <summary>
    /// Atom.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Atom : UserControl
    {
        public Atom()
        {
            InitializeComponent();
        }

        private void a_Drop(object sender, DragEventArgs e)
        {
        }

        private void a_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.All);

        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void img1_Drop(object sender, DragEventArgs e)
        {
            Image imageControl = (Image)sender;
            if ((e.Data.GetData(typeof(ImageSource)) != null))
            {
                ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
                imageControl = new Image() { Width = 100, Height = 100, Source = image };
                img1 = imageControl;
            }

        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("dd");
        }

        private void img1_Drop_1(object sender, DragEventArgs e)
        {
            var a = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            img1.Source = new BitmapImage(new Uri(a[0], UriKind.Absolute));
        }
    }
}
