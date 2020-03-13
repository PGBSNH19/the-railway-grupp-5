﻿using System;
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
        public static TimeSpan timer;
 

        public static void Main(string[] args)
        {

            CreateDatabase();

            var trainPlaner1 = new TrainPlaner(trainList, 2).FollowSchedule(scheduleList);
            var trainPlaner2 = new TrainPlaner(trainList, 3).FollowSchedule(scheduleList);

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
        }

        public static void StartTimer() 
        {
            TimeSpan addMin = TimeSpan.FromMinutes(1);
            timer = new TimeSpan(10, 15, 00);
            for (int i = 0; i < 62; i++)
            {
                Console.WriteLine(timer);
                timer += addMin;
                Thread.Sleep(200);
            }
        }

        public interface IControlRoom
        {
            Train train { get; }
            List<Schedule> trainSchedules { get; set; }

            IControlRoom FollowSchedule(List<Schedule> schedules);
        }

        public class TrainPlaner : IControlRoom
        {
            public Train train { get; }
            public List<Schedule> trainSchedules { get; set; }

            public TrainPlaner(List<Train> trainList, int check)
            {
                this.train = trainList.Where(p => p.id == check).ToList().First();
            }

            public IControlRoom FollowSchedule(List<Schedule> schedules)
            {
                trainSchedules = schedules.Where(x => x.traindId == train.id).ToList();
                return this;
            }
        }

        public class CreateTrainPlaner
        {
            public Train train { get; }
            public List<Schedule> trainSchedules { get; }
            public Thread trainThread;

            public CreateTrainPlaner(IControlRoom test)
            {
                this.train = test.train;
                this.trainSchedules = test.trainSchedules;
            }

            public void Drive(CreateTrainPlaner driveTest)
            {
                bool check = false;
                string station;
                while(check == false) {
                    
                    if(driveTest.trainSchedules[0].departureTime == timer.ToString())
                    {
                        
                        station = stationList.Where(p => p.id == driveTest.trainSchedules[0].stationId).ToList().Select(p => p.stationName).First();
                        Console.WriteLine($"{driveTest.train.name} leaving {station}");
                        Thread.Sleep(300);
                    }
                    if(driveTest.trainSchedules[1].arrivalTime == timer.ToString()) 
                    {
                        station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                        Console.WriteLine($"{driveTest.train.name} arrived to {station}");
                        Thread.Sleep(300);

                    }
                    if(driveTest.trainSchedules[1].departureTime == timer.ToString())
                    {
                        station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                        Console.WriteLine($"{driveTest.train.name} leaving {station}");
                        Thread.Sleep(300);
                    }

                    if (driveTest.trainSchedules[2].arrivalTime == timer.ToString())
                    {
                        station = stationList.Where(p => p.id == driveTest.trainSchedules[2].stationId).ToList().Select(p => p.stationName).First();
                        Console.WriteLine($"{driveTest.train.name} arrived to its end station {station}");
                        check = true;
                    }
                }
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