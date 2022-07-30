namespace PieShopAPI.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }

        //Home Page
        IEnumerable<Pie> PiesOfTheWeek { get; }

        //Details page
        Pie GetPieById(int pieId);
        IEnumerable<Pie> FruitPie { get; }

        IEnumerable<Pie> CheeseCake { get; }

        IEnumerable<Pie> SeasonalPie { get; }
    }
}
