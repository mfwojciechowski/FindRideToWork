using AutoMapper;
using FindRideToWork.Core.Domain;
using FindRideToWork.Infrastructure.DTO.Driver;
using FindRideToWork.Infrastructure.DTO.User;

namespace FindRideToWork.Infrastructure.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Init()
        {
            var configuration = new MapperConfiguration(cfg =>{
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Driver, DriverDTO>();
                cfg.CreateMap<Vehicle, VehicleDetailsDTO>();
            });
            return configuration.CreateMapper();
        }
    }
}