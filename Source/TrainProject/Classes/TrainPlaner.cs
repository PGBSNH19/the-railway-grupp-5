using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TrainProject.Program;

namespace TrainProject
{
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
}