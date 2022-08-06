/*using Microsoft.AspNetCore.Mvc;
using My_Pie_Shop.Models;

namespace My_Pie_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICartRepository _cartRepository;
        private readonly AppDbContext _appDbContext;

        public CartController(IHttpContextAccessor httpContextAccessor, ICartRepository cartRepository , AppDbContext appDbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this._cartRepository = cartRepository;
            this._appDbContext = appDbContext;
        }

        public IActionResult ViewCart()
        {
            var user = httpContextAccessor.HttpContext.User.Identity.Name;
            var cart = _appDbContext.Cart.Where(c => c.OrderId == user);
            if (user == "manager@gmail.com")
            {
                cart = _appDbContext.Cart;
            }
            ViewBag.User = user;   
            return View(cart);
        }

        public IActionResult Increase(int id)
        {
            var cart = _appDbContext.Cart.FirstOrDefault(c => c.CartId == id);
            cart.Quantity++;
            _appDbContext.SaveChanges();
            return RedirectToAction("ViewCart");
        }

        public IActionResult Decrease(int id)
        {
            var cart = _appDbContext.Cart.FirstOrDefault(c => c.CartId == id);
            if (cart.Quantity != 0)
            {
                cart.Quantity--;
                _appDbContext.SaveChanges();
            }
            return RedirectToAction("ViewCart");
        }

        public IActionResult Remove(int id)
        {
            var RemoveItem = _appDbContext.Cart.FirstOrDefault(c => c.CartId == id);
            _cartRepository.DeleteOrder(RemoveItem);
            return RedirectToAction("ViewCart");
        }

    }
}
*/