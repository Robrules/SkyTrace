namespace SkyTrace.Api.Domain
{
    public class Satellite
    {
        public Guid Id  { get; init; }
        public string Name { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public double AltitudeKm { get; set; }

        public DateTimeOffset Timestamp  { get; set; }

    }
}
