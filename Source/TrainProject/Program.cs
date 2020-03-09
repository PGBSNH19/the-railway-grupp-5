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

    class Train
    {
        int id = 0;
        string name;
        int maxSpeed = 0;
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

        string[] reader = File.ReadAllLines(@)

    }

    }
}