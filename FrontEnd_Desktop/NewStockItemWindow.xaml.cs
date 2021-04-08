using DataAccess;
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
using System.Windows.Shapes;
using System.Configuration;

namespace FrontEnd_Desktop
{
    /// <summary>
    /// Interaction logic for NewStockItem.xaml
    /// </summary>
    public partial class NewStockItemWindow : Window
    {
        //For Combobox dropdowns
        private readonly List<Product> products;
        private readonly List<Worker> workers;

        private readonly DataRepository dataRepository;

        public NewStockItem StockItem { get; set; }
        public NewStockItemWindow(DataRepository dataRepository)
        {
            InitializeComponent();

            this.dataRepository = dataRepository;

            products = dataRepository.GetProductsList();
            workers = dataRepository.GetWorkersList();

            foreach (var item in products)
            {
                ProductsCombo.Items.Add((object)(item.Name + " (" + item.Unit + ")"));
            }

            foreach (var item in workers)
            {
                WorkersCombo.Items.Add((object)(item.Name + " " + item.Surname));
            }
        }

        private void CreateNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            StockItem = new NewStockItem
            {
                ProductId = GetSelectedProductId()
            };

            if (ProductionDatePicker.SelectedDate.HasValue) 
            {
                StockItem.ProductionDate = ProductionDatePicker.SelectedDate.Value;
            }

            StockItem.StockedDate = DateTime.Now;
            StockItem.Quantity = int.Parse(QuantityTextBox.Text);
            StockItem.Price = decimal.Parse(UnitPriceTextBox.Text);
            StockItem.WorkerId = GetSelectedWorkerId();

            this.DialogResult = true;
            Close();
        }

        private int GetSelectedProductId() 
        {
            int id = ProductsCombo.SelectedIndex;
            return products[id].ProductId;
        }

        private int GetSelectedWorkerId() 
        {
            int id = WorkersCombo.SelectedIndex;
            return workers[id].WorkerId;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
