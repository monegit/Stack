using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Stack.UI.Component;

namespace Stack.Handler.Movement
{
    internal class MovementHandler
    {
        private readonly Atom _atom;
        private readonly Canvas _canvas;

        public MovementHandler(Atom target, Canvas canvas)
        {
            target.MouseLeftButtonDown += MouseDown;
            target.MouseLeftButtonUp += MouseUp;
            target.MouseMove += MouseMove;

            _atom = target;
            _canvas = canvas;
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
