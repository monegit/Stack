using Microsoft.Win32;
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
        public XmlDocument xdoc = new XmlDocument();
        public XmlDocument doc = new XmlDocument();

        public Document()
        {
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

                x.Value = unit.Margin.Left.ToString();
                y.Value = unit.Margin.Top.ToString();
                width.Value = unit.ActualWidth.ToString();
                height.Value = unit.ActualHeight.ToString();

                atom.Attributes.Append(x);
                atom.Attributes.Append(y);
                atom.Attributes.Append(width);
                atom.Attributes.Append(height);

                root.AppendChild(atom);
                //   Debug.WriteLine($"type: {unit.GetType().Name}, top: {unit.Margin.Top}, left: {unit.Margin.Left}");
            }

            /*            XmlNode root = xdoc.CreateElement("Employees");
                        xdoc.AppendChild(root);

                        // Employee#1001
                        XmlNode emp1 = xdoc.CreateElement("Employee");
                        XmlAttribute attr = xdoc.CreateAttribute("Id");
                        attr.Value = "1001";
                        emp1.Attributes.Append(attr);

                        XmlNode name1 = xdoc.CreateElement("Name");
                        name1.InnerText = "Tim";
                        emp1.AppendChild(name1);

                        XmlNode dept1 = xdoc.CreateElement("Dept");
                        dept1.InnerText = "Sales";
                        emp1.AppendChild(dept1);

                        root.AppendChild(emp1);

                        // Employee#1002
                        var emp2 = xdoc.CreateElement("Employee");
                        var attr2 = xdoc.CreateAttribute("Id");
                        attr2.Value = "1002";
                        emp2.Attributes.Append(attr2);

                        var name2 = xdoc.CreateElement("Name");
                        name2.InnerText = "John";
                        emp2.AppendChild(name2);

                        XmlNode dept2 = xdoc.CreateElement("Dept");
                        dept2.InnerText = "HR";
                        emp2.AppendChild(dept2);

                        root.AppendChild(emp2);
            */

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Stack file (*.st)|*.st";
            if (saveFileDialog.ShowDialog() == true)
                doc.Save(saveFileDialog.FileName);
            //File.WriteAllText(saveFileDialog.FileName, "ddd");

            // XML 파일 저장
            //xdoc.Save(@"C:\Temp\Emp.xml");
        }
    }
}