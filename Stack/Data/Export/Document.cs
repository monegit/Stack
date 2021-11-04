using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stack.Data.Export
{
    class Document
    {
        public XmlDocument xdoc = new XmlDocument();

        public Document()
        {
            XmlNode root = xdoc.CreateElement("Employees");
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


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Stack file (*.st)|*.st";
            if (saveFileDialog.ShowDialog() == true)
                xdoc.Save(saveFileDialog.FileName);
            //File.WriteAllText(saveFileDialog.FileName, "ddd");

            // XML 파일 저장
            //xdoc.Save(@"C:\Temp\Emp.xml");
        }
    }
}