﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Stack.UI.Modal
{
    class Modal
    {
        public Modal(Grid target)
        {
            target.Children.Add(new ModalView());
        }
    }
}
