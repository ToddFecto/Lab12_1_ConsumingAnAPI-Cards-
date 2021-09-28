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
        public int deck_count { get; set; }
    }
}
