using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_1_ConsumingAnAPI.Models
{
    public class CardDeck
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public int remaining { get; set; }
        public bool shuffled { get; set; }
        public List<Draw> cards { get; set; }
        public List<Stacks> piles { get; set; }
    }

    public class Draw
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }

    public class Stacks
    {
        public List<Discards> discard { get; set; }
    }
    public class Discards
    {
        public int remaining { get; set; }
    }
}
