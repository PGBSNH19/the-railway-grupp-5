using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

    class StationList
    {
        public List<Station> InitAvailableStations()
        {
            List<Station> AllStations = new List<Station>();

            string[] station = File.ReadAllLines(Program.StationFilePath);

            foreach (string item in station)
            {
                AllStations.Add(new Station(item));
            }
            return AllStations;

        }
    }
}
