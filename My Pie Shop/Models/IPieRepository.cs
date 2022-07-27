namespace My_Pie_Shop.Models
{
    public interface IPieRepository
    {
        //middle page
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
