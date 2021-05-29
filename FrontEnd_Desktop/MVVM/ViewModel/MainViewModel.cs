using DataAccess;
using FrontEnd_Desktop.Core;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class MainViewModel: ObservableObject
    {
        private object _currentView;

        //commands
        public RelayCommand InStockViewCommand { get; set; }
        public RelayCommand OrderViewCommand { get; set; }
        public RelayCommand TempViewCommand { get; set; }

        //ViewModels
        public StockViewModel InStockVM { get; set; }
        public OrdersViewModel OrderVM { get; set; }
        public TemporaryViewModel TempVM { get; set; }

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
            TempVM = new TemporaryViewModel();

            CurrentView = InStockVM;

            InStockViewCommand = new RelayCommand(o =>
            {
                CurrentView = InStockVM;
               
            });

            OrderViewCommand = new RelayCommand(o =>
            {
                CurrentView = OrderVM;
            });

            TempViewCommand = new RelayCommand(o =>
            {
                CurrentView = TempVM;
            });
        }
    }
}
