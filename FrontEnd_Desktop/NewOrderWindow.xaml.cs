using DataAccess;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FrontEnd_Desktop
{
    /// <summary>
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        //For Combobox dropdowns
        private readonly List<Product> products;
        private readonly List<Worker> workers;
        private readonly List<Customer> customers;

        private readonly List<Product> productsOfOrder;
        public NewOrder OrderItem { get; set; }

        private static double newItemsTopMargin;

        private readonly DataRepository dataRepository;

        public NewOrderWindow(DataRepository dataRepository)
        {
            InitializeComponent();

            this.dataRepository = dataRepository;

            productsOfOrder = new List<Product>();
            products = this.dataRepository.GetProductsList();
            workers = this.dataRepository.GetWorkersList();
            customers = this.dataRepository.GetCustomersList();

            foreach (var item in products)
            {
                ProductsCombo.Items.Add((object)(item.Name + " (" + item.Unit + ")"));
            }

            foreach (var item in workers)
            {
                WorkersCombo.Items.Add((object)(item.Name + " " + item.Surname));
            }

            foreach (var item in customers)
            {
                CustomerCombo.Items.Add(item.CustomerId);
            }

            newItemsTopMargin = ProductsCombo.Margin.Top + ProductsCombo.Height + 5;
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            ComboBox productsCombo = new ComboBox
            {
                Margin = new Thickness(ProductsCombo.Margin.Left, newItemsTopMargin, 0, 0),
                VerticalAlignment = ProductsCombo.VerticalAlignment,
                HorizontalAlignment = ProductsCombo.HorizontalAlignment
            };

            foreach (var item in products)
            {
                productsCombo.Items.Add((object)(item.Name + " (" + item.Unit + ")"));
            }

            productsCombo.Height = ProductsCombo.Height;
            productsCombo.Width = ProductsCombo.Width;

            TextBox quantityTextBox = new TextBox
            {
                Margin = new Thickness(QuantityTextBox.Margin.Left, newItemsTopMargin, 0, 0),
                VerticalAlignment = QuantityTextBox.VerticalAlignment,
                HorizontalAlignment = QuantityTextBox.HorizontalAlignment,
                HorizontalContentAlignment = QuantityTextBox.HorizontalContentAlignment,
                Height = QuantityTextBox.Height,
                Width = QuantityTextBox.Width,
            };


            ProductsComboBoxGrid.Children.Add(productsCombo);
            QuantityTextBoxGrid.Children.Add(quantityTextBox);


            newItemsTopMargin = productsCombo.Margin.Top + productsCombo.Height + 5;
            AddItemBtn.Margin = new Thickness(AddItemBtn.Margin.Left, AddItemBtn.Margin.Top + productsCombo.Height + 5, 0, 0);

            SeparatorLine.Margin = new Thickness(SeparatorLine.Margin.Left, SeparatorLine.Margin.Top + productsCombo.Height + 5, 0, 0);
            SubmitBtn.Margin = new Thickness(SubmitBtn.Margin.Left, SubmitBtn.Margin.Top + productsCombo.Height + 5, 0, 0);
            CancelBtn.Margin = new Thickness(CancelBtn.Margin.Left, CancelBtn.Margin.Top + productsCombo.Height + 5, 0, 0);
            NewOrderGrid.Height = NewOrderGrid.Height + productsCombo.Height + 5;
        }

        private void CreateNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrder newOrderItem = new NewOrder();

            foreach (Control control in ProductsComboBoxGrid.Children)
            {
                if (control is ComboBox)
                {
                    int productIndex = (control as ComboBox).SelectedIndex;
                    if (productIndex != -1) 
                    {
                        Product product = new Product
                        {
                            ProductId = products[productIndex].ProductId
                        };
                        productsOfOrder.Add(product);
                    }
                }
            }

            int index = 0;
            foreach (Control control in QuantityTextBoxGrid.Children)
            {
                if (control is TextBox)
                {
                    if (!string.IsNullOrEmpty((control as TextBox).Text)) 
                    {
                        productsOfOrder[index].Quantity = double.Parse((control as TextBox).Text);
                        index++;
                    }
                    
                }
            }

            newOrderItem.ProductList = productsOfOrder;
            int workerId = WorkersCombo.SelectedIndex;
            newOrderItem.ReceivedBy = workers[workerId].WorkerId;

            if (OrderDatePicker.SelectedDate.HasValue)
            {
                newOrderItem.ReceivedDate = OrderDatePicker.SelectedDate.Value;
            }

            int customerId = CustomerCombo.SelectedIndex;
            newOrderItem.CustomerId = customers[customerId].CustomerId;

            this.OrderItem = newOrderItem;

            this.DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
