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
            //CreateDatabase();

            //var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();
            //var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            //CreateTrainPlaner testTrainPlaner1 = new CreateTrainPlaner(trainPlaner1);
            //CreateTrainPlaner testTrainPlaner2 = new CreateTrainPlaner(trainPlaner2);

            //StartTimer(testTrainPlaner1, testTrainPlaner2);

            CreateDatabase();

            var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList).AddPassengers(passengerList).CrossoverControll();

            CreateTrainPlaner train1 = new CreateTrainPlaner(trainPlaner1);
            CreateTrainPlaner train2 = new CreateTrainPlaner(trainPlaner2);
            new Thread(() =>
            {
                TimeSpan addMin = TimeSpan.FromMinutes(1);
                timer = new TimeSpan(10, 15, 00);
                for (int i = 0; i < 62; i++)
                {
                    Console.WriteLine(timer);
                    if (train1.trainSchedules[0].departureTime == timer.ToString())
                    {
                        train1.trainThread = new Thread(() => train1.Drive1(train1));
                        train1.trainThread.Start();
                        train1.trainThread.Join();
                    }
                    if (train1.trainSchedules[1].arrivalTime == timer.ToString())
                    {
                        train1.trainThread = new Thread(() => train1.Drive2(train1));
                        train1.trainThread.Start();
                        train1.trainThread.Join();
                    }
                    if (train1.trainSchedules[1].departureTime == timer.ToString())
                    {
                        train1.trainThread = new Thread(() => train1.Drive3(train1));
                        train1.trainThread.Start();
                        train1.trainThread.Join();
                    }
                    if (train1.trainSchedules[2].arrivalTime == timer.ToString())
                    {
                        train1.trainThread = new Thread(() => train1.Drive4(train1));
                        train1.trainThread.Start();
                        train1.trainThread.Join();
                    }
                    //if (train2.trainSchedules[0].departureTime == timer.ToString())
                    //{
                    //    train2.trainThread = new Thread(() => train2.Drive(train2));
                    //    train2.trainThread.Start();
                    //}

                    timer += addMin;
                    Thread.Sleep(300);
                    Console.WriteLine("----------------");
                }
            }).Start();
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

        //public static void StartTimer(CreateTrainPlaner train1, CreateTrainPlaner train2)
        //{
        //    string station;
        //    TimeSpan addMin = TimeSpan.FromMinutes(1);
        //    timer = new TimeSpan(10, 15, 00);
        //    for (int i = 0; i < 62; i++)
        //    {
        //        Console.WriteLine(timer);
        //        if (train1.trainSchedules[0].departureTime == timer.ToString())
        //        {
        //            train1.trainThread = new Thread(() => train1.Drive(train1));
        //            train1.trainThread.Start();
        //        }
        //        if(train2.trainSchedules[0].departureTime == timer.ToString())
        //        {
        //            train2.trainThread = new Thread(() => train2.Drive(train2));
        //            train2.trainThread.Start();
        //        }
        //        timer += addMin;
        //        Thread.Sleep(300);
        //        Console.WriteLine("----------------");
        //    }
        //}

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