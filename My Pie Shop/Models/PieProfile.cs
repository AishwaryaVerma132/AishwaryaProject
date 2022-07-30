using AutoMapper;

namespace My_Pie_Shop.Models
{
    public class PieProfile : Profile
    {
        public PieProfile()
        {
            this.CreateMap<Pie, PieMini>();
        }
    }
}
