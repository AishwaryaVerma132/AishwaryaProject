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
        int CreatePie(Pie pie);
        int UpdatePie(Pie pie);
        int RemovePie(Pie pie);
    }
}
