﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrainProject
{
    public class Train
    {
        public int id { get; set; }
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

        public Train(List<Train> trainList, int check)
        {
            foreach (var item in trainList)
            {
                if (item.id == check)
                {
                    id = item.id;
                    name = item.name;
                    maxSpeed = item.maxSpeed;
                    operated = item.operated;
                }
            }
        }
    }

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