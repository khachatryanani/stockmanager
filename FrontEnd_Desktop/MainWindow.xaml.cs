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
using DataAccess;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Media;

namespace FrontEnd_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataRepository dataRepository;

        public MainWindow()
        {
            InitializeComponent();

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString;
            dataRepository = new DataRepository(sqlConnectionString);
        }

        //Stock Items
        private void CreateNewStockItemBtn_Click(object sender, RoutedEventArgs e)
        {
            NewStockItemWindow stockItemWindow = new NewStockItemWindow(dataRepository);

            if (stockItemWindow.ShowDialog() == true)
            {
                NewStockItem stockItem = stockItemWindow.StockItem;

                dataRepository.CreateNewStockItem(stockItem);

                MessageBox.Show("Successfully created");
            }
        }

        private void ViewStockItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            var stockItems = dataRepository.GetInStockItems();
            InStockDataGrid.ItemsSource = stockItems;

            ViewStockItemsBtn.Content = "Refresh View";
            InStockItemDetailDataGrid.Visibility = Visibility.Hidden;
        }

        private void InStockDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewStockItemDetailsBtn.IsEnabled = true;
        }

        private void ViewStockItemDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = InStockDataGrid.SelectedItem as InStockItem;
            var inStockedItemDetails = dataRepository.GetStockedProductDetails(selectedItem.ProductId);

            InStockItemDetailDataGrid.Visibility = Visibility.Visible;
            InStockItemDetailDataGrid.ItemsSource = inStockedItemDetails;
        }

        // Orders
        private void CreateNewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow(dataRepository);
            if (newOrderWindow.ShowDialog() == true)
            {
                NewOrder order = newOrderWindow.OrderItem;
                dataRepository.CreateNewOrder(order);

                MessageBox.Show("Successfully created");
            }
        }

        private void ViewOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            var orders = dataRepository.GetOrders();
            OrdersDataGrid.ItemsSource = orders;

            ViewOrdersBtn.Content = "Refresh View";
            OrderDetailDataGrid.Visibility = Visibility.Hidden;
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewOrderDetailsBtn.IsEnabled = true;
            AcceptOrderBtn.IsEnabled = true;
        }

        private void ViewOrderDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as Order;
            var orderDetails = dataRepository.GetOrderDetails(selectedOrder.OrderId);

            OrderDetailDataGrid.Visibility = Visibility.Visible;
            OrderDetailDataGrid.ItemsSource = orderDetails;
        }

        private void AcceptOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = OrdersDataGrid.SelectedItem as Order;

            dataRepository.AcceptOrder(selectedOrder.OrderId);
        }

        // Delivery Ready Orders
        private void ViewDeliveryReadyOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            var deliveryReadyorders = dataRepository.GetDeliveryReadyOrders();
            DeliveryReadyOrdersDataGrid.ItemsSource = deliveryReadyorders;

            ViewDeliveryReadyOrdersBtn.Content = "Refresh View";
        }

        private void DeliveryReadyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApproveDeliveryBtn.IsEnabled = true;
        }

        private void ApproveDeliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = DeliveryReadyOrdersDataGrid.SelectedItem as Order;
            int orderId = selectedOrder.OrderId;
            DateTime deliveryDate = DateTime.Now;

            //using default Id now, to be changed when [admin user] is implemented
            int delivereId = 101;

            dataRepository.ApproveDelivery(orderId, deliveryDate, delivereId);
        }

        // Delivered Orders
        private void ViewDeliveredOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            var deliveredOrders = dataRepository.GetDeliveredOrders();

            DeliveredOrdersDataGrid.ItemsSource = deliveredOrders;
            ViewDeliveredOrdersBtn.Content = "Refresh View";
        }

        //General
        private void HamsterMainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            InStockDataGrid.UnselectAll();
            ViewStockItemDetailsBtn.IsEnabled = false;

            OrderDetailDataGrid.UnselectAll();
            ViewOrderDetailsBtn.IsEnabled = false;

            DeliveryReadyOrdersDataGrid.UnselectAll();
            ViewDeliveryReadyOrderDetailsBtn.IsEnabled = false;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(DataAccess.ColumnNameAttribute)] as DataAccess.ColumnNameAttribute;
            if (att != null)
            {
                e.Column.Header = att.Name;
            }
        }

        private void TransactionsMenu_Click(object sender, RoutedEventArgs e)
        {
            TransactionsGrid.Visibility = Visibility.Visible;
            TransactionsMenu.Foreground = Brushes.LightGray;
        }
    }
}
