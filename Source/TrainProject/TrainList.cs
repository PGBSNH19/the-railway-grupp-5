using System.Collections.Generic;
using System.IO;

namespace TrainProject
{
    public class TrainList
    {
        public List<Train> InitAvailableTrain()
        {
            List<Train> AvailableTrain = new List<Train>();
            string[] trains = File.ReadAllLines(Program.TrainFilePath);

            foreach (string item in trains)
            {
                AvailableTrain.Add(new Train(item));
            }

            return AvailableTrain;
        }
    }
}
