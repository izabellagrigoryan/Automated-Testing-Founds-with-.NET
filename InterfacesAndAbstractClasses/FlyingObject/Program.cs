using System;
using IFly;

namespace FlyingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Airplane airplane = new Airplane();
            Drone drone = new Drone();

            Coordinate coordinate = new Coordinate();

            Console.Write("Please input X coordinate of new point(km): ");
            coordinate.xcoord = double.Parse(Console.ReadLine());
            Console.Write("Please input Y coordinate of new point(km): ");
            coordinate.ycoord = double.Parse(Console.ReadLine());
            Console.Write("Please input Z coordinate of new point(km): ");
            coordinate.zcoord = double.Parse(Console.ReadLine());

            double distance = bird.FlyTo(coordinate);
            Console.WriteLine($"Bird has flown the distance:  {distance} km");
            distance = airplane.FlyTo(coordinate);
            Console.WriteLine($"Airplane has flown the distance:  {distance} km");
            distance = drone.FlyTo(coordinate);
            Console.WriteLine($"Drone has flown the distance:  {distance} km");

            double time = bird.GetFlyTime(coordinate);
            Console.WriteLine($"Time of bird flying:  {time} h");
            time = airplane.GetFlyTime(coordinate);
            Console.WriteLine($"Time of airplane flying:  {time} h");
            time = drone.GetFlyTime(coordinate);
            Console.WriteLine($"Time of drone flying:  {time} m");
            Console.ReadLine();

        }
    }
}