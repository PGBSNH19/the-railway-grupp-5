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
        public static TrainPlaner trainPlaner;
        public static CreateTrainPlaner createTrainPlaner;
        public static Thread test;
        public static TimeSpan timer;
        public static TimeSpan addMin;

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

            createTrainPlaner = new CreateTrainPlaner(trainPlaner);
            TrainThread trainT = new TrainThread();

            addMin = TimeSpan.FromMinutes(1);
            timer = new TimeSpan(10, 10, 00);

            test = new Thread(new ThreadStart(trainT.Drive));
            test.Start();
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

            public CreateTrainPlaner(IControlRoom test)
            {
                this.train = test.train;
                this.trainSchedules = test.trainSchedules;
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

    public class TrainThread : Program
    {
        public void Drive()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(timer);
                Thread.Sleep(250);
                timer += addMin;

                if (createTrainPlaner.trainSchedules[0].departureTime == timer.ToString())
                {
                    Console.WriteLine($"{createTrainPlaner.train.name} leaving station");
                }

                if (createTrainPlaner.trainSchedules[2].arrivalTime == timer.ToString())
                {
                    Console.WriteLine("Klar");
                }
            }
        }
    }
}