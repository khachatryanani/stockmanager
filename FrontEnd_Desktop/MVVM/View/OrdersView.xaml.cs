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


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateNewOrderSection.Visibility = Visibility.Hidden;
            VieworderDetailsSection.Visibility = Visibility.Hidden;
        }

        private void ViewDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrderSection.Visibility = Visibility.Hidden;
            VieworderDetailsSection.Visibility = Visibility.Visible;
        }

        private void CreateNewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrderSection.Visibility = Visibility.Visible;
            VieworderDetailsSection.Visibility = Visibility.Hidden;

            //var products = OrderViewModel.GetProducts();
            //ProductsCombo.ItemsSource = products;

            //var workers = OrderViewModel.GetWorkers();
            //WorkersCombo.ItemsSource = workers;

            //var customers = OrderViewModel.GetCustomers();
            //CustomersCombo.ItemsSource = customers;

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

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //List<OrderItemDTO> orderItems = new List<OrderItemDTO>();

            //for (int i = 0; i < OrderItemsStack.Children.Count; i++)
            //{
            //    if (OrderItemsStack.Children[i] is ComboBox) 
            //    {
            //        var productId = ((OrderItemsStack.Children[i] as ComboBox).SelectedItem as ProductDTO).ProductId;
            //        orderItems.Add(new OrderItemDTO { ProductId = productId });
            //    }

            //    if (OrderItemsStack.Children[i] is TextBox)
            //    {
            //        orderItems[orderItems.Count - 1].Quantity = Convert.ToInt32((OrderItemsStack.Children[i] as TextBox).Text);
            //    }

            //}

            //var order = new OrderDTO
            //{
            //    CustomerId = (CustomersCombo.SelectedItem as CustomerDTO).CustomerId,
            //    ReceivedDate = OrderDatePicker.Text,
            //    ReceivedById = (WorkersCombo.SelectedItem as WorkerDTO).WorkerId,
            //    OrderItemList = orderItems
            //};

            //OrderViewModel.CreateNewOrder(order);
            UpdateViewSource();
            AlertSuccess();
        }

        private void UpdateViewSource()
        {
            //var ordersList = OrderViewModel.GetOrders();
            //OrdersListView.ItemsSource = ordersList;

            CreateNewOrderSection.Visibility = Visibility.Hidden;
            VieworderDetailsSection.Visibility = Visibility.Hidden;
        }

        private void AlertSuccess()
        {
            MessageWindow window = new MessageWindow();
            window.Show();
        }

    }

}
