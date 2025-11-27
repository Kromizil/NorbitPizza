using NorbitPizzaApp.Classes.BusinessLogic;
using NorbitPizzaApp.Classes.Model;
using NorbitPizzaApp.Classes.ModelsDto;
using NorbitPizzaApp.Pages;
using System.Collections.ObjectModel;
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
        public ObservableCollection<ProductDto> _ChangebleProduct { get; } = new ObservableCollection<ProductDto>();
        public ObservableCollection<CategoryDto> _Categories { get; } = new ObservableCollection<CategoryDto>();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

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

        private void FormatRadioBtn_Checked(object sender, RoutedEventArgs e)
        {

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
            ProductItemsControl.ItemsSource = _Product.ToList();
        }

        private void Ingridients()
        {
            var inggridients = _Ingredient.ToList();
            ListIngridients.ItemsSource = inggridients;
        }

        private void RbBasket_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }

        //private Product _currentProduct;
        //private readonly NorbitPizzaContext _context = new NorbitPizzaContext();
        //public MainPage()
        //{
        //    InitializeComponent();
        //    LoadCategories();
        //    //   LoadIngredients();
        //    Ingridients();
        //    LoadProduct();
        //}

        //private void Ingridients()
        //{
        //    using (var context = new NorbitPizzaContext())
        //    {
        //        var inggridients = context.Ingredients.ToList();
        //        //inggridients.Insert(0, new Ingredient { IngredientId = 0, IngredientName = "Выберите категорию" });
        //        ListIngridients.ItemsSource = inggridients;
        //        // ListIngridients.SelectedIndex = 0; // по умолчанию выбран первый
        //    }
        //}

        //private void LoadProduct()
        //{
        //    ProductItemsControl.ItemsSource = _context.Products.ToList();
        //}

        //private void LoadCategories()
        //{
        //    CategoriesItemsControl.ItemsSource = _context.Categories.ToList();
        //}

        //private void LoadIngredients()
        //{

        //    if (IngredientsItemsControl.ItemsSource == null)
        //        IngredientsItemsControl.ItemsSource = CurrentIngr;


        //}

        //private void RadioButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //ObservableCollection<Ingredient> CurrentIngr = new ObservableCollection<Ingredient>();
        //private void ListIngridients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count == 0)
        //        return;

        //    Ingredient ingredient = e.AddedItems[0] as Ingredient;
        //    if (ingredient == null)
        //        return;

        //    if (!CurrentIngr.Contains(ingredient))
        //    {
        //        CurrentIngr.Add(ingredient);
        //        LoadIngredients();
        //    }
        //}

        //private void ListIngridients_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{

        //}

        //private void OpenProductBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    

        //    
        //    
        //    
        //    
        //    
        //    

        //    
        //    
        //    
        //    

        //    
        //    
        //    
        //    
        //}

        //private PizzaFormat _selectedFormat;
        //private void FormatRadioBtn_Checked(object sender, RoutedEventArgs e)
        //{
        //    _selectedFormat = (sender as RadioButton)?.DataContext as PizzaFormat;

        //    if (_selectedFormat != null)
        //        WeightTextBlock.Text = $"Вес: {_selectedFormat.Weight} г";
        //}
    }
}