using System;
using System.Collections.Generic;
using System.IO;

namespace TrainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IControlRoom
    {
        IControlRoom FollowSchedule();
        IControlRoom OpenGate();
        IControlRoom CloseGate();
        IControlRoom SetSwitch();
    }
    class TrainPlaner
    {

    }
    class Train
    {
        int id;
        string name;
        int maxSpeed;
        bool oprated;
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