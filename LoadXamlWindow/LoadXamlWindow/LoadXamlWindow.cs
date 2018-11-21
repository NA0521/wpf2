using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LoadXamlWindow
{
    class LoadXamlWindow
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();

            Uri uri = new Uri("pack://application:,,,/XamlWindow.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Window win = XamlReader.Load(stream) as Window;

            win.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click1));
            Button b = (Button)win.FindName("XamlButton");
            b.Click += B_Click;

            app.Run(win);
        }

        private static void Button_Click1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.Source as Button).Content.ToString() + "1");
        }

        private static void B_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Content.ToString() + "2");
        }
    }
}
