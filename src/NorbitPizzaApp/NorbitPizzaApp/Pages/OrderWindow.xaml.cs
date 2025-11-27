using NorbitPizzaApp.Classes.Model;
using NorbitPizzaApp.Classes.ModelsDto;
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
using System.Windows.Shapes;

namespace NorbitPizzaApp.Pages
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        List<PartialProductBasketClass> _listProducts = new();
        public OrderWindow(List<PartialProductBasketClass> listProducts, decimal totalSum)
        {
            InitializeComponent();
            _listProducts = listProducts;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderControl.ItemsSource = _listProducts;
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbAddress.Text) || string.IsNullOrWhiteSpace(TbName.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            Order order = new Order()
            {
                Address = TbAddress.Text,
                Name = TbName.Text,
                Comment = TbComment.Text,
                LastName = TbLastName.Text
            };
        }















        //public decimal Total { get; set; }
        //private int _basketId = 1;
        //private readonly NorbitPizzaContext _context = new NorbitPizzaContext();
        //public OrderPage()
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    LoadOrder();
        //    LoadPaymentMethods();
        //}

        //private void LoadOrder()
        //{
        //    var items = _context.ProductOrders
        //        .Where(po => po.BasketId == _basketId)
        //        .Select(po => new
        //        {
        //            Name = po.Product.ProductName,
        //            Count = po.Count,
        //            Price = po.Product.BasePrice,
        //            Total = po.Product.BasePrice * po.Count
        //        })
        //        .ToList();

        //    OrderControl.ItemsSource = items;

        //    Total = items.Sum(i => i.Total);
        //}

        //private void LoadPaymentMethods()
        //{
        //    var methods = _context.PaymentMethods.ToList();
        //    PaymentMethodsControl.ItemsSource = methods;
        //}
    }
}
