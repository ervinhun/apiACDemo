using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace apiACDemo;



public class AircraftService (MyDbContext db) : IAircraftService
{

    public async Task<AircraftEntity> CreateAircraft(AircraftController.CreateAcDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var ac = new AircraftEntity()
        {
            Brand = dto.Brand,
            Model = dto.Model,
            YearOfManufacture = dto.YearOfManufacture,
            CreatedAt = DateTime.Now.ToUniversalTime(),
            Id = Guid.NewGuid().ToString()
        };
        await db.Aircrafts.AddAsync(ac);
        await db.SaveChangesAsync();
        return ac;
    }

    public async Task<AircraftEntity> UpdateAc(string id, AircraftController.CreateAcDto acs)
    {
        if (id.Equals("1") || id.Equals("2"))
            throw new ArgumentException("The first two aircrafts can not modify their properties.");
        Validator.ValidateObject(acs, new ValidationContext(acs), true);
        var existingAc = db.Aircrafts.FirstOrDefaultAsync(p => p.Id == id);
        if (existingAc.Result == null)
            throw new KeyNotFoundException("Could not find the aircraft with id: " + id + "");
        existingAc.Result.Brand = acs.Brand;
        existingAc.Result.Model = acs.Model;
        existingAc.Result.YearOfManufacture = acs.YearOfManufacture;
        await db.SaveChangesAsync();
        return existingAc.Result;
    }

    public async Task<AircraftEntity> DeleteAc(string id)
    {
        if (id.Equals("1") || id.Equals("2"))
            throw new ArgumentException("The first two aircrafts (id 1 and 2) are not available for delete.");
        var ac = db.Aircrafts.FirstOrDefaultAsync(p => p.Id == id);
        if (ac.Result == null)
            throw new KeyNotFoundException("Could not find the aircraft with id: " + id + "");
        db.Aircrafts.Remove(ac.Result);
        await db.SaveChangesAsync();
        return ac.Result;
    }

    public async Task<List<AircraftEntity>> GetAircrafts()
    {
        return await db.Aircrafts.ToListAsync();
    }

    public async Task<AircraftResponseDto> GetOneAircraft(string id)
    {
        var aircraft = new AircraftResponseDto(db.Aircrafts.FirstOrDefault(p => p.Id == id));
        if (aircraft == null)
            throw new KeyNotFoundException("Could not find the aircraft with id: " + id + "");
        return aircraft;
    }
}

