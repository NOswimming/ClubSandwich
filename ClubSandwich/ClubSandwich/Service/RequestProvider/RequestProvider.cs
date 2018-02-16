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

        private const string END_POINT = @"https://api.sandwichclub.tk/graphql";

        private readonly HttpClient _client;

        public RequestProvider()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Sandwich-Auth-Token", "facebook EAAV6wdp26tcBAJbXu0vpVN7BZCXcY4qDO4ZBAHfccOslZBhxd6uzEibV3Ok0HM5ZC5cqb8LRDvU6Kmdm25D0KXEb7ak3qCrEZCFpmv0Wf447xCZBP3n5wJFmq46kpjl7YA7E3mWygNgh78H59ONJKiasPZAS6GxifGnGVmV5rTAhekJ9T3tCEJecJw183vy1s0Vh7WROzjBVAZDZD");
        }

        public async Task<GraphResult<T>> Query<T>(string query)
        {
            try
            {
                var graphQuery = new { query };
                var content = new StringContent(JsonConvert.SerializeObject(graphQuery), Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(END_POINT, content).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var graphResult = JsonConvert.DeserializeObject<GraphResult<T>>(json);

                return graphResult;
            }catch(Exception ex)
            {
                throw new Exception("Error on querying..");
            }
        }
    }
}
