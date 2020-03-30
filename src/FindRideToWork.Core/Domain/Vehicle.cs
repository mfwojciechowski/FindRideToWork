using System;
using FindRideToWork.Core.Entities;

namespace FindRideToWork.Core.Domain
{
    //THE VEHICLE HAS A VARIOUS COLORS
    // CAN HELP IDENTIFY 
    // PLATE NUMBER
    public class Vehicle
    {
        public int SeatsNumber { get; protected set; }
        public string CarModel { get; protected set; }
        public string Brand { get; protected set; }
        public string Plates { get; protected set; }
        public int Doors { get; protected set; }
        public int ColourId { get; protected set; }

        public virtual Colour Colour {get;set;}

        public Vehicle()
        {            
        }

        public Vehicle(string brand, int seats, int doors, string plates, string carModel, int colourId)
        {
            SetColour(colourId);
            SetBrand(brand);
            SetSeats(seats);            
            SetDoors(doors);
            SetCarModel(carModel);
            SetPlates(plates);
        }
 
        private void SetColour(int colourId)
        {
            ColourId = colourId;
        } 

        private void SetCarModel(string carModel)
        {
            if (string.IsNullOrWhiteSpace(carModel))
            { 
                throw new Exception("Car model cannot be null.");
            }

            if(CarModel == carModel) return;
            CarModel = carModel;
        }

        public void SetSeats(int seatsNumber)
        {
            if(seatsNumber < 0)
            {
                throw new Exception("Seats number must be greater than 0.");

            }

            if(seatsNumber > 9)
            {
                throw new Exception("You cannot provide more than 9 seats.");
            }
            if(seatsNumber == SeatsNumber) return;
            SeatsNumber = seatsNumber;
        }

        private void SetBrand(string brand)
        {
            if(string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Brand cannot be null.");
            }

            if(brand == Brand) return;
            Brand = brand;
        }

        private void SetDoors(int doors)
        {
            if(doors > 5)
            {
                throw new Exception("Brand cannot be null.");
            }

            if(doors < 3)
            {
                throw new Exception("");
            }

            if(doors == Doors) return;
            Doors = doors;
        }

        private void SetPlates(string plates)
        {
            if(string.IsNullOrWhiteSpace(plates))
            {
                throw new Exception("Plates cannot be null.");
            }

            if(plates == Plates) return;
            Plates = plates;
        }

        public static Vehicle Create(string brand, int seats, int doors, string plates, string carModel, int colourId)
            => new Vehicle(brand, seats, doors, plates, carModel, colourId);
    }
}