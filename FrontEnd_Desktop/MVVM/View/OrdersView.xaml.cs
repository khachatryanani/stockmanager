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
using DataAccess;
using FrontEnd_Desktop.MVVM.Model;
using FrontEnd_Desktop.MVVM.ViewModel;

namespace FrontEnd_Desktop.MVVM.View
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
       
        public OrdersView()
        {
            InitializeComponent();
          

            //var ordersList = OrderViewModel.GetOrders();
            //OrdersListView.ItemsSource = ordersList;

        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            TopCloseButton.Visibility = Visibility.Visible;
            BottomCloseButton.Visibility = Visibility.Hidden;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            TopCloseButton.Visibility = Visibility.Hidden;
            BottomCloseButton.Visibility = Visibility.Hidden;
        }

        private void ViewDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersListView.SelectedItem != null)
            {
                BottomCloseButton.Visibility = Visibility.Visible;
                TopCloseButton.Visibility = Visibility.Hidden;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersListView.UnselectAll();
        }
    

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
           // ComboBox combo = new ComboBox();
           // OrderItemsStack.Children.Add(combo);
           // combo.VerticalAlignment = VerticalAlignment.Top;
           // combo.HorizontalAlignment = HorizontalAlignment.Left;
           // combo.Height = 30;
           // combo.Width = 145;
           // combo.ItemsSource = OrderViewModel.GetProducts();
           //combo.Margin = new Thickness(combo.Margin.Left,
           //                              combo.Margin.Top + 10, 0, 0);
           

           // TextBox textbox = new TextBox();
           // OrderItemsStack.Children.Add(textbox);
           // textbox.VerticalAlignment = VerticalAlignment.Top;
           // textbox.HorizontalAlignment = HorizontalAlignment.Left;
           // textbox.VerticalContentAlignment = VerticalAlignment.Center;
           // textbox.HorizontalContentAlignment = HorizontalAlignment.Right;
           // textbox.Height = 30;
           // textbox.Width = 45;
           // textbox.Margin = new Thickness(QuantityTetxtBox.Margin.Left,
           //                             textbox.Margin.Top - 30, 0, 0);
          
        }

      
    }

}
