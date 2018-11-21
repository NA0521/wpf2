using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows;

namespace WpfApp1
{
    public class DPTest : DependencyObject
    {
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
            "Test", typeof(string), typeof(DPTest), 
            new PropertyMetadata("Dependency Property Initial Value", OnTestPropertyChandged));

        private static void OnTestPropertyChandged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Perperty changed : {0}", e.NewValue);
        }

        public string Test
        {
            get
            {
                Debug.WriteLine("Test Getvalue");
                return (string)GetValue(TestProperty);
            }
            set
            {
                Debug.WriteLine("Test Setvalue");
                SetValue(TestProperty, value);
            }
        }
    }
}
