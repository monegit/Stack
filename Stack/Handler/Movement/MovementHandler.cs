using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Stack.UI.Model;
using Stack.UI.Panel.Monitor;
using Stack.UI.Panel.Monitor.Unit;

namespace Stack.Handler.Movement
{
    internal class MovementHandler
    {
        private readonly FrameworkElement _atom;
        private readonly Canvas _canvas;
        UnitFrame a = new UnitFrame();


        // Attributes
        private readonly Location _location = new Location();

        private AdornerLayer adornerLayer;
        Adorner adorner;

        public MovementHandler(FrameworkElement target, Canvas canvas)
        {
            target.MouseLeftButtonDown += MouseDown;
            target.MouseLeftButtonUp += MouseUp;
            target.MouseMove += MouseMove;

            _atom = target;
            _canvas = canvas;

            _location.Target = _atom;

            adornerLayer = AdornerLayer.GetAdornerLayer(_atom);
            adornerLayer.Add(new ResizeHandler(_atom));
            adorner = adornerLayer.GetAdorners(_atom)[0];
        }

        #region Events
        private bool _isDrag;
        private Point _point;
        private Thickness _margin;

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDrag) return;

            var pt = e.GetPosition(_canvas);

            var moveX = pt.X - _point.X;
            var moveY = pt.Y - _point.Y;
            _atom.Margin = 
                new Thickness(
                    _margin.Left + moveX, 
                    _margin.Top + moveY, 
                    _margin.Right - moveX, 
                    _margin.Bottom - moveY);

            _location.X = _atom.Margin.Left;
            _location.Y = _atom.Margin.Top;
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDrag = false;
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            _point = e.GetPosition(_canvas);
            _margin = _atom.Margin;
            _isDrag = true;

            var aa = new Rectangle()
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Red
            };
            var units = new FrameworkElement[] { _location, aa };
            new AttributeHandler(units);
        }
        #endregion
    }
}
