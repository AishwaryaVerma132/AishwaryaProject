namespace My_Pie_Shop.Models
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext appDbContext;

        public CartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Cart> AllOrders => appDbContext.Cart;

        public Cart AddOrder(Cart cart)
        {
            var insert = this.appDbContext.Cart.Add(cart);
            this.appDbContext.SaveChanges();
            return insert.Entity;            
        }

        public Cart DeleteOrder(Cart cart)
        {
           // var deleteOrder = AllOrders.FirstOrDefault(pie => pie.CartId == cartId);
            var delete = this.appDbContext.Remove(cart);
            this.appDbContext.SaveChanges();
            return delete.Entity;
        }

        public Cart UpdateOrder(Cart cart)
        {
            var updateOrder = this.appDbContext.Cart.Update(cart);
            this.appDbContext.SaveChanges();
            return updateOrder.Entity;
        }
    }
}
