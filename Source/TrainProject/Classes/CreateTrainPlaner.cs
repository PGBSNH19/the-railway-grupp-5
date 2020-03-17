using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrainProject
{
    public class CreateTrainPlaner : Program
    {
        public Train train { get; }
        public List<Schedule> trainSchedules { get; }
        public List<Passenger> passengers { get; set; }
        public List<TimeSpan> crossOver { get; set; }
        public Thread trainThread;

        public CreateTrainPlaner(IControlRoom test)
        {
            this.train = test.train;
            this.trainSchedules = test.trainSchedules;
            this.passengers = test.trainPassenger;
            this.crossOver = test.openCloseCrossover;
        }

        public void Drive(CreateTrainPlaner driveTest)
        {
            StartEngine(this);
            CrossControll(this);
            ArrivingMidStation(this);
            ArrivingEndStation(this);          
        } 
    }
}