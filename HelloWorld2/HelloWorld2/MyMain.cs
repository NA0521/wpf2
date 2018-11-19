using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelloWorld2
{
    class MyMain
    {
        [STAThread]
        public static void Main()
        {
            Window mainWindow = new Window();
            mainWindow.Title = "WPF Sample(Main)";
            mainWindow.MouseDown += WinMouseDown;
            // mainWindow.Show();

            for (int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                win.ShowInTaskbar = false;
                win.Owner = mainWindow;
                win.Show();
            }

            Application app = new Application();
            app.Run(mainWindow);
        }
        
        static void WinMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window win = new Window();
            win.Title = "Modal DialogBox";
            win.Width = 400;
            win.Height = 200;

            Button b = new Button();
            b.Content = "Click Me!";
            b.Click += B_Click;

            win.Content = b;
            win.ShowDialog();
        }

        static void B_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Click", sender.ToString());
        }
    }
}
