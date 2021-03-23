using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XpertGroup.Users.Domain.Entities;
using XpertGroup.Users.Domain.Interfaces.Adapters;

namespace XpertGroup.Users.Infra.Data.Adapters
{
    public class BaseAdapter : IBaseAdapter
    {
        private readonly HttpClient httpClient;
        public BaseAdapter()
        {
            this.httpClient = new HttpClient();
        }

        public HttpClient GetHttpClient()
        {
            return this.httpClient;
        }

        public async Task<T> Get<T>(string url)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
            var response = await this.httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return (T)Activator.CreateInstance(typeof(T));

            var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return data;
        }
    }
}
