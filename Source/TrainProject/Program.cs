using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TrainProject
{
    class Program
    {
        public static string trains = File.ReadAllText("trains.txt");
        public static string[] a = trains.Split(",");


        static void Main(string[] args)
        {
            Console.WriteLine(a[0].ToString());
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
    class Train
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxSpeed { get; set; }
        public bool oprated { get; set; }

        


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

    class Station
    {
        int id;
        string stationName;
        bool endStation;
    }

    class Passenger
    {
        int id;
        string name;
    }
    
}