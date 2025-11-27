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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListIngridients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OpenProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FormatRadioBtn_Checked(object sender, RoutedEventArgs e)
        {

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
        //    var product = (sender as Button)?.Tag as Product;

        //    _currentProduct = _context.Products
        //        .Include(p => p.PizzaFormats)
        //        .ThenInclude(pf => pf.Format)
        //        .Include(p => p.ProductIngredients)
        //        .ThenInclude(pi => pi.Ingredient)
        //        .FirstOrDefault(p => p.ProductId == product.ProductId);

        //    if (_currentProduct != null)
        //    {
        //        DetailPanel.DataContext = _currentProduct;
        //        FormatsItemsControl.ItemsSource = _currentProduct.PizzaFormats;

        //        // выбрать первый формат
        //        _selectedFormat = _currentProduct.PizzaFormats.FirstOrDefault();
        //        WeightTextBlock.Text = $"Вес: {_selectedFormat?.Weight ?? 0} г";
        //    }
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