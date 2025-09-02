using System.ComponentModel.DataAnnotations;
using apiACDemo;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AircraftController : ControllerBase
{

    private readonly IAircraftService _service;

    public AircraftController(AircraftService service)
    {
        Console.WriteLine("controller");
        _service = service;
    }
    
    [HttpGet]
    [Route(nameof(GetAircraft))]
    public AircraftResponseDto GetAircraft([FromQuery] string id)
    {
        return _service.GetOneAircraft(id);
    }
    
    [HttpGet]
    [Route(nameof(GetAllAircrafts))]
    public async Task<List<AircraftEntity>> GetAllAircrafts()
    {
        return await _service.GetAircrafts();
    }
    
    [HttpPost]
    [Route(nameof(CreateAircraft))]
    public async Task<AircraftEntity> CreateAircraft([FromBody] CreateAcDto acs)
    {
     return await _service.CreateAircraft(acs);
    }
    
    [HttpPut]
    [Route(nameof(UpdateAircratf))]
    public async Task<AircraftEntity> UpdateAircratf(
        [FromQuery] string id, 
        [FromBody] CreateAcDto acs)
    {
     Console.WriteLine("Update Aircratf");
     return await _service.UpdateAc(id, acs);
    }
    
    [HttpDelete]
    [Route(nameof(DeleteAircratf))]
    public async Task<AircraftEntity> DeleteAircratf([FromQuery] string id)
    {
     Console.WriteLine("Delete Aircratf");   
     return await _service.DeleteAc(id);
    }
    
    
    public record CreateAcDto
    {
        [MinLength(3)]
        public string Brand { get; set; }
        [MinLength(2)]
        public string Model { get; set; }
        [Range(1950,2025)]
        public int YearOfManufacture { get; set; }
    }
}