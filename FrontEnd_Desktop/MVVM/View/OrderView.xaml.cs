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

namespace FrontEnd_Desktop.MVVM.View
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();

            InitializeComponent();
            string connectionString = @"Data Source = DESKTOP-TK7OBVA\SQLEXPRESS; Initial Catalog = Hamster; Integrated Security = True";
            DataRepository dataRep = new DataRepository(connectionString);

            var itemlist = dataRep.GetOrders();
            InStockListView.DataContext = new Order();
            InStockListView.ItemsSource = itemlist;
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
        }
    }
}
