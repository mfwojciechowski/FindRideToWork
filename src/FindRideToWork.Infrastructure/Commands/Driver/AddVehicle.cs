using System;

namespace FindRideToWork.Infrastructure.Commands.Driver
{
    public class AddVehicle : ICommand
    {
        public Guid UserId { get; set; }
        public int SeatsNumber { get; set; }
        public string CarModel { get; set; }
        public string Brand { get; set; }
        public string Plates { get; set; }
        public int Doors { get; set; }        
        public int ColorId 
        { 
            get
            {
                return 1;
            } 
        }        
    }
}