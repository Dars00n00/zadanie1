namespace Cw3;

public abstract class Container
{
    private static int counter = 0;
    
    
    public virtual string Cargo { get; set; }
    public double MaxCargoMass { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    
    
    private double _cargoMass;
    public double CargoMass
    {
        get
        {
            return _cargoMass;
        }
        set
        {
            if (value < 0)
            {
                throw new NegativeCargoMassException("Cargo mass cannot be negative!");
            } 
            else if (value > MaxCargoMass)
            {
                throw new OverflowException("Cargo mass cannot be greater than max!");
            }
            else
            {
                _cargoMass = value;
            }
        }
    }
    
    public string Serial { get; private set; }
    protected void SetSerial(char type)
    {
        var serial = "KON-";
        serial += type.ToString() + "-";
        serial += counter++;
        Serial = serial;
    }
    
    public Container(string cargo, 
                     double maxCargoMass,
                     double height, double weight, double depth)
    {
        Cargo = cargo;
        MaxCargoMass = maxCargoMass;
        Height = height;
        Weight = weight;
        Depth = depth;
    }
    
    public virtual void EmptyCargo()
    {
        CargoMass = 0;
        Console.WriteLine("Cargo emptied");
    }

    public virtual void LoadCargo(double cargoMass, bool isCargoDangerous)
    {
        CargoMass = cargoMass;
        Console.WriteLine($"Cargo loaded {CargoMass}kg");
    }

    public override string ToString()
    {
        return $"Container number: {Serial}  Cargo: {CargoMass}kg of {Cargo}  Size: h:{Height} w:{Weight} d:{Depth}";
    }
    
}

public class FluidContainer : Container, IHazardNotifier
{
    private const char ContainerType = 'L';
    
    public FluidContainer(string cargo,
                          double maxCargoMass,
                          double height, double weight, double depth) 
        : base(cargo,maxCargoMass, height, weight, depth)
    {
        SetSerial(ContainerType);
    }
    
    public override void LoadCargo(double cargoMass, bool isCargoDangerous)
    {
        if (isCargoDangerous)
        {
            if (cargoMass/MaxCargoMass * 100 > 50)
            {
                Notify();
            }
            else
            {
                base.LoadCargo(cargoMass, isCargoDangerous);
            }
        }
        else
        {
            if (cargoMass/MaxCargoMass * 100 > 90)
            {
                Notify();
            }
            else
            {
                base.LoadCargo(cargoMass, isCargoDangerous);
            }
        }
    }

    public void Notify()
    {
        Console.WriteLine($"Dangerous situation in fluid container {Serial}");
    }
    
}


public class GasContainer : Container, IHazardNotifier
{
    private const char _containerType = 'G';
    public double Pressure { get; set; }

    public GasContainer(string cargo, 
                        double maxCargoMass,
                        double height, double weight, double depth, double pressure)
        : base(cargo,maxCargoMass, height, weight, depth)
    {
        SetSerial(_containerType);
        Pressure = pressure;
    }
    
    public override void EmptyCargo()
    {
        CargoMass = CargoMass * 0.05;
        Console.WriteLine($"Cargo emptied (5% of cargo mass left={CargoMass})");
    }
    
    public void Notify()
    {
        Console.WriteLine($"Dangerous situation in gas container {Serial}");
    }
    
    public override string ToString()
    {
        return $"Container number: {Serial}  Cargo: {CargoMass}kg of {Cargo}  Size: h:{Height} w:{Weight} d:{Depth}  Pressure: {Pressure}";
    }
}


public class CoolingContainer : Container, IHazardNotifier
{
    private const char ContainerType  = 'C';
    private readonly Dictionary<string, double> Cooling = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 }, { "Chocolate", 18 }, { "Fish", 2 }, { "Meat", -15 },
        { "Ice cream", -18 }, { "Frozen pizza", -30 }, { "Cheese", 7.2 }, { "Sauseges", 5 },
        { "Butter", 20.5 }, { "Eggs", 19 },
    };

    private double _temperature;
    public double Temperature
    {
        get
        {
            return _temperature;
        }
        set
        {
            if (value < Cooling[_cargo])
            {
                throw new InvalidTemperatureException("Invalid temperature");
            }
            _temperature = value;
        }
    }
    
    private string _cargo;
    public override string Cargo
    {
        get
        {
            return _cargo;
        }
        set
        {
            if (!Cooling.ContainsKey(value))
            {
                throw new UnknownCoolingProduct("{Cargo} not found in cooling list");
            }
            _cargo = value;
        }
    }
    

    public CoolingContainer(string cargo, 
                            double maxCargoMass,
                            double height, double weight, double depth, 
                            double temperature)
        : base(cargo, maxCargoMass, height, weight, depth)
    {
        SetSerial(ContainerType);
        Temperature = temperature;
    }
    
    public override void EmptyCargo()
    {
        CargoMass = 0;
        Console.WriteLine("Cargo emptied");
    }

    public override void LoadCargo(double cargoMass, bool isCargoDangerous)
    {
        CargoMass = cargoMass;
        Console.WriteLine($"Cargo loaded {cargoMass}kg");
    }
    
    public void Notify()
    {
        Console.WriteLine($"Dangerous situation in cooling container {Serial}");
    }
    
    public override string ToString()
    {
        return $"Container number: {Serial}  Cargo: {CargoMass}kg of {Cargo}  Size: h:{Height} w:{Weight} d:{Depth}  Temperature: {Temperature} Min temperature: {Cooling[Cargo]}";
    }
    
}