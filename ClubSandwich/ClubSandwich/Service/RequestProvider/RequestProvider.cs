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
            _client.DefaultRequestHeaders.Add("Sandwich-Auth-Token", "facebook EAAV6wdp26tcBAJgi7eWM65nrVZB3UW1ovUM4yfEnMJj83dAmCs2A3QSKdGBXZCWOQcbz8d3tdbqzfdPTc9wtiCmTM5JCqlzupjqjdyGd1c71ZBdi8oDz2GwGJEv5gJiIKwcz23Xx7CW8hgYTeeR6lfhkbSTCh8OVBRVgmRSMpmMMsZCrVIkL2Mm12D9Df78xZBPCq5VdZBIAZDZD");
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
