namespace apiACDemo;

public interface IAircraftService
{
    Task<AircraftEntity> CreateAircraft(AircraftController.CreateAcDto dto);
    Task<AircraftEntity> UpdateAc(string id, AircraftController.CreateAcDto acs);
    Task<AircraftEntity> DeleteAc(string id);
    Task<AircraftResponseDto> GetOneAircraft(string id);
    Task<List<AircraftEntity>> GetAircrafts();
}