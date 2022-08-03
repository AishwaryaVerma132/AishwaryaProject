using System.ComponentModel.DataAnnotations;

namespace My_Pie_Shop.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }     // primary key
        public string OrderId { get; set; }     // User specific
        public int PieId { get; set; }      // Foreign key
        public string PieName { get; set; }
        public decimal PiePrice { get; set; }
        public int Quantity { get; set; }

    }
}
