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
        static readonly object _lock = new object();

        public static void Main(string[] args)
        {
            CreateDatabase();

            var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();
            var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            CreateTrainPlaner testTrainPlaner1 = new CreateTrainPlaner(trainPlaner1);
            CreateTrainPlaner testTrainPlaner2 = new CreateTrainPlaner(trainPlaner2);

            StartTimer(testTrainPlaner1, testTrainPlaner2);
        }

        public static void ArrivingEndStation(CreateTrainPlaner train)
        {
            bool check = false;
            string station;
            while(check == false)
            {
                if(TimeSpan.Parse(train.trainSchedules[2].arrivalTime).Subtract(TimeSpan.FromMinutes(3)) == timer)
                {
                    if(train.trainSchedules[2].stationId == stationList[2].id)
                    {
                        Console.WriteLine($"{train.train.name} will arrive to {stationList[2].stationName} in 3 minutes, setting switch to left");
                        while(check == false)
                        {
                            if(train.trainSchedules[2].arrivalTime == timer.ToString())
                            {
                                station = stationList.Where(p => p.id == train.trainSchedules[2].stationId).ToList().Select(p => p.stationName).First();
                                Console.WriteLine($"{train.train.name} arrived to its end station {station} and {train.passengers.Count} passenger(s) got off the train");
                                check = true;
                            }
                        }
                    }
                    if (train.trainSchedules[2].stationId == stationList[0].id)
                    {
                        Console.WriteLine($"{train.train.name} will arrive to {stationList[0].stationName} in 3 minutes, setting switch to left");
                        while (check == false)
                        {
                            if (train.trainSchedules[2].arrivalTime == timer.ToString())
                            {
                                station = stationList.Where(p => p.id == train.trainSchedules[2].stationId).ToList().Select(p => p.stationName).First();
                                Console.WriteLine($"{train.train.name} arrived to its end station {station} and {train.passengers.Count} passenger(s) got off the train");
                                check = true;
                            }
                        }
                    }
                }
            }
        }
        public static void ArrivingMidStation(CreateTrainPlaner train)
        {
            bool check = false;
            string station;
            while(check == false)
            {
                if (train.trainSchedules[1].arrivalTime == timer.ToString())
                {
                    lock (_lock)
                    {
                        station = stationList.Where(p => p.id == train.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                        Random rnd = new Random();
                        int random = rnd.Next(0, train.passengers.Count);
                        Console.WriteLine($"{train.train.name} arrived to {station} and {random} passenger(s) got off the train");
                        train.passengers.RemoveRange(0, random);
                        while(check == false)
                        {
                            if (train.trainSchedules[1].departureTime == timer.ToString())
                            {
                                station = stationList.Where(p => p.id == train.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                                Console.WriteLine($"{train.train.name} leaving {station}");
                                check = true;
                            }
                        }
                    }
                }
                    
                
            }
            
        }
        public static void CrossControll(CreateTrainPlaner train)
        {
            bool check = false;
            while(check == false)
            {
                if (train.crossOver[0] == timer)
                {
                    Console.WriteLine($"{train.train.name} closing in to crossroad, closing gate");
                    Thread.Sleep(250);
                }
                if (train.crossOver[1] == timer)
                {
                    Console.WriteLine($"{train.train.name} passed by crossroad, open gate");
                    Thread.Sleep(250);
                    check = true;
                }
            }
        }

        public static void StartEngine(CreateTrainPlaner train)
        {
            string station = stationList.Where(p => p.id == train.trainSchedules[0].stationId).ToList().Select(p => p.stationName).First();
            Console.WriteLine($"{train.train.name} leaving {station} and {train.passengers.Count} passanger(s) aboard the train, setting switch to right");
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

        public static void StartTimer(CreateTrainPlaner train1, CreateTrainPlaner train2)
        {
           
            TimeSpan addMin = TimeSpan.FromMinutes(1);
            timer = new TimeSpan(10, 15, 00);
            for (int i = 0; i < 62; i++)
            {
                
                if (train1.trainSchedules[0].departureTime == timer.ToString())
                {
                    train1.trainThread = new Thread(() => train1.Drive(train1));
                    train1.trainThread.Name = "Train1";
                    train1.trainThread.Start();
                }
                if (train2.trainSchedules[0].departureTime == timer.ToString())
                {
                    train2.trainThread = new Thread(() => train2.Drive(train2));
                    train2.trainThread.Name = "Train2";
                    train2.trainThread.Start();
                }
                timer += addMin;
                Thread.Sleep(200);
                
            }
        }

        public interface IControlRoom
        {
            Train train { get; }
            List<Schedule> trainSchedules { get; set; }
            List<Passenger> trainPassenger { get; set; }
            List<TimeSpan> openCloseCrossover { get; set; }

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