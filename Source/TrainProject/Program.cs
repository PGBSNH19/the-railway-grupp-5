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
            var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList).AddPassengers(passengerList);
            var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList).AddPassengers(passengerList);

            CreateTrainPlaner testTrainPlaner1 = new CreateTrainPlaner(trainPlaner1);
            testTrainPlaner1.trainThread = new Thread(() => testTrainPlaner1.DriveTrack1(testTrainPlaner1));

            CreateTrainPlaner testTrainPlaner2 = new CreateTrainPlaner(trainPlaner2);
            testTrainPlaner2.trainThread = new Thread(() => testTrainPlaner2.DriveTrack2(testTrainPlaner2));

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
            }
        }

        public interface IControlRoom
        {
            Train train { get; }
            List<Schedule> trainSchedules { get; set; }
            List<Passenger> trainPassenger { get; set; }

            IControlRoom FollowSchedule(List<Schedule> schedules);

            IControlRoom AddPassengers(List<Passenger> passengers);
        }

        public class TrainPlaner : IControlRoom
        {
            public Train train { get; }
            public List<Schedule> trainSchedules { get; set; }
            public List<Passenger> trainPassenger { get; set; }

            public TrainPlaner(List<Train> trainList, int check)
            {
                this.train = trainList.Where(p => p.id == check).ToList().First();
            }

            public IControlRoom FollowSchedule(List<Schedule> schedules)
            {
                trainSchedules = schedules.Where(x => x.traindId == train.id).ToList();
                return this;
            }

            public IControlRoom AddPassengers(List<Passenger> passengers)
            {
                trainPassenger = new List<Passenger>();
                Random rnd = new Random();
                int random = rnd.Next(0, passengerList.Count);
                for (int i = 0; i < random; i++)
                {
                    trainPassenger.Add(passengers[i]);
                }
                passengerList.RemoveRange(0, random);
                return this;
            }
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