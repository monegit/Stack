using Microsoft.Win32;
using Stack.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Stack.Data.Export
{
    class Document
    {
        public XmlDocument doc = new XmlDocument();

        public Document()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Stack file (*.st)|*.st"
            };

            if (saveFileDialog.ShowDialog() != true) return;

            var root = doc.CreateElement("StackInfo");
            var canvasWidth = doc.CreateAttribute("Width");
            var canvasHeight = doc.CreateAttribute("Height");

            doc.AppendChild(root);
            canvasWidth.Value = Main.Instance.Canvas.ActualWidth.ToString();
            canvasHeight.Value = Main.Instance.Canvas.ActualHeight.ToString();
            root.Attributes.Append(canvasWidth);
            root.Attributes.Append(canvasHeight);

            foreach (FrameworkElement unit in Main.Instance.Canvas.Children)
            {
                var atom = doc.CreateElement(unit.GetType().Name);
                var x = doc.CreateAttribute("X");
                var y = doc.CreateAttribute("Y");
                var width = doc.CreateAttribute("Width");
                var height = doc.CreateAttribute("Height");
                var text = doc.CreateAttribute("Text");

                x.Value = unit.Margin.Left.ToString();
                y.Value = unit.Margin.Top.ToString();
                width.Value = unit.ActualWidth.ToString();
                height.Value = unit.ActualHeight.ToString();

                atom.Attributes.Append(x);
                atom.Attributes.Append(y);
                atom.Attributes.Append(width);
                atom.Attributes.Append(height);

                switch (unit.GetType().Name)
                {
                    case "Button":
                        text.Value = unit.GetType().Name.ToString();
                        atom.Attributes.Append(text);
                        break;
                }

                root.AppendChild(atom);
                //   Debug.WriteLine($"type: {unit.GetType().Name}, top: {unit.Margin.Top}, left: {unit.Margin.Left}");
            }

            doc.Save(saveFileDialog.FileName);
        }
    }
}