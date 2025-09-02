namespace apiACDemo;

public class AircraftDB
{
    public List<Aircraft> AllAircrafts = new List<Aircraft>();
    public Aircraft CurrentAircraft {get;set;} = new Aircraft();
}

public class Aircraft
{
    public string Brand {get;set;}
    public string Model {get;set;}
    public int YearOfManufacture {get;set;}
    public DateTime CreatedAt {get;set;}
    public string Id {get;set;}
}