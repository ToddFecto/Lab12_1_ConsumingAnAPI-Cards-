using Lab12_1_ConsumingAnAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab12_1_ConsumingAnAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> shufflethecards(string key)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/{key}.json";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return View(result);
        }

        public async Task<IActionResult> drawacard(string key)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/{key}.json";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return View(result);
        }

        public async Task<IActionResult> reshufflethecards(string key)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/{key}.json";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path); // Async means our function will pause and wait until GetAsync finishes. Then come back and pick up where we left off.
            CardDeck result = await connection.Content.ReadAsAsync<CardDeck>();

            return View(result);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
