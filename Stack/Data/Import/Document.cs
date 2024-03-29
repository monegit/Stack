﻿using Stack.Handler.Movement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Stack.Data.Import
{
    class Document
    {
        readonly XmlDocument doc = new XmlDocument();
        readonly Main main = Main.Instance;

        public Document(string docPath)
        {
            doc.Load(docPath);
            main.Canvas.Children.Clear();

            SetStackInfo();
            SetAtomInfo();
        }

        private double AtoI(string str)
        {
            return Convert.ToDouble(str);
        }

        private XmlNodeList GetNodeList(string node)
        {
            return doc.SelectNodes(node);
        }

        private void SetStackInfo()
        {
            var nodes = GetNodeList("/StackInfo");

            foreach(XmlNode root in nodes)
            {
                var width = AtoI(root.Attributes["Width"].Value);
                var height = AtoI(root.Attributes["Height"].Value);

                main.CanvasBase.Width = width;
                main.CanvasBase.Height = height;

            }
        }

        private void SetAtomInfo()
        {
            var nodes = GetNodeList("/StackInfo");

            foreach(XmlNode root in nodes)
            {
                foreach(XmlNode child in root.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "Button":
                            var button = new UI.Model.Button();
                            main.Canvas.Children.Add(button);
                            var buttonMove = new MovementHandler(button, main.Canvas);

                            foreach (XmlNode att in child.Attributes)
                            {
                                switch(att.Name)
                                {
                                    case "X":
                                        buttonMove._location.X = AtoI(att.Value);
                                        break;
                                    case "Y":
                                        buttonMove._location.Y = AtoI(att.Value);
                                        break;
                                    case "Width":
                                        button.Width = AtoI(att.Value);
                                        break;
                                    case "Height":
                                        button.Height = AtoI(att.Value);
                                        break;
                                    case "Text":
                                        button.Content = att.Value;
                                        break;
                                }
                            }

                            break;
                        case "Image":
                            var image = new UI.Model.Image();
                            main.Canvas.Children.Add(image);
                            var imageMove = new MovementHandler(image, main.Canvas);

                            foreach(XmlNode att in child.Attributes)
                            {
                                switch(att.Name)
                                {
                                    case "X":
                                        imageMove._location.X = AtoI(att.Value);
                                        break;
                                    case "Y":
                                        imageMove._location.Y = AtoI(att.Value);
                                        break;
                                    case "Width":
                                        image.Width = AtoI(att.Value);
                                        break;
                                    case "Height":
                                        image.Height = AtoI(att.Value);
                                        break;
                                    case "Source":
                                        image.image.Source = Image.Convert.Base64ToImage(att.Value);
                                        break;
                                }
                            }
                            break;
                    }

                }
            }
        }
    }
}
