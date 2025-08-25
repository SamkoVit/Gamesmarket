using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamesmarket.Domain.ViewModel.Cart
{
    public class CartItemViewModel
    {
        public long CartItemId { get; set; }

        public int GameId { get; set; }

        public string GameName { get; set; }

        public string Developer { get; set; }

        public List<string> Genres { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }
    }
}
