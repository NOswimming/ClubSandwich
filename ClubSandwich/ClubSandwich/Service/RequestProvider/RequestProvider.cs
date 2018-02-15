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
            _client.DefaultRequestHeaders.Add("Sandwich-Auth-Token", "facebook EAAV6wdp26tcBAAkBwQXqewjvFUQZCVNfAIlJ0rKy9ZAie55LvBZBFCf7UQFoLvAFRjFBEWrQbtUVCVOcT7xZB3ZASyZCxTUzi8ZCZAQnwRUoBE46goZAz88sXvkMOFlp9RrZAIcY6HbUZCZBoJvfsHZCaWpXMpVlgFXuJHsG61YPpUx2xhSnuxhF4W4aEly9idn9Y5QvZBdRWKcZATrWQZDZD");
            _client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache, no-store, must-revalidate");
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
