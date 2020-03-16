using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TrainProject
{
    public class Program
    {
        public const string ProductFilePath = (@"TextFiles\timetable.txt");
        public const string TrainFilePath = (@"TextFiles\trains.txt");
        public const string StationFilePath = (@"TextFiles\stations.txt");
        public const string PassengersFilePath = (@"TextFiles\passengers.txt");
        public static List<Schedule> scheduleList;
        public static List<Train> trainList;
        public static List<Station> stationList;
        public static List<Passenger> passengerList { get; set; }
        public static TimeSpan timer;

        public static void Main(string[] args)
        {
            CreateDatabase();

            var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            CreateTrainPlaner testTrainPlaner1 = new CreateTrainPlaner(trainPlaner1);
            testTrainPlaner1.trainThread = new Thread(() => testTrainPlaner1.Drive(testTrainPlaner1));

            CreateTrainPlaner testTrainPlaner2 = new CreateTrainPlaner(trainPlaner2);
            testTrainPlaner2.trainThread = new Thread(() => testTrainPlaner2.Drive(testTrainPlaner2));

            testTrainPlaner2.trainThread.Start();
            testTrainPlaner1.trainThread.Start();

            StartTimer();
        }

        public static void CreateDatabase()
        {
            ScheduleList p = new ScheduleList();
            scheduleList = p.InitAvailableSchedule();

            TrainList promp = new TrainList();
            trainList = promp.InitAvailableTrain();

            StationList SList = new StationList();
            stationList = SList.InitAvailableStations();

            PassengerList createPassengerList = new PassengerList();
            passengerList = createPassengerList.InitAllPassengers();
        }

        public static void StartTimer()
        {
            TimeSpan addMin = TimeSpan.FromMinutes(1);
            timer = new TimeSpan(10, 15, 00);
            for (int i = 0; i < 62; i++)
            {
                Console.WriteLine(timer);
                timer += addMin;
                Thread.Sleep(300);
                Console.WriteLine("----------------");
            }
        }

        public interface IControlRoom
        {
            Train train { get; }
            List<Schedule> trainSchedules { get; set; }
            List<Passenger> trainPassenger { get; set; }

            IControlRoom FollowSchedule(List<Schedule> schedules);
            IControlRoom AddPassengers(List<Passenger> passengers);
            IControlRoom CrossoverControll();
        }

        private class Switch
        {
            private bool turnRight;
        }

        private class LevelCrossing
        {
            private bool open;
        }
    }
}