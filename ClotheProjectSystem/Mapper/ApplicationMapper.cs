using AutoMapper;
using ClotheBusinessObject.BusinessObject;
using ClotheBusinessObject.DTO.Create;
using ClotheBusinessObject.DTO.Update;
using ClotheBusinessObject.ViewModel;

namespace ClotheProjectSystem.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ClotheVM, Clothe>().ReverseMap();
            CreateMap<ClotheCreateDTO, Clothe>().ReverseMap();
            CreateMap<ClotheUpdateDTO, Clothe>().ReverseMap();

        }
    }
}
