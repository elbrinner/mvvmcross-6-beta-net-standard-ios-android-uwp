using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Classic.Core.Services.Connectors
{
    public class WebClientService : IDisposable, IWebClientService
    {
        private HttpClient client;

        public NativeCookieHandler CookieContainer { get; set; }

        public WebClientService()
        {
            this.client = this.GenerateHttpClient();
        }

        private HttpClient GenerateHttpClient()
        {
            this.CookieContainer = new NativeCookieHandler();

            NativeMessageHandler httpClientHandler = new NativeMessageHandler(
                false,
                true,
                this.CookieContainer
            );

            return new HttpClient(httpClientHandler);

        }

        public HttpClient Client()
        {
            return this.client;
        }


        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
