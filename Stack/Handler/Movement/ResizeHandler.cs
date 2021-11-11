using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Brushes = System.Drawing.Brushes;
using Size = System.Windows.Size;

namespace Stack.Handler.Movement
{
    class ResizeHandler : Adorner
    {
        private Thumb topLeftThumb;
        private Thumb topRightThumb;
        private Thumb bottomLeftThumb;
        private Thumb bottomRightThumb;

        private VisualCollection visualCollection;

        protected override int VisualChildrenCount
        {
            get
            {
                return this.visualCollection.Count;
            }
        }

        public ResizeHandler(UIElement targetElement) : base(targetElement)
        {
            this.visualCollection = new VisualCollection(this);

            SetThumb(ref this.topLeftThumb, Cursors.SizeNWSE);
            SetThumb(ref this.topRightThumb, Cursors.SizeNESW);
            SetThumb(ref this.bottomLeftThumb, Cursors.SizeNESW);
            SetThumb(ref this.bottomRightThumb, Cursors.SizeNWSE);

            this.topLeftThumb.DragDelta += topLeftThumb_DragDelta;
            this.topRightThumb.DragDelta += topRightThumb_DragDelta;
            this.bottomLeftThumb.DragDelta += bottomLeftThumb_DragDelta;
            this.bottomRightThumb.DragDelta += bottomRightThumb_DragDelta;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.visualCollection[index];
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double desiredWidth = AdornedElement.DesiredSize.Width;
            double desiredHeight = AdornedElement.DesiredSize.Height;

            double adornerWidth = DesiredSize.Width;
            double adornerHeight = DesiredSize.Height;

            this.topLeftThumb.Arrange
            (
                new Rect
                (
                    -adornerWidth / 2,
                    -adornerHeight / 2,
                    adornerWidth,
                    adornerHeight
                )
            );

            this.topRightThumb.Arrange
            (
                new Rect
                (
                    desiredWidth - adornerWidth / 2,
                    -adornerHeight / 2,
                    adornerWidth,
                    adornerHeight
                )
            );

            this.bottomLeftThumb.Arrange
            (
                new Rect
                (
                    -adornerWidth / 2,
                    desiredHeight - adornerHeight / 2,
                    adornerWidth,
                    adornerHeight
                )
            );

            this.bottomRightThumb.Arrange
            (
                new Rect
                (
                    desiredWidth - adornerWidth / 2,
                    desiredHeight - adornerHeight / 2,
                    adornerWidth,
                    adornerHeight
                )
            );

            return finalSize;
        }

        private void topLeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;

            Thumb thumb = sender as Thumb;

            if (element == null || thumb == null)
            {
                return;
            }

            SetSize(element);

            element.Width = Math.Max(element.Width - (e.HorizontalChange / 2), thumb.DesiredSize.Width);
            element.Height = Math.Max(element.Height - e.VerticalChange, thumb.DesiredSize.Height);
            element.Margin =
                new Thickness(
                    element.Margin.Left + (e.HorizontalChange / 2),
                    element.Margin.Top + e.VerticalChange,
                    element.Margin.Right - (e.HorizontalChange / 2),
                    element.Margin.Bottom - e.VerticalChange);
        }

        private void topRightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;

            Thumb thumb = sender as Thumb;

            if (element == null || thumb == null)
            {
                return;
            }

            SetSize(element);

            element.Width = Math.Max(element.Width + e.HorizontalChange, thumb.DesiredSize.Width);
            element.Height = Math.Max(element.Height - e.VerticalChange, thumb.DesiredSize.Height);
            element.Margin =
                new Thickness(
                    element.Margin.Left,
                    element.Margin.Top + e.VerticalChange,
                    element.Margin.Right,
                    element.Margin.Bottom - e.VerticalChange);
        }

        private void bottomLeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;

            Thumb thumb = sender as Thumb;

            if (element == null || thumb == null)
            {
                return;
            }

            SetSize(element);

            element.Width = Math.Max(element.Width - (e.HorizontalChange/2), thumb.DesiredSize.Width);
            element.Margin = 
                new Thickness(
                    element.Margin.Left + (e.HorizontalChange / 2), 
                    element.Margin.Top, 
                    element.Margin.Right - (e.HorizontalChange / 2), 
                    element.Margin.Bottom);
            element.Height = Math.Max(e.VerticalChange + element.Height, thumb.DesiredSize.Height);
        }

        private void bottomRightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement element = AdornedElement as FrameworkElement;

            Thumb thumb = sender as Thumb;

            if (element == null || thumb == null)
            {
                return;
            }

            SetSize(element);

            element.Width = Math.Max(element.Width + e.HorizontalChange, thumb.DesiredSize.Width); 
            element.Margin = new Thickness(element.Margin.Left, element.Margin.Top, element.Margin.Right, element.Margin.Bottom);

            element.Height = Math.Max(e.VerticalChange + element.Height, thumb.DesiredSize.Height);
        }

        private void SetThumb(ref Thumb thumb, Cursor cursor)
        {
            if (thumb != null)
            {
                return;
            }

            thumb = new Thumb();

            thumb.Height = thumb.Width = 10;
            thumb.Opacity = 0.40;
            thumb.Background = new SolidColorBrush(Colors.MediumBlue);
            thumb.Cursor = cursor;

            this.visualCollection.Add(thumb);
        }

        private void SetSize(FrameworkElement targetElement)
        {
            if (targetElement.Width.Equals(Double.NaN))
            {
                targetElement.Width = targetElement.DesiredSize.Width;
            }

            if (targetElement.Height.Equals(Double.NaN))
            {
                targetElement.Height = targetElement.DesiredSize.Height;
            }

            FrameworkElement parentElement = targetElement.Parent as FrameworkElement;

            if (parentElement != null)
            {
                targetElement.MaxHeight = parentElement.ActualHeight;
                targetElement.MaxWidth = parentElement.ActualWidth;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var a = new Grid()
            {
                Width = 100,
                Height = 100,
                Background = System.Windows.Media.Brushes.Red
            };

            //drawingContext.DrawDrawing(a, null, );
        }
    }
}
