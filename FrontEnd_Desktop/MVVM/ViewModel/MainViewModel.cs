using DataAccess;
using FrontEnd_Desktop.Core;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class MainViewModel: ObservableObject
    {
        private object _currentView;

        public static readonly DataRepository dataRepository = new DataRepository(ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString);
        public RelayCommand InStockViewCommand { get; set; }
        public RelayCommand OrderViewCommand { get; set; }

        public InStockViewModel InStockVM { get; set; }
        public OrderViewModel OrderVM { get; set; }

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
            InStockVM = new InStockViewModel();
            OrderVM = new OrderViewModel();

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
