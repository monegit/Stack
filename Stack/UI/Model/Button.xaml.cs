using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
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
using Stack.Data.Attribute;
using Stack.Handler.Movement;

namespace Stack.UI.Model
{
    /// <summary>
    /// Button.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Button : UserControl
    {
        #region DependencyProperty
        public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            "Content", typeof(string), typeof(Button), new PropertyMetadata(default(string)));

        public new string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
        #endregion

        public Button()
        {
            DataContext = this;
            InitializeComponent();
        }

    }
}
