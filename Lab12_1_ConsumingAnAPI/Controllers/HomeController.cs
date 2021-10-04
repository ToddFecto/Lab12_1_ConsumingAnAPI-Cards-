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

        public async Task<IActionResult> Index(string deck_id)
        {
            if (deck_id == null)
            {
                deck_id = await DAL.ShuffleTheCards();
            }

            CardDeck cards = await DAL.DrawACard(deck_id, 7);
            return View(cards);
        }

        public async Task<IActionResult> Reshuffle(string deck_id)
        {
            deck_id = await DAL.ReshuffleTheCards(deck_id);

            CardDeck cards = await DAL.DrawACard(deck_id, 7);
            return View(cards);
        }

        public async Task<IActionResult> NewDeck(string deck_id)
        {
            deck_id = await DAL.ABrandNewDeck(deck_id);

            CardDeck cards = await DAL.DrawACard(deck_id, 7);
            return View(cards);
        }

        public async Task<IActionResult> NewDeckWithJokers(string deck_id)
        {
            deck_id = await DAL.JokersInNewDeck(deck_id);

            CardDeck cards = await DAL.DrawACard(deck_id, 7);
            return View(cards);
        }

        public async Task<IActionResult> APartialDeck(string deck_id)
        {
            /*
              In this example, we are asking for a deck consisting of all the aces,
              twos, and kings.
              The value, one of A (for an ace), 2, 3, 4, 5, 6, 7, 8, 9, 0 (for a ten),
              J (jack), Q (queen), or K (king);
              The suit, one of S (Spades), D (Diamonds), C (Clubs), or H (Hearts).
             */
            if (deck_id == null)
            {
                deck_id = await DAL.DeckOf12Cards(deck_id);
            }

            CardDeck cards = await DAL.DrawACard(deck_id, 1);
            return View(cards);
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
