using FrontEnd_Desktop.MVVM.ViewModel;
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
    /// Interaction logic for AddStockItemView.xaml
    /// </summary>
    public partial class StockItemView : UserControl
    {
        public StockItemView()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //var parent = VisualTreeHelper.GetParent(this);
            //(parent as Grid).Children.Remove(this);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

       
    }
}
