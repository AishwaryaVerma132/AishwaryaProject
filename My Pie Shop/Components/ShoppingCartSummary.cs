using Microsoft.AspNetCore.Mvc;
using My_Pie_Shop.Models;
using My_Pie_Shop.ViewModels;

namespace My_Pie_Shop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;//declaring object

        public ShoppingCartSummary(ShoppingCart shoppingCart)//constructor will take care of creating object
        {
            _shoppingCart = shoppingCart; //shopping cart object
        }

        public IViewComponentResult Invoke() //action method for component
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel //creating view model
            {
                ShoppingCart = _shoppingCart, //property- sending entire shopping cart
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal() //total shopping cart items
            };

            return View(shoppingCartViewModel);
        }

    }
}
