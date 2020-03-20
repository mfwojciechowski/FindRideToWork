using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FindRideToWork.Core.Domain;
using FindRideToWork.Core.Repositories;
using FindRideToWork.Infrastructure.DTO.Driver;

namespace FindRideToWork.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IUserRepository userRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddVehicle(Guid userId, string brand, int seats, int doors, string plates, string carModel)
        {
            var driver = await _driverRepository.GetDriverAsync(userId);
            if(driver == null)
            {
                throw new Exception("Driver doesn't exists.");
            }
            var vehicle = new Vehicle(brand, seats, doors, plates, carModel);
            driver.AddVehicle(vehicle);
        }

        public async Task CreateDriverAsync(Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if(user == null)
            {
                throw new Exception("User with id does not exist.");
            }
            
            var driver = new Driver(user.UserId);
            await _driverRepository.CreateDriverAsync(driver);
        }

        public async Task<DriverDTO> GetDriver(Guid userId)
        {
            var user = await _driverRepository.GetDriverAsync(userId);
            return _mapper.Map<Driver,DriverDTO>(user);

        }
    }
}