using System;

namespace IFly
{
    public struct Coordinate
    {
        public double xcoord;
        public double ycoord;
        public double zcoord;

        public double path;

        //Count distance of flying object
        public double GetCurrentPosition(Coordinate point)
        {
            this.path = Math.Pow(point.xcoord, 2) + Math.Pow(point.ycoord, 2) + Math.Pow(point.zcoord, 2);
            return this.path;
        }

    }

    interface IFlyable
    {
        double FlyTo(Coordinate point);
        double GetFlyTime(Coordinate point);
    }

    public class Bird : IFlyable
    {
        private Coordinate currentPosition;
        private double time;
        private double speed;
        private double path;


        public Bird()
        {
            //Set bird speed randomly
            Random rnd = new Random();
            this.speed = rnd.Next(0, 20);
        }
        public double FlyTo(Coordinate point)
        {
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);
            return this.path;
        }
        public double GetFlyTime(Coordinate point)
        {
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);
            this.time = this.path / this.speed;
            
            return this.time;
        }
    }

    public class Airplane : IFlyable
    {
        private Coordinate currentPosition;
        private double time;
        private double speed;
        private double path;

        public Airplane()
        {
            //set airplane's initial speed
            this.speed = 200;
        }
        public double FlyTo(Coordinate point)
        {
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);

            //set airplane's speed that increases
            //by 10 km/h every 10 km of flight from an initial speed of 200 km/h
            double x = this.path / 10;
            this.speed = this.speed + x * 10;
            this.time = this.path / this.speed;

            return this.path;
        }
        public double GetFlyTime(Coordinate point)
        {
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);
            this.time = this.path / this.speed;

            return this.time;
        }
    }

    public class Drone : IFlyable
    {
        private Coordinate currentPosition;
        private double time;
        private double speed;
        private double path;
        public Drone()
        {
            //Set drone's speed (km/h);
            this.speed = 100.0;
        }
        public double FlyTo(Coordinate point)
        {
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);
            
            return this.path;           
        }

        public double GetFlyTime(Coordinate point)
        {           
            this.currentPosition = point;
            this.path = this.currentPosition.GetCurrentPosition(point);

            double count = this.path * 60 / this.speed;
            if (count == 0 && this.path != 0.0)
                this.time = 1.0;
            else
                this.time = count/10; //the drone hovers in the air every 10 minutes of flight for 1 minute 

            return this.time;

        }

    }
}