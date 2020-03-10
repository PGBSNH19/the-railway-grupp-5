using System;
using System.Collections.Generic;
using System.Text;

namespace TrainProject
{
    class Program
    {
        

        public const string ProductFilePath = "timetable.txt";
        public const string TrainFilePath = "trains.txt";


        static void Main(string[] args)
        {

             List<Schedule> scheduleList;
             ScheduleList p = new ScheduleList();
             scheduleList = p.InitAvailableSchedule();

            List<Train> trainList;
            TrainList promp = new TrainList();

            trainList = promp.InitAvailableTrain();
            var jaja = scheduleList; 
        }
    }

    interface IControlRoom
    {
        IControlRoom FollowSchedule();
        IControlRoom OpenGate();
        IControlRoom CloseGate();
        IControlRoom SetSwitch();
    }

    public class TrainPlaner
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

        //public IControlRoom CloseGate()
        //{
        //    throw new NotImplementedException();

        //}

        //public IControlRoom FollowSchedule()
        //{
        //    throw new NotImplementedException();
        //}

        //public IControlRoom OpenGate()
        //{
        //    throw new NotImplementedException();
        //}

        //public IControlRoom SetSwitch()
        //{
        //    throw new NotImplementedException();
        //}
    }

    class Switch
    {
        bool turnRight;
    }

    class LevelCrossing
    {
        bool open;
    }

    public class Station
    {
        public int id { get; }
        public string stationName { get; }
        public bool endStation { get; }

        public Station(string[] stationArray)
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
