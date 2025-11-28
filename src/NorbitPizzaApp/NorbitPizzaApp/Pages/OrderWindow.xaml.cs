using NorbitPizzaApp.Classes.ApiLogic;
using NorbitPizzaApp.Classes.Model;
using NorbitPizzaApp.Classes.ModelsDto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        decimal _price = 0;
        private PaymentMethodDto currentMethod = new();

        public OrderWindow(List<PartialProductBasketClass> listProducts, decimal totalSum, List<PaymentMethodDto> paymentMethods)
        {
            InitializeComponent();
            _listProducts = listProducts;
            _price = totalSum;
            TotalPriceTb.Text = $"{Math.Round(totalSum, 2)} р.";
            PaymentMethodsControl.ItemsSource = paymentMethods.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OrderControl.ItemsSource = _listProducts;
        }

        private async void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbAddress.Text) || string.IsNullOrWhiteSpace(TbName.Text) || string.IsNullOrWhiteSpace(TbPhone.Text) || currentMethod.PaymentMethodId == 0)
            {
                MessageBox.Show("Заполните все поля!");
            }
            Order order = new Order()
            {
                Address = TbAddress.Text,
                Name = TbName.Text,
                Comment = TbComment.Text,
                LastName = TbLastName.Text,
                Phone = TbPhone.Text,
                CreatedAt = DateTime.Now,
                IsPickup = CbIsPickUp.IsChecked,
                TotalPrice = Convert.ToDouble(_price),
                PaymentMethod = currentMethod.PaymentMethodId
            };

            var createdOrder = await ApiService.PostOrderAsync(order);


            foreach (var product in _listProducts)
            {
                ApiService.PostProductOrderAsync(new ProductOrder()
                {
                    BasketId = createdOrder.OrderId,
                    ProductId = product.ProductId,
                    Count = 1
                });
            }

            this.Close();


        }

        private void BtnDelProd_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as PartialProductBasketClass;
            _listProducts.Remove(product);
            OrderControl.ItemsSource = _listProducts;
            OrderControl.Items.Refresh();
            _price -= product.Format.CalculatedPrice;
            TotalPriceTb.Text = $"{Math.Round(_price, 2)} р.";

        }


        private void RbPayment_Checked(object sender, RoutedEventArgs e)
        {
            currentMethod = (sender as RadioButton).DataContext as PaymentMethodDto;
        }



    }
}
