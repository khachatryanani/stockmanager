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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DesktopDesign.MVVM.Model;

namespace DesktopDesign.MVVM.View
{
    /// <summary>
    /// Interaction logic for TransactionsView.xaml
    /// </summary>
    public partial class InStockView : UserControl
    {
        public InStockView()
        {
            InitializeComponent();
            string connectionString = @"Data Source=SQL5103.site4now.net;Initial Catalog=DB_A719F9_Hstock;User Id=DB_A719F9_Hstock_admin;Password=hamsterstock21";
            DataRepository dataRep = new DataRepository(connectionString);

            var itemlist = dataRep.GetInStockItems();
            InStockListView.DataContext = new StockItem();
            InStockListView.ItemsSource = itemlist;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
