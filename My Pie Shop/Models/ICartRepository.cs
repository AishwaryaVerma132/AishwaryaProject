namespace My_Pie_Shop.Models
{
    public interface ICartRepository
    {
        IEnumerable<Cart> AllOrders { get; }
        Cart AddOrder(Cart cart);
        Cart UpdateOrder(Cart cart);
        Cart DeleteOrder(Cart cartId);
    }
}
