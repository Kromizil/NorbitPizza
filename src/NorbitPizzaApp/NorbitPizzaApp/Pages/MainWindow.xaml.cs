using NorbitPizzaApp.Classes.BusinessLogic;
using NorbitPizzaApp.Classes.Model;
using NorbitPizzaApp.Classes.ModelsDto;
using NorbitPizzaApp.Pages;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace NorbitPizzaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly DataRepository _repository = new();

        public ObservableCollection<Ingredient> _Ingredient { get; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<ProductDto> _Product { get; } = new ObservableCollection<ProductDto>();
        public ObservableCollection<ProductDto> _ChangebleProduct { get; set; } = new ObservableCollection<ProductDto>();
        public ObservableCollection<CategoryDto> _Categories { get; } = new ObservableCollection<CategoryDto>();


        private CategoryDto _selectedCategory;

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                ApplyFilter();
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void SetSelectedCategory(CategoryDto category)
        {
            _selectedCategory = category;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (ProductItemsControl == null)
                return;

            var filtered = _Product.Where(p =>
            {
                if (_selectedCategory != null &&
                    !string.Equals(_selectedCategory.CategoryName, "Все", StringComparison.OrdinalIgnoreCase))
                {
                    if (p.Categories == null ||
                        !p.Categories.Any(ct => string.Equals(ct.CategoryName, _selectedCategory.CategoryName, StringComparison.OrdinalIgnoreCase)))
                    {
                        return false;
                    }
                }

                if (!string.IsNullOrWhiteSpace(SearchQuery))
                {
                    if (string.IsNullOrEmpty(p.ProductName) ||
                        p.ProductName.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        return false;
                    }
                }

                if (CurrentIngr != null && CurrentIngr.Count > 0)
                {
                    if (p.Ingredients == null)
                        return false;

                    bool allIngredientsPresent = CurrentIngr.All(ci =>
                        p.Ingredients.Any(pi => pi.IngredientId == ci.IngredientId));
                    if (!allIngredientsPresent)
                        return false;
                }

                return true;
            });

            _ChangebleProduct.Clear();
            foreach (var item in filtered)
                _ChangebleProduct.Add(item);

            ProductItemsControl.ItemsSource = _ChangebleProduct;
        }


        ObservableCollection<Ingredient> CurrentIngr = new ObservableCollection<Ingredient>();
        private void ListIngridients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;

            Ingredient ingredient = e.AddedItems[0] as Ingredient;
            if (ingredient == null)
                return;

            if (!CurrentIngr.Contains(ingredient))
            {
                CurrentIngr.Add(ingredient);
                LoadIngredients();
                ApplyFilter();
            }
        }
        private void LoadIngredients()
        {

            if (IngredientsItemsControl.ItemsSource == null)
                IngredientsItemsControl.ItemsSource = CurrentIngr;

        }

        private void OpenProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var product = button.DataContext as ProductDto;
            if (product == null) return;

            DetailPanel.DataContext = product;
            DetailPanel.Visibility = Visibility.Visible;

        }

        FormatDTO SelectedFormat = new FormatDTO();
        private void FormatRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            SelectedFormat = (sender as RadioButton).DataContext as FormatDTO;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = await _repository.LoadDataAsync();

            _Product.Clear();
            foreach (var pizza in data.Pizzas)
                _Product.Add(pizza);

            _Ingredient.Clear();
            foreach (var ingrid in data.Ingredients)
                _Ingredient.Add(ingrid);

            _Categories.Clear();
            foreach (var categorys in data.Category)
                _Categories.Add(categorys);

            _Categories.Add(new CategoryDto { CategoryName = "Все" });

            LoadProduct();
            Ingridients();
            LoadCategory();
        }

        private void LoadCategory()
        {
            CategoriesItemsControl.ItemsSource = _Categories.ToList();
        }

        private void LoadProduct()
        {
            _ChangebleProduct.Clear();
            foreach (var item in _Product)
                _ChangebleProduct.Add(item);
            ProductItemsControl.ItemsSource = _ChangebleProduct;
        }

        private void Ingridients()
        {
            var inggridients = _Ingredient.ToList();
            ListIngridients.ItemsSource = inggridients;
        }

        private void RbBasket_Click(object sender, RoutedEventArgs e)
        {
            if(basketClass == null)
            {
                MessageBox.Show("Выберите продукт из списка!");
            }
            OrderWindow orderWindow = new OrderWindow(basketClass, _totalSum);
            orderWindow.ShowDialog();
        }

        private void RbIngridientDel_Click(object sender, RoutedEventArgs e)
        {
            CurrentIngr.Remove((sender as RadioButton).DataContext as Ingredient);
            LoadIngredients();
            ApplyFilter();
        }

        private void RbSelectCategory_Click(object sender, RoutedEventArgs e)
        {
            var category = (sender as RadioButton)?.DataContext as CategoryDto;
            if (category != null)
            {
                SetSelectedCategory(category);
            }
        }
        private decimal _totalSum = 0;
        private List<PartialProductBasketClass> basketClass = new List<PartialProductBasketClass>();
        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {

            if(SelectedFormat  == null)
            {
                MessageBox.Show("Вы не выбрали формат!");
                return;
            }

            var selectedProduct = (sender as Button).DataContext as ProductDto;

            basketClass.Add(new PartialProductBasketClass()
            {
                ProductId = selectedProduct.ProductId,
                ProductName = selectedProduct.ProductName,
                Format = SelectedFormat
            });


            decimal totalSum = 0;
            foreach (var basket in basketClass) 
            {
                totalSum += basket.Format.CalculatedPrice;
            }
            _totalSum = totalSum;
            TotalSumTb.Text = $"{Math.Round(totalSum, 0)} р.";
        }
    }
}