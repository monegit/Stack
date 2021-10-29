using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Stack.UI.Model;
using Stack.UI.Panel.Monitor;
using Stack.UI.Panel.Monitor.Unit;

namespace Stack.Handler.Movement
{
    internal class MovementHandler
    {
        private readonly FrameworkElement _atom;
        private readonly Canvas _canvas;

        private readonly Location _location = new Location();

        public MovementHandler(FrameworkElement target, Canvas canvas)
        {
            target.MouseLeftButtonDown += MouseDown;
            target.MouseLeftButtonUp += MouseUp;
            target.MouseMove += MouseMove;

            _atom = target;
            _canvas = canvas;

            _location.Target = _atom;
            Main.Instance.Monitor.Children.Add(_location);
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
        }
        #endregion
    }
}
