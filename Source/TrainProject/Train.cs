namespace TrainProject
{
    public class Train
    {
        public int id { get; }
        public string name { get; }
        public int maxSpeed { get; }
        public bool operated { get; }

        public Train(string trianList)
        {
            string[] convert = trianList.Split(",");
            id = int.Parse(convert[0]);
            name = convert[1];
            maxSpeed = int.Parse(convert[2]);
            operated = bool.Parse(convert[3]);
        }
    }
}
