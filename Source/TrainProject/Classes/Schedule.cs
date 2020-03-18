using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrainProject
{
    public class Schedule
    {
        public int traindId { get; }
        public int stationId { get; }
        public string departureTime { get; set; }
        public string arrivalTime { get; }

        public Schedule(string scheduleList)
        {
            string[] part = scheduleList.Split(',');

            traindId = int.Parse(part[0]);
            stationId = int.Parse(part[1]);
            departureTime = part[2] + ":00";
            arrivalTime = part[3] + ":00";
        }
    }

    public class ScheduleList
    {
        public List<Schedule> InitAvailableSchedule()
        {
            List<Schedule> AvailableSchedule = new List<Schedule>();
            string[] tidtabell = File.ReadAllLines(Program.ProductFilePath);

            foreach (string item in tidtabell)
            {
                AvailableSchedule.Add(new Schedule(item));
            }

            return AvailableSchedule;
        }
    }
}