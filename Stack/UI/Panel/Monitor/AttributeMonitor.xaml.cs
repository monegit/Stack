﻿using Stack.UI.Panel.Monitor.Unit;
using System;
using System.Collections.Generic;
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

namespace Stack.UI.Panel.Monitor
{
    /// <summary>
    /// AttributeMonitor.xaml에 대한 상호 작용 논리
    /// </summary>
    [ContentProperty(nameof(Children))]
    public partial class AttributeMonitor : UserControl
    {
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
            nameof(Children),
            typeof(UIElementCollection),
            typeof(AttributeMonitor),
            new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set 
            {
                SetValue(ChildrenProperty, value);
            }
        }

        public AttributeMonitor()
        {
            InitializeComponent();
            Children = Monitor.Children;
        }
    }
}
