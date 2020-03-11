using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TrainProject
{
    public class Program
    {
        public const string ProductFilePath = "timetable.txt";
        public const string TrainFilePath = "trains.txt";
        public const string StationFilePath = "stations.txt";
        public const string PassengersFilePath = "passengers.txt";
        public static List<Schedule> scheduleList;
        public static List<Train> trainList;
        public static List<Station> stationList;



        static void Main(string[] args)
        {
            
             ScheduleList p = new ScheduleList();
             Program.scheduleList = p.InitAvailableSchedule();
            var jaja = scheduleList;


            TrainList promp = new TrainList();
            trainList = promp.InitAvailableTrain();



            StationList SList = new StationList();
            stationList = SList.InitAvailableStations();
            var stationTest = stationList;

            var train1 = new TrainPlaner(trainList, 2);
            var train2 = new TrainPlaner(trainList, 3);
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
        public Train train 
        {
            get;
        }
        public List<Schedule> trainSchedules = new List<Schedule>();
        public TrainPlaner(List<Train> trainList, int check)
        {
            foreach (var item in trainList)
            {
                if (item.id == check)
                {
                    train = item;
                }
            }
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

 

  
}
