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
        public static TimeSpan timer;
 

        public static void Main(string[] args)
        {
            ScheduleList p = new ScheduleList();
            scheduleList = p.InitAvailableSchedule();

            TrainList promp = new TrainList();
            trainList = promp.InitAvailableTrain();

            StationList SList = new StationList();
            stationList = SList.InitAvailableStations();

            var train1 = new Train(trainList, 2);
            var train2 = new Train(trainList, 3);

            var trainPlaner = new TrainPlaner(train1).FollowSchedule(scheduleList);

            CreateTrainPlaner testTrainPlaner = new CreateTrainPlaner(trainPlaner);
            testTrainPlaner.trainThread = new Thread(() => testTrainPlaner.Drive(testTrainPlaner));

            CreateTrainPlaner newTest = new CreateTrainPlaner(trainPlaner);
            newTest.trainThread = new Thread(() => newTest.Drive(newTest));
            newTest.trainThread.Start();
            TimeSpan addMin = TimeSpan.FromMinutes(1);
            timer = new TimeSpan(10, 10, 00);
            for(int i = 0; i< 50; i++)
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

            public TrainPlaner(Train train)
            {
                this.train = train;
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
                while(check == false) {
                    
                    if(driveTest.trainSchedules[0].departureTime == timer.ToString())
                    {
                        Console.WriteLine($"{driveTest.train.name} leaving station");
                        Thread.Sleep(500);
                    }

                    if (driveTest.trainSchedules[2].arrivalTime == timer.ToString())
                    {
                        Console.WriteLine("Klar");
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