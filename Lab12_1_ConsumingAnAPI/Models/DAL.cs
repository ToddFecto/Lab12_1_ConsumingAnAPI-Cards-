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
            //3 Lines below not needed due to use of **SINGLETON** object
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/new/shuffle/?deck_count=1";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<CardDeck> DrawACard(string deck_id, int drawCount)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);
            //string path = $"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count={drawCount}";

            string path = $"/api/deck/{deck_id}/draw/?count={drawCount}";

            var connection = await client.GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result;
        }

        public static async Task<string> ReshuffleTheCards(string deck_id)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/{deck_id}/shuffle/";
            
            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<string> ABrandNewDeck(string deck_id)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/new/";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<string> JokersInNewDeck(string deck_id)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/new/?jokers_enabled=true";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<string> DeckOf12Cards(string deck_id)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/new/shuffle/?cards=AS,2S,KS,AD,2D,KD,AC,2C,KC,AH,2H,KH";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }

        public static async Task<string> AddPiles(string deck_id)
        {
            //string domain = "https://deckofcardsapi.com";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(domain);

            string path = $"/api/deck/{deck_id}/pile/discard/add/?cards=AS,2S";

            var connection = await GetHttpClient().GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return result.deck_id;
        }
    }
}
