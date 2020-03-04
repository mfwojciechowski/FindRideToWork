using System;

namespace FindRideToWork.Core.Domain
{
    public class RoutePoint
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public string Address { get; protected set; }

        public RoutePoint(double latitude, double longitude, string address)
        {
            SetAddress(address);
            SetCoordinates(latitude, longitude);
        }

        private void SetCoordinates(double latitude, double longitude)
        {
            if(double.IsNaN(latitude) || double.IsNaN(longitude))
            {
                throw new Exception("You must provide correct data.");
            }
            if(Latitude == latitude || Longitude == longitude) return;
            Latitude = latitude;
            Longitude = longitude;
        }

        private void SetAddress(string address)
        {
            if(string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Address cannot be null.");
            }
            
            if(address == Address) return;
            Address = address;
        }

        public static RoutePoint Create(double latitude, double longitude, string address)
            => new RoutePoint(latitude, longitude, address);
    }
}