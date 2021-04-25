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
        }

        private void AddNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            TopCloseButton.Visibility = Visibility.Visible;
            BottomCloseButton.Visibility = Visibility.Hidden;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            TopCloseButton.Visibility = Visibility.Hidden;
            BottomCloseButton.Visibility = Visibility.Hidden;
        }

        private void ViewDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InStockListView.SelectedItem != null) 
            {
                BottomCloseButton.Visibility = Visibility.Visible;
                TopCloseButton.Visibility = Visibility.Hidden;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InStockListView.UnselectAll();
        }
    }
}