using NorbitPizzaApp.Classes.Model;
using NorbitPizzaApp.Classes.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.ApiLogic
{
    public static  class ApiService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7084")
        };

        public static Task<List<Product>> GetProductsAsync()
        {
            return client.GetFromJsonAsync<List<Product>>("/Pizza");
        }

        public static Task<List<Ingredient>> GetIngredientsAsync()
        {
            return client.GetFromJsonAsync<List<Ingredient>>("/Ingredients");
        }

        public static Task<List<Ingredient>> GetProductIngredientAsync(int ProductNum)
        {
            return client.GetFromJsonAsync<List<Ingredient>>($"/Ingredients/{ProductNum}");
        }

        public static Task<List<CategoryDto>> GetCategorysAsync()
        {
            return client.GetFromJsonAsync<List<CategoryDto>>($"/Categories");
        }

        public static Task<List<CategoryDto>> GetCategorysProductAsync(int ProductNum)
        {
            return client.GetFromJsonAsync<List<CategoryDto>>($"/Categories/{ProductNum}");
        }

        public static Task<List<FormatDTO>> GetFormatProductAsync(int ProductNum)
        {
            return client.GetFromJsonAsync<List<FormatDTO>>($"/PizzaFormat/{ProductNum}");
        }
        //public static Task<Order> PostOrderAsync(Order order)
        //{
        //    return client.PostAsJsonAsync("/Orders", order)
        //                 .ContinueWith(responseTask =>
        //                 {
        //                     var response = responseTask.Result;
        //                     response.EnsureSuccessStatusCode();
        //                     return response.Content.ReadFromJsonAsync<Order>();
        //                 }).Unwrap();
        //}
    }
}
