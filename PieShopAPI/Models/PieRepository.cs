using Microsoft.EntityFrameworkCore;

namespace PieShopAPI.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
       
        public IEnumerable<Pie> AllPies => appDbContext.Pies.Include(c => c.Category);

        
        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek).Include(c=> c.Category);   

        public Pie DeletePie(int PieID)
        {
            var deletePie = AllPies.FirstOrDefault(pie => pie.PieId == PieID);
            var delete = this.appDbContext.Pies.Remove(deletePie);
            this.appDbContext.SaveChanges();
            return delete.Entity;
        }

        //Details
        public Pie GetPieById(int pieId)
        {
            //It returns the first Pie on the basis of entered PieId
            return this.AllPies.FirstOrDefault(p => p.PieId == pieId);
        }

        public Pie InsertPie(Pie pie)
        {
            var insert = this.appDbContext.Pies.Add(pie);
            this.appDbContext.SaveChanges();
            return insert.Entity;
        }

        public Pie UpdatePie(Pie pie)
        {
            var updatePie = this.appDbContext.Pies.Update(pie);
            this.appDbContext.SaveChanges();
            return updatePie.Entity;
        }
    }
}
