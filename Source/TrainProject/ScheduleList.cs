using System.Collections.Generic;
using System.IO;

namespace TrainProject
{
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
