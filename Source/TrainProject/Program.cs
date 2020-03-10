using System;
using System.Collections.Generic;
using System.IO;
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
    public class Train
    {
        public int id { get; }
        public string name { get; }
        public int maxSpeed { get; }
        public bool operated { get; }

        public Train(string trianList)
        {
            string[] convert = trianList.Split(",");
            id = int.Parse(convert[0]);
            name = convert[1];
            maxSpeed = int.Parse(convert[2]);
            operated = bool.Parse(convert[3]);
        }
    }

    public class TrainList
    {
        public List<Train> InitAvailableTrain()
        {
            List<Train> AvailableTrain = new List<Train>();
            string[] trains = File.ReadAllLines(Program.TrainFilePath);

            foreach (string item in trains)
            {
                AvailableTrain.Add(new Train(item));
            }

            return AvailableTrain;
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

    public class Schedule
    {
        public int traindId { get; }
        public int stationId { get; }
        public TimeSpan departureTime { get; }
        public TimeSpan arrivalTime{ get;   }


        public Schedule(string scheduleList)
        {
            string[] part = scheduleList.Split(',');

            traindId = int.Parse(part[0]);
            stationId = int.Parse(part[1]);
            try
            {
                departureTime = TimeSpan.Parse(part[2]);
                
            }
            catch
            {
                departureTime = TimeSpan.Parse("00:00");
            }
            
            try
            {
                arrivalTime = TimeSpan.Parse(part[3]);   
            }
            catch 
            {
                arrivalTime = TimeSpan.Parse("00:00");
            }
           
            //if (string.IsNullOrEmpty(part[2]))
            //{
            //    departureTime = TimeSpan.Parse("00:00");
            //}
            //else
            //{
            //    departureTime = TimeSpan.Parse(part[2]);

            //}
            //if (string.IsNullOrEmpty(null))
            //{
            //    arrivalTime = TimeSpan.Parse("00:00");
            //}
            //else
            //{
            //arrivalTime = TimeSpan.Parse(part[3]);

            //}

        }
    }

    public class ScheduleList
    {
        public List<Schedule> InitAvailableSchedule()
        {
            List<Schedule> AvailableSchedule = new List<Schedule>();
            string[] tidtabell = File.ReadAllLines(Program.ProductFilePath);

            foreach (string item in tidtabell)
            {
                AvailableSchedule.Add(new Schedule(item));
            }

            return AvailableSchedule;
        }
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
