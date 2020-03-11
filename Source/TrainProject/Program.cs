using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrainProject
{
    class Program
    {
        public const string ProductFilePath = "timetable.txt";
        public const string TrainFilePath = "trains.txt";
        public const string StationFilePath = "stations.txt";



        static void Main(string[] args)
        {
             List<Schedule> scheduleList;
             ScheduleList p = new ScheduleList();
             scheduleList = p.InitAvailableSchedule();
            var jaja = scheduleList;


            List<Train> trainList;
            TrainList promp = new TrainList();
            trainList = promp.InitAvailableTrain();


            List<Station> stationList;
            StationList SList = new StationList();
            stationList = SList.InitAvailableStations();
            var stationTest = stationList;

        }
    }

    public interface IControlRoom
    {
        IControlRoom FollowSchedule();
        IControlRoom OpenGate();
        IControlRoom CloseGate();
        IControlRoom SetSwitch();
    }

    public class TrainPlaner : IControlRoom
    {
        public List<Schedule> trainSchedules = new List<Schedule>();
        public List<Station> trainStations { get; }
        public TrainPlaner(Train train)
        {

            //string[] tidtabell = File.ReadAllLines("timetable.txt");
            //for (int i = 0; i < tidtabell.Length; i++)
            //{
            //    string[] convert = tidtabell[i].Split(",");
            //    var test = new Schedule(convert);
            //    if (test.traindId == train.id)
            //    {
            //        trainSchedules.Add(test);
            //    }
            //}
        }

        public IControlRoom CloseGate()
        {
            return this;

        }

        public IControlRoom FollowSchedule()
        {
            return this;
        }

        public IControlRoom OpenGate()
        {
            return this;
        }

        public IControlRoom SetSwitch()
        {
            return this;
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

 

    class Passenger
    {
        int id;
        string name;
    }
}
