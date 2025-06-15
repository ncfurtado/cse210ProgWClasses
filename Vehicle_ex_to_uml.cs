using System;

// Level 1: Base class
public abstract class Vehicle
{
    protected string _brand;
    protected string _model;
    protected int _year;
    protected double _price;

    public Vehicle(string brand, string model, int year, double price)
    {
        _brand = brand;
        _model = model;
        _year = year;
        _price = price;
    }

    // Abstract method - must be implemented by subclasses
    public abstract void Start();

    // Concrete method - inherited by all subclasses
    public void DisplayInfo()
    {
        Console.WriteLine($"{_year} {_brand} {_model} - ${_price:N0}");
    }

    // Virtual method that can be overridden
    public virtual void Stop()
    {
        Console.WriteLine("Vehicle is stopping...");
    }
}


// Level 2: Intermediate classes
public class LandVehicle : Vehicle
{
    protected int _wheels;
    protected string _fuelType;

    public LandVehicle(string brand, string model, int year, double price,
                      int wheels, string fuelType)
        : base(brand, model, year, price)
    {
        _wheels = wheels;
        _fuelType = fuelType;
    }

    public override void Start()
    {
        Console.WriteLine("Land vehicle engine starting...");
    }

    public void Drive()
    {
        Console.WriteLine($"Driving on land with {_wheels} wheels");
    }
}


public class WaterCraft : Vehicle
{
    protected string _propulsionType;
    protected bool _hasAnchor;

    public WaterCraft(string brand, string model, int year, double price,
                       string propulsionType, bool hasAnchor)
        : base(brand, model, year, price)
    {
        _propulsionType = propulsionType;
        _hasAnchor = hasAnchor;
    }

    public override void Start()
    {
        Console.WriteLine("Water vehicle engine starting...");
    }

    public void Sail()
    {
        Console.WriteLine($"Sailing using {_propulsionType} propulsion");
    }

    public void Anchor()
    {
        if (_hasAnchor)
        {
            Console.WriteLine("Dropping anchor");
        }
        else
        {
            Console.WriteLine("No anchor available");
        }
    }
}


public class AirCraft : Vehicle
{
    protected int _maxAltitude;
    protected string _engineType;

    public AirCraft(string brand, string model, int year, double price,
                     int maxAltitude, string engineType)
        : base(brand, model, year, price)
    {
        _maxAltitude = maxAltitude;
        _engineType = engineType;
    }

    public override void Start()
    {
        Console.WriteLine($"Air vehicle {_engineType} engine starting...");
    }

    public void Fly()
    {
        Console.WriteLine($"Flying at maximum altitude of {_maxAltitude:N0} feet");
    }

    public void Land()
    {
        Console.WriteLine("Landing the aircraft");
    }
}


// Level 3: Specific vehicle types
public class Car : LandVehicle
{
    private int _doors;
    private bool _isConvertible;

    public Car(string brand, string model, int year, double price,
               string fuelType, int doors, bool isConvertible)
        : base(brand, model, year, price, 4, fuelType) // Cars have 4 wheels
    {
        _doors = doors;
        _isConvertible = isConvertible;
    }

    public override void Start()
    {
        Console.WriteLine("Car ignition turned on, engine purring...");
    }

    public override void Stop()
    {
        Console.WriteLine("Car is parking and engine turned off");
    }

    public void OpenTrunk()
    {
        Console.WriteLine("Opening car trunk");
    }

    public void ToggleConvertibleTop()
    {
        if (_isConvertible)
        {
            Console.WriteLine("Toggling convertible top");
        }
        else
        {
            Console.WriteLine("This car doesn't have a convertible top");
        }
    }
}


public class Motorcycle : LandVehicle
{
    private string _bikeType;
    private bool _hasSidecar;

    public Motorcycle(string brand, string model, int year, double price,
                     string fuelType, string bikeType, bool hasSidecar)
        : base(brand, model, year, price, 2, fuelType) // Motorcycles have 2 wheels
    {
        _bikeType = bikeType;
        _hasSidecar = hasSidecar;
    }

    public override void Start()
    {
        Console.WriteLine("Motorcycle roaring to life!");
    }

    public void Wheelie()
    {
        Console.WriteLine($"Performing a wheelie on the {_bikeType}");
    }

    public void AddPassenger()
    {
        if (_hasSidecar)
        {
            Console.WriteLine("Passenger can ride in the sidecar");
        }
        else
        {
            Console.WriteLine("Passenger rides behind the driver");
        }
    }
}


public class Sailboat : WaterCraft
{
    private int _numSails;
    private string _hullMaterial;

    public Sailboat(string brand, string model, int year, double price,
                   int numSails, string hullMaterial)
        : base(brand, model, year, price, "Wind", true)
    {
        _numSails = numSails;
        _hullMaterial = hullMaterial;
    }

    public override void Start()
    {
        Console.WriteLine("Raising sails to catch the wind...");
    }

    public void AdjustSails()
    {
        Console.WriteLine($"Adjusting {_numSails} sails for optimal wind");
    }

    public void CheckHull()
    {
        Console.WriteLine($"Inspecting {_hullMaterial} hull for damage");
    }
}


public class Airplane : AirCraft
{
    private int _passengerCapacity;
    private string _aircraftType;

    public Airplane(string brand, string model, int year, double price,
                   int maxAltitude, string engineType, int passengerCapacity,
                   string aircraftType)
        : base(brand, model, year, price, maxAltitude, engineType)
    {
        _passengerCapacity = passengerCapacity;
        _aircraftType = aircraftType;
    }

    public override void Start()
    {
        Console.WriteLine("Airplane engines spooling up for takeoff...");
    }

    public void Takeoff()
    {
        Console.WriteLine($"{_aircraftType} taking off with {_passengerCapacity} passengers");
    }

    public void ServePassengers()
    {
        Console.WriteLine($"Flight attendants serving {_passengerCapacity} passengers");
    }
}


// Demonstration class
public class Program
{
    public static void Main()
    {
        // Create instances of different vehicles
        Car sedan = new Car("Toyota", "Camry", 2023, 28000, "Gasoline", 4, false);
        Motorcycle sportsBike = new Motorcycle("Yamaha", "R1", 2023, 18000,
                                              "Gasoline", "Sport", false);
        Sailboat yacht = new Sailboat("Beneteau", "Oceanis", 2022, 150000, 3, "Fiberglass");
        Airplane jet = new Airplane("Boeing", "737", 2021, 89000000, 41000,
                                   "Turbofan", 189, "Commercial");

        // Demonstrate polymorphism - all vehicles can be treated as Vehicle objects
        Vehicle[] vehicles = { sedan, sportsBike, yacht, jet };

        Console.WriteLine("=== Vehicle Information ===");
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.DisplayInfo(); // Inherited method
            vehicle.Start();       // Overridden method (polymorphism)
            Console.WriteLine();
        }

        Console.WriteLine("=== Specific Vehicle Behaviors ===");

        // Demonstrate specific behaviors
        sedan.Drive();
        sedan.OpenTrunk();
        sedan.ToggleConvertibleTop();
        Console.WriteLine();

        sportsBike.Drive();
        sportsBike.Wheelie();
        sportsBike.AddPassenger();
        Console.WriteLine();

        yacht.Sail();
        yacht.AdjustSails();
        yacht.Anchor();
        Console.WriteLine();

        jet.Fly();
        jet.Takeoff();
        jet.ServePassengers();
        jet.Land();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
