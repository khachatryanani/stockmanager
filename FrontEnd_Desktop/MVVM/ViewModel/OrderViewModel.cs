using System;
using System.Collections.Generic;
using System.Text;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using DataAccess;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class OrderViewModel: ObservableObject
    {
        private readonly DataRep _dataRepository = new DataRep(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);

        private object _rightSideView;
        private object _bottomSideView;

        public List<OrderDTO> Orders { get; set; }
        public static OrderDTO SelectedOrder { get; set; }

        public object RightSideView
        {
            get
            {
                return _rightSideView;
            }
            set
            {
                _rightSideView = value;
                OnPropertyChanged();
            }
        }

        public object BottomSideView
        {
            get
            {
                return _bottomSideView;
            }
            set
            {
                _bottomSideView = value;
                OnPropertyChanged();
            }
        }

        public OrderViewModel()
        {
            Orders = _dataRepository.GetOrders();
        }
    }
}
