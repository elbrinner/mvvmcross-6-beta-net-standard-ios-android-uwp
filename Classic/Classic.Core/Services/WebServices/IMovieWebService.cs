using Classic.Core.Models.Movie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.Services.WebServices
{
    public interface IMovieWebService
    {
       Task<MovieResponse> Movie();
    }
}
