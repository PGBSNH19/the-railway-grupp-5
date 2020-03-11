using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;

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
        public static TrainPlaner trainPlaner;
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
            Thread test = new Thread(Drive);
            Console.WriteLine();
            timer = new TimeSpan(10, 10, 00);
            //test.Start();
            
        }

        static void Drive()
        {
            TimeSpan addMin = TimeSpan.FromMinutes(1);

            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine(timer);
                if (trainPlaner.trainSchedules[0].departureTime == timer.ToString())
                {
                    Console.WriteLine("Train leaving");
                }
                timer += addMin;
                Thread.Sleep(250);
            }    
        }
    }

    public interface IControlRoom
    {
        IControlRoom FollowSchedule(List<Schedule> schedules);
        
        
    }

    public class TrainPlaner : IControlRoom
    {
        public Train train 
        {
            get;
        }
        public List<Schedule> trainSchedules = new List<Schedule>();
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

    class Switch
    {
        bool turnRight;
    }

    class LevelCrossing
    {
        bool open;
    }

 

  
}
