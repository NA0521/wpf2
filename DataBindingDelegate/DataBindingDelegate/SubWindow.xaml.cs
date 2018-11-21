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
using System.Windows.Shapes;

namespace DataBindingDelegate
{
    /// <summary>
    /// SubWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubWindow : Window
    {
        public Delegate UpdateActor;

        public SubWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(rdoInner.IsChecked == false && rdoOutside.IsChecked == false)
            {
                MessageBox.Show("inner outside check");
                return;
            }

            DutyType dutyType = (rdoInner.IsChecked == true) ? DutyType.Inner : DutyType.OutSide;
            MainWindow.duties.Add(new Duty(txtDutyName.Text, dutyType));

            UpdateActor.DynamicInvoke(dutyType);

            MessageBox.Show("Save Ok");
            this.Close();

        }
    }
}
