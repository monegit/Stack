using Stack.UI.Panel.Monitor.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Stack.Handler.Movement
{
    class AttributeHandler
    {
        static UnitFrame _unitFrame = new UnitFrame();

        public AttributeHandler(FrameworkElement[] attributeUnits)
        {
            Main.Instance.Monitor.Children.Clear();
            _unitFrame.Children.Clear();

            foreach (var unit in attributeUnits)
            {
                _unitFrame.Children.Add(unit);
            }

            Main.Instance.Monitor.Children.Add(_unitFrame);
        }
    }
}
