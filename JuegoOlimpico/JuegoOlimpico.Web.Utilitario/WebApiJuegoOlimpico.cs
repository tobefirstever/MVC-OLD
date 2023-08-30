using JuegoOlimpico.Web.Dto.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JuegoOlimpico.Web.Utilitario
{
    public class WebApiJuegoOlimpico
    {
        private readonly string apiJuegosOlimpicos = System.Configuration.ConfigurationManager.AppSettings["UrlWebApiJuegoOlimpico"];

        public async Task<string> EnviarPeticionPost<T>(T entity, string url, string token)
        {
            string jsonText = string.Empty;
            HttpResponseMessage response;
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                jsonText = JsonConvert.SerializeObject(entity);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                request.Content = new StringContent(jsonText);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }



            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> EnviarPeticionPut<T>(T entity, string url, string token)
        {
            string jsonText = string.Empty;
            HttpResponseMessage response;

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                jsonText = JsonConvert.SerializeObject(entity);
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                request.Content = new StringContent(jsonText);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }



            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> EnviarPeticionDelete<T>(T entity, string url, string token)
        {
            string jsonText = string.Empty;
            HttpResponseMessage response;

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                jsonText = JsonConvert.SerializeObject(entity);
                var request = new HttpRequestMessage(HttpMethod.Delete, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                request.Content = new StringContent(jsonText);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> EnviarPeticionDelete(string url, string token)
        {
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                var response = await _httpClient.DeleteAsync(url);


                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();

            }
        }

        public async Task<string> EnviarPeticionGet(string url, string token)
        {
            HttpResponseMessage response;

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }




            return await response.Content.ReadAsStringAsync();
        }

        public async Task<LoginResponseDto> ObtenerToken<T>(T entity, string url)
        {
            string jsonText = string.Empty;
            //_httpClient.BaseAddress = new Uri(apiPantallas);
            //_httpClient.Timeout = new TimeSpan(0, 30, 0);
            //_httpClient.DefaultRequestHeaders.Clear();

            using (var _httpClient = new HttpClient())
            {

                _httpClient.BaseAddress = _httpClient.BaseAddress ?? new Uri(apiJuegosOlimpicos);
                _httpClient.Timeout = new TimeSpan(0, 30, 0);
                _httpClient.DefaultRequestHeaders.Clear();

                jsonText = JsonConvert.SerializeObject(entity);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                request.Content = new StringContent(jsonText);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                jsonText = await response.Content.ReadAsStringAsync();
            }


            LoginResponseDto usuarioResponseApi = JsonConvert.DeserializeObject<Response<LoginResponseDto>>(jsonText).Data;

            return usuarioResponseApi;
        }
    }
}
