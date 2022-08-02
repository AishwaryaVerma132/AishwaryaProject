using My_Pie_Shop.Models;

namespace My_Pie_Shop.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string CurrentCategory { get; set; }

        public Category Description { get; set; }

    }
}
