using System;

namespace FindRideToWork.Core.Domain
{
    public class Vehicle
    {
        public Guid VehicleId { get; protected set; }
        public int SeatsNumber { get; protected set; }
        public string Brand { get; protected set; }
        public int Doors { get; protected set; }

        //THE VEHICLE HAS A VARIOUS COLORS
        // CAN HELP IDENTIFY 
        // PLATE NUMBER
    }
}