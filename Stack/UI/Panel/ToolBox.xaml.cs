using Stack.Handler.Movement;
using Stack.UI.Panel.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stack.UI.Panel
{
    /// <summary>
    /// ToolBox.xaml에 대한 상호 작용 논리
    /// </summary>
    [ContentProperty(nameof(Children))]
    public partial class ToolBox : UserControl
    {
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
            nameof(Children),
            typeof(UIElementCollection),
            typeof(ToolBox),
            new PropertyMetadata());

        public UIElementCollection Children
        {
            get => (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty);
            private set => SetValue(ChildrenProperty, value);
        }


        public ToolBox()
        {
            InitializeComponent();
            Children = Box.Children;
        }

        private void ImageUnit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var _ = new Model.Image();
            Main.Instance.Canvas.Children.Add(_);
            new MovementHandler(_, Main.Instance.Canvas);
        }

        private void SettingUnit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Modal.Modal(Main.Instance.StackBase);
        }
    }
}
