using Gamesmarket.Domain.Entity;
using Gamesmarket.Domain.ViewModel.Order;
using System.Collections.Generic;
using System.Linq;

namespace Gamesmarket.Utilities.Cart
{
    public static class CartQueriesUtilities
    {
        // Map many cart items to view models (one view model for cart item)
        public static IEnumerable<OrderViewModel> MapOrdersToViewModels(IEnumerable<CartItem> cartItem)
        {
            if(cartItem == null) return Enumerable.Empty<OrderViewModel>();
            
            return cartItem.Select(x => MapOrderToViewModel(x));
        }

        // Map single cart item
        public static OrderViewModel MapOrderToViewModel(CartItem CartItem)
        {
            var game = CartItem.Game;
            
            return new OrderViewModel
            {
                Id = CartItem.Id,
                GameName = game.Name,
                GameDeveloper = game.Developer,
                GameGenre = game.GameGenre.ToString(),
                GamePrice = game.Price,
                Email = order.Email,
                Name = order.Name,
                DateCreate = order.DateCreated.ToShortDateString()
            };
        }
    }
}
