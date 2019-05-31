using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SampleAPI.Tests.Util
{
    public class WebTest
    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<SampleAPI.Startup> _factory;

        public WebTest()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
