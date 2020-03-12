using System.Collections.Generic;
using System.IO;

namespace TrainProject
{
    public class Passengers
    {
        public int id { get; }
        public string name { get; }

        public Passengers(string passengerList)
        {
            string[] convert = passengerList.Split(",");
            id = int.Parse(convert[0]);
            name = convert[1];
        }
    }

    public class PassengerList
    {
        public List<Passengers> InitAllPassengers()
        {
            List<Passengers> allPassengers = new List<Passengers>();
            string[] passengers = File.ReadAllLines(Program.PassengersFilePath);

            foreach (string item in passengers)
            {
                allPassengers.Add(new Passengers(item));
            }

            return allPassengers;
        }
    }
}