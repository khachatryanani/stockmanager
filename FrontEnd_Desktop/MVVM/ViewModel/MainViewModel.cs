using DataAccess;
using FrontEnd_Desktop.Core;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class MainViewModel: ObservableObject
    {
        private object _currentView;

        private readonly DataRep _dataRepository = new DataRep(ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString);
        public RelayCommand InStockViewCommand { get; set; }
        public RelayCommand OrderViewCommand { get; set; }

        public StockViewModel InStockVM { get; set; }
        public OrdersViewModel OrderVM { get; set; }

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InStockVM = new StockViewModel();
            OrderVM = new OrdersViewModel();

            CurrentView = InStockVM;

            InStockViewCommand = new RelayCommand(o =>
            {
                CurrentView = InStockVM;
               
            });

            OrderViewCommand = new RelayCommand(o =>
            {
                CurrentView = OrderVM;
            });
        }
    }
}
