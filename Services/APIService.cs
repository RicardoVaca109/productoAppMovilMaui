using Newtonsoft.Json;
using productoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace productoApp.Services
{
    public class APIService
    {
        public static string _baseUrl;
        //public HttpClient _httpClient;
        HttpClient httpClient=new HttpClient();
        public APIService()
        {
            /*var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);*/
            _baseUrl = "https://apibodega20231205124415.azurewebsites.net";
            httpClient.BaseAddress= new Uri(_baseUrl);
        }
        public async Task<bool> DeleteProducto(int ProductoId)
        {
            var response = await httpClient.DeleteAsync($"/api/Producto/{ProductoId}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Producto> GetProducto(int ProveedorId)
        {
            var response = await httpClient.GetAsync($"/api/Producto/{ProveedorId}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return new Producto();
        }
        public async Task<List<Producto>> GetProductos()
        {
            var response = await httpClient.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return new List<Producto>();

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Producto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<Producto> PutProducto(int ProductoId, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"/api/Producto/{ProductoId}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await httpClient.GetAsync("/api/User");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<User> usuarios = JsonConvert.DeserializeObject<List<User>>(json_response);
                return usuarios;
            }
            return new List<User>();

        }

        public async Task<User> GetUser(int IdUser)
        {
            var response = await httpClient.GetAsync($"/api/User/{IdUser}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                User usuario = JsonConvert.DeserializeObject<User>(json_response);
                return usuario;
            }
            return new User();
        }

        public async Task<bool> VerificarUsuario(User userToValidate)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(userToValidate), Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync("/api/User", content);

            if (userToValidate != null)
            {
                var content = new StringContent(JsonConvert.SerializeObject(userToValidate), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/User", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var userFromServer = JsonConvert.DeserializeObject<User>(responseData);
                    if (response != null && userToValidate.UserPassword == userToValidate.UserPassword && userToValidate.UserMail == userToValidate.UserMail)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<User> PostUser(User newUser)
        {
            var content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/User/create", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                User usuario2 = JsonConvert.DeserializeObject<User>(json_response);
                return usuario2;
            }
            return new User();
        }

    }
}
