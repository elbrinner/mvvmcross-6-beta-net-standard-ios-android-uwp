using Classic.Core.Constants;
using Classic.Core.Models.Movie;
using Classic.Core.Services.Connectors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.Services.WebServices
{
    public class MovieWebService : IMovieWebService
    {
        IWebClientService conection;

        public MovieWebService(IWebClientService conection)
        {
            this.conection = conection;
        }

        public async Task<MovieResponse> Movie()
        {
            var url = new Uri(string.Format(CultureInfo.InvariantCulture, ConfigConstants.baseUrl));
            var result = await conection.Client().GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                if (content != null)
                {
                    var response = JsonConvert.DeserializeObject<MovieResponse>(content);
                    response.IsCorrect = true;
                    return response;
                }
            }
            return new MovieResponse() { Mensage = "Servicio no disponible" };
        }
    }
}
