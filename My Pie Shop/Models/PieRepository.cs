using Microsoft.EntityFrameworkCore;

namespace My_Pie_Shop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        
        // All Pies Page
        public IEnumerable<Pie> AllPies => appDbContext.Pies.Include(c => c.Category);

        // Home Page
        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek).Include(c => c.Category);

        public IEnumerable<Pie> FruitPie => appDbContext.Pies.Where(pies => pies.CategoryId == 1).Include(c => c.Category);

        public IEnumerable<Pie> CheeseCake => appDbContext.Pies.Where(pies => pies.CategoryId == 2).Include(c => c.Category);

        public IEnumerable<Pie> SeasonalPie => appDbContext.Pies.Where(pies => pies.CategoryId == 3).Include(c => c.Category);

        //Details
        public Pie GetPieById(int pieId)
        {
            //It returns the first Pie on the basis of entered PieId
            return this.AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
