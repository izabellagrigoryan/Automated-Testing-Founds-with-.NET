
using CarPark;
class Car
{
    Engine engine;
    Chassis chassis;
    Transmission transmission;

    string carName;
    List<Car> carsDataset;

    //default constructor
    public Car()
    { }

    //parameterizied constructor
    public Car(Engine engine, Chassis chassis, Transmission transmission, string carName)
    {
        this.engine = new Engine(engine.Power, engine.Volume, engine.Type, engine.Serialnumber);
        this.chassis = new Chassis(chassis.Wheelsnumber, chassis.Number, chassis.Permissibleload);
        this.transmission = new Transmission(transmission.Type, transmission.Numberofgears, transmission.Manufacturer);
        this.carName = carName; 
    }
        
    static void Main(string[] args)
    {
        Car cars = new Car();
        cars.carsDataset = new List<Car>();

        //initialization of cars List
        cars.carsDataset = cars.CreateNewObjects(cars.carsDataset);

        //print cars List on console
        cars.PrintOnConsole(cars.carsDataset);
    }
    //initialization of cars List
    public List<Car> CreateNewObjects(List<Car> carsDataset)
    {
        Car passengerCar = new Car(new Engine(60, 5, "Mustang", "23Nov23"),
                                   new Chassis(4, 190, 2347), new Transmission("Handle", 6, "Manufact"), "Passenger Car" );
        
        Car truck = new Car(new Engine(160, 10, "Belarus", "23Aug23"),new Chassis(4, 190, 2347),
                            new Transmission("Handle", 6, "Manufact"), "Truck");

        Car bus = new Car(new Engine(260, 10, "Ikarus", "23Mar23"), new Chassis(4, 190, 2347),
                          new Transmission("Handle", 6, "Manufact"), "Bus");
       
        Car scooter = new Car(new Engine(160, 2, "Bird", "23Feb23"), new Chassis(4, 190, 2347),
                              new Transmission("Handle", 6, "Manufact"), "Scooter");

        carsDataset.Add(passengerCar);
        carsDataset.Add(truck);
        carsDataset.Add(bus);
        carsDataset.Add(scooter);

        return carsDataset;
    }

    //print cars List on console
    public void PrintOnConsole(List<Car> carsDataset)
    {
        foreach(Car car in carsDataset)
        {
            Console.WriteLine(car.carName);
            car.engine.Print();
            car.chassis.Print();
            car.transmission.Print();
        }
    }
}