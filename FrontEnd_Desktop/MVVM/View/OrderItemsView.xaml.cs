using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEnd_Desktop.MVVM.View
{
    /// <summary>
    /// Interaction logic for OrderItemsView.xaml
    /// </summary>
    public partial class OrderItemsView : UserControl
    {
        public OrderItemsView()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            AlertSuccess();
        }


        private void AlertSuccess()
        {
            MessageWindow window = new MessageWindow();
            window.Show();
        }
    }
}
