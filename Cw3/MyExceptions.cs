namespace Cw3;

public class OverfillException : Exception
{
    public OverfillException(string msg) : base(msg) { }
}

public class NegativeCargoMassException : Exception
{
    public NegativeCargoMassException(string msg) : base(msg) { }
}

public class InvalidTemperatureException : Exception
{
    public InvalidTemperatureException(string msg) : base(msg) { }
}

public class UnknownCoolingProduct : Exception
{
    public UnknownCoolingProduct(string msg) : base(msg) { }
}