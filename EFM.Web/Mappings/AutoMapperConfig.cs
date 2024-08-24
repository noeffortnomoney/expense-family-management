using AutoMapper;
using EFM.Model.Model;
using EFM.Web.Models;

namespace EFM.Web.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                //User
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
