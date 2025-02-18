using Newtonsoft.Json;
using Pre.Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pre.Movies.Core
{
    public class MovieRepository
    {
        private readonly HttpClient _httpClient;
        private const string _url = "https://freetestapi.com/api/v1/movies";
        public MovieRepository()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            _httpClient = new HttpClient(handler);
        }

        public async Task<List<Movie>> GetMovies()
        {
            var result = await _httpClient
                .GetAsync(_url).Result.Content
                .ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Movie>>(result);
        }

    }
}
