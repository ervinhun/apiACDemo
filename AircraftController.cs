using System.ComponentModel.DataAnnotations;
using apiACDemo;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AircraftController : ControllerBase
{

    private readonly AircraftService _service;

    public AircraftController(AircraftService service)
    {
        Console.WriteLine("controller");
        _service = service;
    }
    
    [HttpGet]
    [Route(nameof(GetAircraft))]
    public Aircraft GetAircraft([FromQuery] string id)
    {
        Aircraft ac = _service.GetOneAircraft(id);
        return ac;
    }
    
    [HttpGet]
    [Route(nameof(GetAllAircrafts))]
    public List<Aircraft> GetAllAircrafts()
    {
        return _service.GetAircrafts();
    }
    
    [HttpPost]
    [Route(nameof(CreateAircratf))]
    public void CreateAircratf([FromBody] CreateAcDto acs)
    {
     Console.WriteLine("Add Aircratf");
     _service.CreateAircraft(acs);
    }
    
    [HttpPut]
    [Route(nameof(UpdateAircratf))]
    public void UpdateAircratf(
        [FromQuery] string id, 
        [FromBody] CreateAcDto acs)
    {
     Console.WriteLine("Update Aircratf");
     _service.UpdateAc(id, acs);
    }
    
    [HttpDelete]
    [Route(nameof(DeleteAircratf))]
    public void DeleteAircratf([FromQuery] string id)
    {
     Console.WriteLine("Delete Aircratf");   
     _service.DeleteAc(id);
    }
    
    
    public record CreateAcDto
    {
        [MinLength(3)]
        public string Brand { get; set; }
        [MinLength(3)]
        public string Model { get; set; }
        [Range(1950,2025)]
        public int YearOfManufacture { get; set; }
    }
}