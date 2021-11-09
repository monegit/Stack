using Microsoft.Win32;
using Stack.Data.Image;
using Stack.UI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var source = doc.CreateAttribute("Source");

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
                        var button = (Button)unit;
                        if (button.Content != null)
                        {
                            text.Value = button.Content;
                            atom.Attributes.Append(text);
                        }
                        break;
                    case "Image":
                        var image = (UI.Model.Image)unit;
                        if (image.ImagePath != null)
                        {
                            source.Value = Image.Convert.PathToBase64(image.ImagePath);
                            atom.Attributes.Append(source);
                        }
                        break;
                }

                root.AppendChild(atom);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Stack file (*.st)|*.st";
                if (saveFileDialog.ShowDialog() == true)
                    doc.Save(saveFileDialog.FileName);
            }
        }
    }
}