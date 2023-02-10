
using System.Xml.Linq;
using CarPark;

class Cars
{
    Engine engine;
    Chassis chassis;
    Transmission transmission;
    string carName;
    //default constructor
    public Cars()
    { }
    //parameterizied constructor
    public Cars(Engine engine, Chassis chassis, Transmission transmission, string carName)
    {
        this.engine = new Engine(engine.Power, engine.Volume, engine.Type, engine.Serialnumber);
        this.chassis = new Chassis(chassis.Wheelsnumber, chassis.Number, chassis.Permissibleload);
        this.transmission = new Transmission(transmission.Type, transmission.Numberofgears, transmission.Manufacturer);
        this.carName = carName; 
    }

    
    List<Cars> carsDataset;
    static void Main(String[] args)
    {
        Cars cars = new Cars();
        cars.carsDataset = new List<Cars>();
        
        //initialization of cars List
        cars.carsDataset = cars.CreateNewObjects(cars.carsDataset);

        //1. Write in file All information about all vehicles an engine capacity of which is more than 1.5 liters
        cars.VolumeMore(cars.carsDataset);
        //2. Write in file Engine type, serial number and power rating for all buses and trucks
        cars.BusTruck(cars.carsDataset);    
        //3. All information about all vehicles, grouped by transmission type
        cars.TransmissionType(cars.carsDataset);    
    }

    //initialization of cars List
    public List<Cars> CreateNewObjects(List<Cars> carsDataset)
    {
        Cars passengerCar = new Cars(new Engine(60, 5, "Mustang", "23Nov23"),
                                     new Chassis(4, 190, 2347), new Transmission("Handle", 6, "Manufact"), "Passenger Car");

        Cars truck = new Cars(new Engine(160, 10, "Belarus", "23Aug23"), new Chassis(4, 190, 2347),
                              new Transmission("Handle", 6, "Manufact"), "Truck");

        Cars bus = new Cars(new Engine(260, 10, "Ikarus", "23Mar23"), new Chassis(4, 190, 2347),
                            new Transmission("Handle", 6, "Manufact"), "Bus");

        Cars scooter = new Cars(new Engine(160, 2, "Bird", "23Feb23"), new Chassis(4, 190, 2347),
                                new Transmission("Handle", 6, "Manufact"), "Scooter");

        Cars vehicle = new Cars(new Engine(160, 2, "Bird", "23Feb23"), new Chassis(40, 1900, 2347),
                                new Transmission("Automat", 10, "Manufact"), "Vehicle");

        carsDataset.Add(passengerCar);
        carsDataset.Add(truck);
        carsDataset.Add(bus);
        carsDataset.Add(scooter);
        carsDataset.Add(vehicle);

        return carsDataset;
    }

    public void VolumeMore(List<Cars> carsDataset)
    {
        //LINQ Query for all information about all vehicles an engine capacity of which is more than 1.5 liters
        var carsubset = from theCar in carsDataset
                        where theCar.engine.Volume > 1.5
                        select theCar;

        XElement xCarsubset = XElement.Load("..\\..\\VolumeMore1.5L.xml");


        foreach (Cars theCar in carsubset)
        {
            //write in a Bus&Truck.xml XML file
            xCarsubset.Add(new XElement("Car",
                           new XElement("CarName", theCar.carName),
                           new XElement("Engine", new XAttribute("Volume", theCar.engine.Volume + "Liter"))));


        }
        //save in xml file
        xCarsubset.Save("..\\..\\VolumeMore1.5L.xml");

    }
    public void BusTruck(List<Cars> carsDataset)
    {
        //LINQ QUERY for Engine type, serial number and power rating for all buses and trucks
        var carsubset = from theCar in carsDataset
                        where theCar.carName == "Bus" || theCar.carName == "Truck"
                        select theCar;

        XElement xCarsubset = XElement.Load("..\\..\\Bus&Truck.xml");

        foreach (Cars theCar in carsubset)
        {
            //write in a Bus&Truck.xml XML file
            xCarsubset.Add(new XElement("Car",
                           new XElement("CarName", theCar.carName),
                           new XElement("Engine", new XAttribute("Type", theCar.engine.Type)),
                           new XElement("Engine", new XAttribute("SerialNumber", theCar.engine.Serialnumber)),
                           new XElement("Engine", new XAttribute("Power", theCar.engine.Power))));
        }
        //save in xml file
        xCarsubset.Save("..\\..\\Bus&Truck.xml");
    }
    public void TransmissionType(List<Cars> carsDataset)
    {
        //LINQ QUERY for all information about all vehicles, grouped by transmission type
        var carsallset = carsDataset.GroupBy(p => p.transmission.Type, p => p).ToList();

        XElement xCarsubset = XElement.Load("..\\..\\AllbyTransmissionType.xml");

        foreach (var theCar in carsallset)
        {
            string transtype = theCar.Key.ToString();// thetempCar.transmission.Type.ToString();
            //write in a AllbyTransmission.xml XML file
            xCarsubset.Add(new XElement("TransmissionType", transtype));
            foreach (Cars thetempCar in theCar)
            {
                //add in a AllbyTransmission.xml XML file
                xCarsubset.Add(new XElement("Car",
                               new XElement("CarName", thetempCar.carName),
                               new XElement("Engine", new XAttribute("Type", thetempCar.engine.Type)),
                               new XElement("Engine", new XAttribute("SerialNumber", thetempCar.engine.Serialnumber)),
                               new XElement("Engine", new XAttribute("Power", thetempCar.engine.Power)),
                               new XElement("Engine", new XAttribute("Volume", thetempCar.engine.Volume)),
                               new XElement("Chassis", new XAttribute("Wheelsnumber", thetempCar.chassis.Wheelsnumber)),
                               new XElement("Chassis", new XAttribute("Number", thetempCar.chassis.Number)),
                               new XElement("Chassis", new XAttribute("PermissibleLoad", thetempCar.chassis.Permissibleload)),
                               new XElement("Transmission", new XAttribute("Manufacturer", thetempCar.transmission.Manufacturer)),
                               new XElement("Transmission", new XAttribute("NumberofGears", thetempCar.transmission.Numberofgears))));
            }
        }
        //save in xml file
        xCarsubset.Save("..\\..\\AllbyTransmissionType.xml");
    }
}

