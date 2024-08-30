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
                //Category
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();

                //User
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();

                //Family
                cfg.CreateMap<Family, FamilyViewModel>();
                cfg.CreateMap<FamilyViewModel, Family>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
