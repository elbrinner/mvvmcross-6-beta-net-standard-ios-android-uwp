using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Classic.Core.Services.Connectors
{
    public interface IWebClientService
    {
        HttpClient Client();
    }
}
