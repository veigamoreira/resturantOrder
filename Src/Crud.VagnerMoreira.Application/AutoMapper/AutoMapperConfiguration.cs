using AutoMapper;

namespace Crud.VagnerMoreira.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ModelToViewModel());
                ps.AddProfile(new ViewModelToModel());
            });
        }
    }
}
