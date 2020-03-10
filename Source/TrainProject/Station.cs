namespace TrainProject
{
    public class Station
    {
        public int id { get; }
        public string stationName { get; }
        public bool endStation { get; }

        public Station(string list)
        {
            string[] convert = list.Split("|");

            id = int.Parse(convert[0]);
            stationName = convert[1];
            endStation = bool.Parse(convert[2]);
        }
    }
}
