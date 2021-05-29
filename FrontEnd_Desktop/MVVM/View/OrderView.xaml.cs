using FrontEnd_Desktop.MVVM.Model;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderItem = new OrderItemDTO();
            OrdersViewModel.Order.OrderItems.Add(orderItem);
            ComboBox combo = new ComboBox();
            OrderItemsStack.Children.Add(combo);
            combo.VerticalAlignment = VerticalAlignment.Top;
            combo.HorizontalAlignment = HorizontalAlignment.Left;
            combo.Height = 30;
            combo.Width = 145;
            combo.ItemsSource = ProductsCombo.ItemsSource;
            combo.Margin = new Thickness(combo.Margin.Left,
                                          combo.Margin.Top + 10, 0, 0);

            TextBox textbox = new TextBox();
            OrderItemsStack.Children.Add(textbox);
            textbox.VerticalAlignment = VerticalAlignment.Top;
            textbox.HorizontalAlignment = HorizontalAlignment.Left;
            textbox.VerticalContentAlignment = VerticalAlignment.Center;
            textbox.HorizontalContentAlignment = HorizontalAlignment.Right;
            textbox.Height = 30;
            textbox.Width = 45;
            textbox.Text = QuantityTetxtBox.Text;
            textbox.Margin = new Thickness(QuantityTetxtBox.Margin.Left,
                                        textbox.Margin.Top - 30, 0, 0);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = OrderItemsStack.Children;
            var list = OrdersViewModel.Order.OrderItems;
            AlertSuccess();
        }

        private void AlertSuccess()
        {
            MessageWindow window = new MessageWindow();
            window.Show();
        }
    }
}
