using Cw3;

Console.WriteLine("statek:");
Ship ship = new Ship("Black Pearl", 40, 6, 0.3);
ship.DisplayShipInfo();


Console.WriteLine("\nKontenerowce na plyny:");
FluidContainer fc1 = new FluidContainer("milk",150, 78, 54, 67.56);
fc1.LoadCargo(78, false);
Console.WriteLine(fc1.ToString());
fc1.EmptyCargo();
Console.WriteLine(fc1.ToString());

FluidContainer fc2 = new FluidContainer("oil",150, 78, 54, 67.56);
fc2.LoadCargo(78, true);
fc2.LoadCargo(25, true);
Console.WriteLine(fc2.ToString());


Console.WriteLine("\nKontenerowce na gazy:");
GasContainer gc1 = new GasContainer("gas",600, 78, 54, 67.56, 1012);
gc1.LoadCargo(600, true);
gc1.EmptyCargo();
Console.WriteLine(gc1.ToString());

GasContainer gc2 = new GasContainer("gas",600, 78, 54, 67.56, 1012);
gc2.LoadCargo(600, true);
Console.WriteLine(gc2.ToString());


Console.WriteLine("\nKontenerowce chlodnicze:");
CoolingContainer cc1 = new CoolingContainer("Bananas", 150, 78, 54, 67.56, 14);
cc1.LoadCargo(78, false);
Console.WriteLine(cc1.ToString());
try
{
    CoolingContainer cc2 = new CoolingContainer("Cos tam", 150, 78, 54, 67.56, 14);
}
catch (UnknownCoolingProduct e)
{
    Console.WriteLine(e);
}
CoolingContainer cc3 = new CoolingContainer("Frozen pizza", 150, 78, 54, 67.56, 14);
cc3.LoadCargo(78, false);
Console.WriteLine(cc3.ToString());

Console.WriteLine("\nStatek");
ship.AddContainer(fc1);
ship.AddContainer(fc2);
ship.AddContainer(gc1);
ship.AddContainer(gc2);
ship.AddContainer(cc1);
ship.DisplayContainers();

ship.AddContainer(cc3);
ship.DisplayContainers();
ship.DisplayShipInfo();
