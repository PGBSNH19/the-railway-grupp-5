namespace TrainProject
{
    public class Schedule
    {
        public int traindId { get; }
        public int stationId { get; }
        public string departureTime { get; }
        public string arrivalTime{ get;   }


        public Schedule(string scheduleList)
        {
            string[] part = scheduleList.Split(',');

            traindId = int.Parse(part[0]);
            stationId = int.Parse(part[1]);
            departureTime = part[2];
            arrivalTime = part[3];       
        }
    }
}
