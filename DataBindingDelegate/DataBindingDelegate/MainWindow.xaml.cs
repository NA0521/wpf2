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


namespace DataBindingDelegate
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Duties duties = new Duties();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSelected(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                if ((sender as ListBox).SelectedItem != null)
                {
                    string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();
                    DataContext = from duty in duties
                                  where duty.DutyType.ToString() == dutyType select duty;
                }
            }
        }

        private void OnSelected2(object sender, SelectionChangedEventArgs e)
        {
            var duty = (Duty)myListBox2.SelectedItem;
            string value = duty == null ? "No selection" : duty.ToString();
        }

        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            SubWindow subWindow = new SubWindow();

            RefreshListEvent += new RefreshList(RefreshListBox);

            subWindow.UpdateActor = RefreshListEvent;
            subWindow.Show();

            
        }

        public delegate void RefreshList(DutyType dutyType);
        public event RefreshList RefreshListEvent;

        private void RefreshListBox(DutyType dutyType)
        {
            myListBox1.SelectedItem = null;
            myListBox1.SelectedIndex = (dutyType == DutyType.Inner) ? 0 : 1;
        }
    }
}
