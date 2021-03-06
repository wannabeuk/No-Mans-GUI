﻿using NoMansGUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NoMansGUI.Utils.TemplateSelectors
{
    /// <summary>
    /// Not sure if you can/will make use of this yourself, it simply tells the view which template to use based on the type, this is where all the 
    /// display stuff is done.
    /// </summary>
    public class MBINTemplateSelector : DataTemplateSelector
    {
        private static readonly log4net.ILog m_log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (item is MBINField field)
            {
                //Get just the last part of the string
                string switchCase = field.NMSType.Split('.').Last();
                switch(switchCase.ToLower())
                {
                    case "list":                       
                        return element.FindResource("ListDataTemplate") as DataTemplate;
                    case "string":
                        return element.FindResource("StringDataTemplate") as DataTemplate;
                    case "int":
                        return element.FindResource("IntDataTemplate") as DataTemplate;
                    case "boolean":
                        return element.FindResource("BoolDataTemplate") as DataTemplate;
                    default:
                        //We don't yet have a match for these, for now we return the standard string template and log it as missing.
                        m_log.Error("No Template found for item of type " + switchCase);
                        return element.FindResource("StringDataTemplate") as DataTemplate;
                }
            }

            return element.FindResource("StringDataTemplate") as DataTemplate;
        }

    }
}
