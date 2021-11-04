using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Stack.UI.Model
{
    /// <summary>
    /// Atom.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Image : UserControl
    {
        public string ImagePath { get; set; }

        public Image()
        {
            InitializeComponent();
        }
        
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            var path = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ImagePath = path[0];
            img1.Source = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
        }
    }
}
