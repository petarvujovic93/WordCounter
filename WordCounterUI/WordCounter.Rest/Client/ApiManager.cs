using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Common.Configuration;

namespace WordCounter.Rest.Client
{
    public class ApiManager<TInput, TOutout> 
        where TInput : class
        where TOutout : class
    {
        public async Task<TOutout> Post(string route, TInput input)
        {
            using (var client = CreateHttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

                var result = await client.PostAsync(route, stringContent);
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TOutout>(result.Content.ReadAsStringAsync().Result);
                }
                else
                    return null;
            }
        }

        public async Task<TOutout> Upload (string route, TInput input)
        {
            using (var client = CreateHttpClient())
            {
                dynamic command = input as TInput;
                var uploadContent = new MultipartFormDataContent();
                var stream = command.Content as System.IO.Stream;

                uploadContent.Add(new StreamContent(stream), command.Name, command.Name);

                var result = await client.PostAsync(route, uploadContent);
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TOutout>(result.Content.ReadAsStringAsync().Result);
                }
                else
                    return null;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(WebConfiguration.GetApiUrl());
            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }
    }
}
