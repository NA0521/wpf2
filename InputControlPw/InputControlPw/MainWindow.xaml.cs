using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InputControlPw
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InputMethod.SetIsInputMethodEnabled(this, false);
        }

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            Key inputKey = e.Key.Equals(Key.ImeProcessed) ? e.ImeProcessedKey : e.Key;
            if (inputKey == Key.Escape) Close();
        }

        private void txt2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txt2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
