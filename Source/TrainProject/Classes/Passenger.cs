using System.Collections.Generic;
using System.IO;

namespace TrainProject
{
    public class Passenger
    {
        public int id { get; }
        public string name { get; }

        public Passenger(string passengerList)
        {
            string[] convert = passengerList.Split(";");
            id = int.Parse(convert[0]);
            name = convert[1];
        }
    }

    public class PassengerList
    {
        public List<Passenger> InitAllPassengers()
        {
            List<Passenger> allPassengers = new List<Passenger>();
            string[] passengers = File.ReadAllLines(Program.PassengersFilePath);

            foreach (string item in passengers)
            {
                allPassengers.Add(new Passenger(item));
            }

            return allPassengers;
        }
    }
}