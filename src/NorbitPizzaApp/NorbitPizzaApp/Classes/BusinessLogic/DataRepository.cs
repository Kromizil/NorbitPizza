using NorbitPizzaApp.Classes.ApiLogic;
using NorbitPizzaApp.Classes.ModelsDto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NorbitPizzaApp.Classes.BusinessLogic
{
    public class DataRepository
    {
        private const string CacheFilePath = "pizza_data.json";

        public async Task<DataContainer> LoadDataAsync()
        {
            if (await IsApiAvailableAsync())
            {
                var container = await LoadFromApiAsync();
                SaveToCache(container);
                return container;
            }
            else
            {
                return LoadFromCache() ?? new DataContainer();
            }
        }

        private async Task<bool> IsApiAvailableAsync()
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5066") };
                var response = await client.GetAsync("/Pizza");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private async Task<DataContainer> LoadFromApiAsync()
        {
            var products = await ApiService.GetProductsAsync();
            var ingredients = await ApiService.GetIngredientsAsync();
            var category = await ApiService.GetCategorysAsync();
            var paymentMethod = await ApiService.GetPaymentMethodsAsync();

            var pizzas = new List<ProductDto>();
            foreach (var product in products)
            {
                var relatedIngredients = await ApiService.GetProductIngredientAsync(product.ProductId);
                var relatedCategorys = await ApiService.GetCategorysProductAsync(product.ProductId);
                var relatedFormats = await ApiService.GetFormatProductAsync(product.ProductId);
                foreach (var format in relatedFormats)
                {
                    format.CalculatedPrice = product.BasePrice * (format.PriceMultiplier ?? 1m);
                }
                pizzas.Add(new ProductDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    BasePrice = product.BasePrice,
                    Comment = product.Comment,
                    Image = product.Image,
                    Title = product.Title,
                    StringIngredient = string.Join(", ", relatedIngredients.Select(p=>p.IngredientName)).ToLower(),
                    Ingredients = relatedIngredients.ToList(),
                    Categories = relatedCategorys.ToList(),
                    Formats = relatedFormats.ToList()
                });
            }

            return new DataContainer
            {
                Pizzas = pizzas,
                Ingredients = ingredients,
                Category = category,
                paymentMethod = paymentMethod
            };
        }

        private void SaveToCache(DataContainer container)
        {
            var json = JsonSerializer.Serialize(container, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CacheFilePath, json);
        }

        public  DataContainer? LoadTranslation()
        {
            if (!File.Exists("Resources\\pizza_dataCRYPTO.json")) return null;
            var json = File.ReadAllText("Resources\\pizza_dataCRYPTO.json");
            return JsonSerializer.Deserialize<DataContainer>(json);
        }

        private DataContainer? LoadFromCache()
        {
            if (!File.Exists(CacheFilePath)) return null;
            var json = File.ReadAllText(CacheFilePath);
            return JsonSerializer.Deserialize<DataContainer>(json);
        }
    }
}

