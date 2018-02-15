using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClubSandwich.Service.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {

        private const string END_POINT = @"https://api.sandwichclub.tk/";

        private readonly HttpClient _client;

        public RequestProvider()
        {
            _client = new HttpClient();
            //_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _session.GetLoginCredentials());
            _client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache, no-store, must-revalidate");
        }

        public async Task<GraphResult<T>> Query<T>(string query)
        {
            var graphQuery = new { query };
            var content = new StringContent(JsonConvert.SerializeObject(graphQuery), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(END_POINT + "graphql", content);
            var json = await response.Content.ReadAsStringAsync();

            var graphResult = JsonConvert.DeserializeObject<GraphResult<T>>(json);

            return graphResult;
        }
    }
}
