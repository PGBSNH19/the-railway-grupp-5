using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainProject
{
    class Program
    {
        //public static [] string trains = File.ReadAllLines("trains.txt");
        //public static string[] a = trains.Split(",");
        
       
     


        static void Main(string[] args)
        {
            string [] trains = File.ReadAllLines("trains.txt");
            string[] stations = File.ReadAllLines("stations.txt");
            var testTrain = new Train(trains);
            var testStation = new Station(stations);
        }   
    }

    interface IControlRoom
    {
        IControlRoom FollowSchedule();
        IControlRoom OpenGate();
        IControlRoom CloseGate();
        IControlRoom SetSwitch();
    }

    class TrainPlaner : IControlRoom
    {

        public TrainPlaner(Object train)
        {

        }

        public IControlRoom CloseGate()
        {
            throw new NotImplementedException();
        }

        public IControlRoom FollowSchedule()
        {
            throw new NotImplementedException();
        }

        public IControlRoom OpenGate()
        {
            throw new NotImplementedException();
        }

        public IControlRoom SetSwitch()
        {
            throw new NotImplementedException();
        }
    }
    public class Train
    {
        public int id { get; }
        public string name { get; }
        public int maxSpeed { get; }
        public bool operated { get; }

        public Train(string [] a)
        {
            string[] convert = a[0].Split(",");
            id = int.Parse(convert[0]);
            name = convert[1];
            maxSpeed = int.Parse(convert[2]);
            operated = bool.Parse(convert[3]);    
        }
    }

    class Switch
    {
        bool turnRight;
    }

    class LevelCrossing
    {
        bool open;
    }

    class Schedule
    {
        int traindId { get; set; }
        int stationId { get; set; }
        TimeSpan departureTime { get; set; }
        TimeSpan arrivalTime { get; set; }

        List<string> timeList = new List<string>();
    }

   public class Station
    {
        public int id { get; }
        public string stationName { get; }
        public bool endStation { get; }

        public Station(string [] stationArray)
        {
            string[] convert = stationArray[1].Split("|");
            id = int.Parse(convert[0]);
            stationName = convert[1];
            endStation = bool.Parse(convert[2]);
        }
    }

    class Passenger
    {
        int id;
        string name;
    }
    
}