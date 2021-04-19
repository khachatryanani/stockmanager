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
    /// Interaction logic for InStockView.xaml
    /// </summary>
    public partial class InStockView : UserControl
    {
        public InStockView()
        {
            InitializeComponent();
            UpdateViewSource();
        }

        private void AddNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewItemSection.Visibility = Visibility.Visible;
            ViewItemDetailsSection.Visibility = Visibility.Hidden;

            var productList = InStockViewModel.GetProducts();
            ProductsCombo.ItemsSource = productList;

            var workerList = InStockViewModel.GetWorkers();
            WorkersCombo.ItemsSource = workerList;
        }

        private void ViewDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InStockListView.SelectedItem != null)
            {
                ViewItemDetailsSection.Visibility = Visibility.Visible;
                CreateNewItemSection.Visibility = Visibility.Hidden;

                var item = InStockListView.SelectedItem as StockItemModel;
                var details = InStockViewModel.GetStockItemDetails(item.Id);
                InStockItemDetailsListView.ItemsSource = details;

                ProductIdLabel.Content = item.Id;
                ProductNameLabel.Content = item.Name;
                ProductTypeLabel.Content = item.Type;
                ProductMUnitLabel.Content = item.MeasurementUnit;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateNewItemSection.Visibility = Visibility.Hidden;
            ViewItemDetailsSection.Visibility = Visibility.Hidden;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            StockItemDetailedModel newStockItem = new StockItemDetailedModel
            {
                ProductId = (ProductsCombo.SelectedItem as ProductModel).ProductId,
                ProductName = (ProductsCombo.SelectedItem as ProductModel).Name,
                Quantity = Convert.ToInt32(QuantityTextBox.Text),
                UnitPrice = Convert.ToDouble(UnitPriceTextBox.Text),
                ProductionDate = ProductionDatePicker.ToString(),
                WorkerId = (WorkersCombo.SelectedItem as WorkerModel).WorkerId
            };

            InStockViewModel.AddNewItem(newStockItem);

            UpdateViewSource();
            AlertSuccess();
        }

        private void UpdateViewSource()
        {
            var stockItemList = InStockViewModel.GetStockItems();
            InStockListView.ItemsSource = stockItemList;

            CreateNewItemSection.Visibility = Visibility.Hidden;
            ViewItemDetailsSection.Visibility = Visibility.Hidden;
        }

        private void AlertSuccess() 
        {
            MessageWindow window = new MessageWindow();
            window.Show();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewItemSection.Visibility = Visibility.Hidden;
        }
    }
}
