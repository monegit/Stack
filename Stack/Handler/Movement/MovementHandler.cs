using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Stack.Data.Attribute;
using Stack.UI.Model;
using Stack.UI.Panel.Monitor;
using Stack.UI.Panel.Monitor.Unit;

namespace Stack.Handler.Movement
{
    internal class MovementHandler
    {
        private readonly FrameworkElement _atom;
        private readonly Canvas _canvas;
        private static FrameworkElement onFocus;

        // Attributes
        public Location _location = new Location();
        private AdornerLayer adornerLayer;
        Adorner adorner;

        public MovementHandler(FrameworkElement target, Canvas canvas)
        {
            target.MouseLeftButtonDown += MouseDown;
            target.MouseLeftButtonUp += MouseUp;
            target.MouseMove += MouseMove;
            Main.Instance.PreviewKeyDown += Main_KeyDown;
            Main.Instance.Canvas.PreviewMouseDown += Main_MouseDown;

            _atom = target;
            _atom.Width = 100;
            _atom.Height = 100;
            _canvas = canvas;

            _location.Target = _atom;
        }


        private void RemoveAdorner(FrameworkElement atom)
        {

            /*foreach (var _ in adornerLayer?.GetAdorners(atom))
            {
                adorner = _;
                adornerLayer.Remove(adorner);
            }*/
        }

        private void SetAdorner(FrameworkElement target)
        {
            adornerLayer = AdornerLayer.GetAdornerLayer(target);
            adornerLayer.Add(new ResizeHandler(target));
            adorner = adornerLayer.GetAdorners(target)[0];
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                case Key.Back:
                    _canvas.Children.Remove(onFocus);
                    break;
            }
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

            // focus
            onFocus = _atom;

            SetAdorner(_atom);

            var units = new FrameworkElement[] { _location };
            new AttributeHandler(units);
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(e.Source.GetType().Name);
            //if (sender.GetType().Name == "Image")
                RemoveAdorner(onFocus);
        }
        #endregion
    }
}
