using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab12_1_ConsumingAnAPI.Models
{
    public class DAL
    {
        private static HttpClient client = null;
        private static HttpClient GetHttpClient()
        {
            // Building a **SINGLETON** object of type HttpClient - avoids a lot extra traffic

            if (client == null)
            {
                // client instance hasn't been made yet, make it and initialize it
                client = new HttpClient();
                client.BaseAddress = new Uri("https://deckofcardsapi.com");
            }
            return client;
        }

        public static async Task<string> ShuffleTheCards()
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/new/shuffle/?deck_count=1";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<CardDeck> DrawACard(string deck_id, int count)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count={count}";

            var connection = await client.GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result;
        }
    }
}
