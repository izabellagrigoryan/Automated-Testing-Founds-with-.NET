namespace CarPark
{
    public class Engine
    {
        public int Power { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public string Serialnumber { get; set; }

        public Engine(int power, double volume, string type, string serialnumber)
        { 
            this.Power = power;
            this.Volume = volume;
            this.Type = type;
            this.Serialnumber = serialnumber;

        }
        public void Print()
        {
            Console.WriteLine(this.Power + ", " + this.Volume + ", " + this.Type + ", " + this.Serialnumber);
        }      
    }

    public class Chassis
    {
        public int Wheelsnumber { get; set; }
        public int Number { get; set; }
        public int Permissibleload { get; set; }

        public Chassis(int wheelsnumber, int number, int permissibleload)
        {
            this.Wheelsnumber = wheelsnumber;
            this.Number = number;
            this.Permissibleload = permissibleload;

        }
        public void Print()
        {
            Console.WriteLine(this.Wheelsnumber + ", " + this.Number + ", " + this.Permissibleload);
        }

    }
    public class Transmission
    {
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public int Numberofgears { get; set; }

        public Transmission(string type, int numberofgears, string manufacturer)
        {
            this.Type = type;
            this.Numberofgears = numberofgears;
            this.Manufacturer = manufacturer;
        }
        public void Print()
        {
            Console.WriteLine(this.Type + ", " + this.Manufacturer + ", " + this.Numberofgears);
        }

    }
}