using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace LoadXaml
{
    class LoadXaml : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXaml());

        }

        public LoadXaml()
        {
            Title = "Load Embedded Xaml";

            string strXaml =
                "<Button xmlns='http://schemas.microsoft.com/" +
                "winfx/2006/xaml/presentation'" +
                 " Foreground='LightSeaGreen' FontSize='24pt'>" +
                 " Hello, WPF!" +
                 "</Button>";

            StringReader strReader = new StringReader(strXaml);
            XmlTextReader xmlReader = new XmlTextReader(strReader);

            Button b = (Button)XamlReader.Load(xmlReader);
            b.Click += B_Click;

            Content = b;
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Embedded Xaml Test");
        }
    }
}
