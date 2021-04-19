using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopDesign.Core;

namespace DesktopDesign.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public RelayCommand InStockViewCommand { get; set; }
        public RelayCommand ProductsViewCommand { get; set; }


        public InStockViewModel InStockVM { get; set; }
        public ProductsViewModel ProductsVM { get; set; }

        private object _currentView;

        public MainViewModel()
        {
            InStockVM = new InStockViewModel();
            ProductsVM = new ProductsViewModel();
            CurrentView = InStockVM;

            InStockViewCommand = new RelayCommand(o =>
            {
                CurrentView = InStockVM;
            });

            ProductsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductsVM;
            });

        }

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
    }
}
