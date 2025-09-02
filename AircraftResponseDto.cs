namespace apiACDemo;

public class AircraftResponseDto(AircraftEntity p)
{
        public string AircraftBrand { get; set; } = p.Brand;
        public string AircraftModel { get; set; } = p.Model;
        public int AircraftYear { get; set; } = p.YearOfManufacture;
}