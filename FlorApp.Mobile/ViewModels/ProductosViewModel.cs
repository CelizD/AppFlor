using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FlorApp.DataAccess.Models;

namespace FlorApp.Mobile.ViewModels
{
    public class ProductosViewModel
    {
        public ObservableCollection<Producto> Productos { get; set; } = new ObservableCollection<Producto>();
        private readonly HttpClient _httpClient;

        public ProductosViewModel()
        {
            var httpClientHandler = new HttpClientHandler();
#if ANDROID
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;
#endif
            _httpClient = new HttpClient(httpClientHandler);
            
        }

        public async Task CargarProductosAsync()
        {
            if (Productos.Count > 0) return;

            try
            {
                
                string apiUrl = "https://192.168.100.212:7162/api/Productos";

                var productosDesdeApi = await _httpClient.GetFromJsonAsync<List<Producto>>(apiUrl);

                if (productosDesdeApi != null)
                {
                    Productos.Clear();
                    foreach (var producto in productosDesdeApi)
                    {
                        Productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", $"No se pudo conectar a la API: {ex.Message}", "OK");
                }
            }
        }
    }
}