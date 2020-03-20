namespace FindRideToWork.Infrastructure.DTO.Driver
{
    public class VehicleDetailsDTO
    {
        public int SeatsNumber { get; protected set; }
        public string CarModel { get; protected set; }
        public string Brand { get; protected set; }
        public string Plates { get; protected set; }
        public int Doors { get; protected set; }
    }
}