using System.Collections.Generic;
using AutoMapper;
using FindRideToWork.Core.Domain;
using FindRideToWork.Infrastructure.DTO.Driver;
using FindRideToWork.Infrastructure.DTO.Route;
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
                cfg.CreateMap<RoutePoint, RoutePointDTO>();
                cfg.CreateMap<Route, RouteDetailsDTO>();
                cfg.CreateMap<SingularRoute,SingularRouteDetailsDTO>();
            });
            return configuration.CreateMapper();
        }
    }
}