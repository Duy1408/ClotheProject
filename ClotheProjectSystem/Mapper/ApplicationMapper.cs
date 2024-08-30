using AutoMapper;
using ClotheBusinessObject.BusinessObject;
using ClotheBusinessObject.ViewModel;

namespace ClotheProjectSystem.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ClotheVM, Clothe>().ReverseMap();
        }
    }
}
