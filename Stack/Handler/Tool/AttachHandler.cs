using Stack.Handler.Movement;
using Stack.UI.Panel;
using Stack.UI.Panel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Stack.Handler.Tool
{
    class AttachHandler
    {
        #region
        public static void AttachImage(Canvas canvas)
        {
            var r = new Rectangle()
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Red
            };

            var q = new ToolFrame();
            q.Children.Add(r);
            q.MouseLeftButtonDown += AttachHandler.ImageEvent;
            Main.Instance.ToolBox.Children.Add(q);
        }
        #endregion

        #region Events
        private static void ImageEvent(object sender, MouseButtonEventArgs e)
        {
            var canvas = Main.Instance.Canvas;
            var a = new UI.Model.Image();
            canvas.Children.Add(a);
            new MovementHandler(a, canvas);
        }


        #endregion
    }
}
