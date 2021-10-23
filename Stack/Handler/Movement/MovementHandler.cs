using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Stack.UI.Component;

namespace Stack.Handler.Movement
{
    class MovementHandler
    {
        private Atom atom;
        private Canvas canvas;

        public MovementHandler(Atom target, Canvas canvas)
        {
            target.MouseLeftButtonDown += MouseDown;
            target.MouseLeftButtonUp += MouseUp;
            target.MouseMove += MouseMove;

            this.atom = target;
            this.canvas = canvas;
        }

        #region Events
        private bool isDrag;
        private Point point;
        private Thickness margin;

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrag) return;

            Point pt = e.GetPosition(canvas);

            double moveX = (pt.X - point.X);
            double moveY = (pt.Y - point.Y);
            atom.Margin = new Thickness(margin.Left + moveX, margin.Top + moveY, margin.Right, margin.Bottom);
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrag = false;
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(canvas);
            margin = atom.Margin;
            isDrag = true;
        }
        #endregion
    }
}
