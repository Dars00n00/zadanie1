namespace Cw3;

public class Ship
{
    public string ShipName { get; set; }
    public List<Container> Containers { get; private set; }
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }

    // Konstruktor
    public Ship(string shipName, double maxSpeed, int maxContainers, double maxWeight)
    {
        ShipName = shipName;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count < MaxContainers && GetTotalWeight() + container.Weight/1000 <= MaxWeight)
        {
            Containers.Add(container);
        }
        else
        {
            Console.WriteLine("Can't add another container, mass or number of containers is too high");
        }
    }
    private double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in Containers)
        {
            totalWeight += container.Weight/1000;
        }
        return totalWeight;
    }

    public void DisplayShipInfo()
    {
        Console.WriteLine($"Ship: {ShipName}");
        Console.WriteLine($"Max speed: {MaxSpeed} knots");
        Console.WriteLine($"Max num of containers: {MaxContainers}");
        Console.WriteLine($"Max weight of containers: {MaxWeight} tons");
        Console.WriteLine($"Number of containers: {Containers.Count}");
        Console.WriteLine($"Weight of containers: {GetTotalWeight()} tons");
    }

    public void DisplayContainers()
    {
        foreach (var c in Containers)
        {
            Console.WriteLine(c);
        }
    }
}