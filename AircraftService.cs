using System.ComponentModel.DataAnnotations;

namespace apiACDemo;

public class AircraftService
{
    private readonly AircraftDB _db;
    
    public AircraftService(AircraftDB db)
    {
        _db = db;
    }

    public Aircraft CreateAircraft(AircraftController.CreateAcDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var ac = new Aircraft()
        {
            Brand = dto.Brand,
            Model = dto.Model,
            YearOfManufacture = dto.YearOfManufacture,
            CreatedAt = DateTime.Now.ToUniversalTime(),
            Id = Guid.NewGuid().ToString()
        };
        _db.AllAircrafts.Add(ac);
        return new Aircraft();
    }

    public Aircraft UpdateAc(string id, AircraftController.CreateAcDto acs)
    {
        Validator.ValidateObject(acs, new ValidationContext(acs), true);
        var existingAc = _db.AllAircrafts.First(p => p.Id == id);
        existingAc.Brand = acs.Brand;
        existingAc.Model = acs.Model;
        existingAc.YearOfManufacture = acs.YearOfManufacture;
        return existingAc;
    }

    public Boolean DeleteAc(string id)
    {
        var ac = _db.AllAircrafts.First(p => p.Id == id);
        if (ac == null)
            throw new KeyNotFoundException("Could not find the aircraft with id: " + id + "");
        var success = _db.AllAircrafts.Remove(ac);
        return !success ? throw new Exception("Error while deleting the aircraft!") : true;
    }

    public List<Aircraft> GetAircrafts()
    {
        List<Aircraft> a = _db.AllAircrafts.ToList();
        if (a.Count == 0)
        {
            a.AddRange(new List<Aircraft>
            {
                new Aircraft { Brand = "Boeing", Model = "738", YearOfManufacture = 2010, CreatedAt = DateTime.Now.ToUniversalTime(), Id = Guid.NewGuid().ToString()},
                new Aircraft { Brand = "Boeing", Model = "787", YearOfManufacture = 2015, CreatedAt = DateTime.Now.ToUniversalTime(), Id = Guid.NewGuid().ToString()},
                new Aircraft { Brand = "Airbus", Model = "A350", YearOfManufacture = 2019, CreatedAt = DateTime.Now.ToUniversalTime(), Id = Guid.NewGuid().ToString()}
            });
        }
        return a;
    }

    public Aircraft GetOneAircraft(string id)
    {
        var Aircratf = _db.AllAircrafts.First(p => p.Id == id);
        if (Aircratf == null)
            throw new KeyNotFoundException("Could not find the aircraft with id: " + id + "");
        return Aircratf;
    }
}

