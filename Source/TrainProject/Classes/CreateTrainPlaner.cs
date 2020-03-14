﻿using System;
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
        public Thread trainThread;

        public CreateTrainPlaner(IControlRoom test)
        {
            this.train = test.train;
            this.trainSchedules = test.trainSchedules;
            this.passengers = test.trainPassenger;
        }

        public void DriveTrack1(CreateTrainPlaner driveTest)
        {
            bool check = false;
            string station;

            while (check == false)
            {
                if (driveTest.trainSchedules[0].departureTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[0].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg1 {driveTest.train.name} leaving {station} and {driveTest.passengers.Count} passanger(s) aboard the train");
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[1].arrivalTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                    Random rnd = new Random();
                    int random = rnd.Next(0, passengers.Count);
                    Console.WriteLine($"Tåg1 {driveTest.train.name} arrived to {station} and {random} passenger(s) got off the train");
                    passengers.RemoveRange(0, random);
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[1].departureTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg1 {driveTest.train.name} leaving {station}");
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[2].arrivalTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[2].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg1 {driveTest.train.name} arrived to its end station {station} and {passengers.Count} passenger(s) got off the train");
                    check = true;
                }
            }
        }

        public void DriveTrack2(CreateTrainPlaner driveTest)
        {
            bool check = false;
            string station;

            while (check == false)
            {
                if (driveTest.trainSchedules[0].departureTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[0].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg2 {driveTest.train.name} leaving {station} and {driveTest.passengers.Count} passanger(s) aboard the train");
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[1].arrivalTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                    Random rnd = new Random();
                    int random = rnd.Next(0, passengers.Count);
                    Console.WriteLine($"Tåg2 {driveTest.train.name} arrived to {station} and {random} passenger(s) got off the train");
                    passengers.RemoveRange(0, random);
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[1].departureTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[1].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg2 {driveTest.train.name} leaving {station}");
                    Thread.Sleep(350);
                }

                if (driveTest.trainSchedules[2].arrivalTime == timer.ToString())
                {
                    station = stationList.Where(p => p.id == driveTest.trainSchedules[2].stationId).ToList().Select(p => p.stationName).First();
                    Console.WriteLine($"Tåg2 {driveTest.train.name} arrived to its end station {station} and {passengers.Count} passenger(s) got off the train");
                    check = true;
                }
            }
        }
    }
}