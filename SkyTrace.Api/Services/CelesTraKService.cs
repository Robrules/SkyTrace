using SkyTrace.Api.Domain;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SkyTrace.Api.Services
{
    public class CelesTraKService : ICelesTrakService
    {
        private readonly HttpClient http;
        private const string ActiveSatellitesUrl =
        "https://celestrak.org/NORAD/elements/gp.php?GROUP=active&FORMAT=json";

        public CelesTraKService(HttpClient http) => this.http = http;
        public async Task<IReadOnlyList<Satellite>> GetActiveSatellitesAsync(CancellationToken ct = default)
        {
            // CelesTrak returns GP element sets in JSON; map to domain model
            var elements = await http.GetFromJsonAsync<List<GpElement>>(ActiveSatellitesUrl, ct)
                           ?? new List<GpElement>();

            return elements.Select(e => new Satellite
            {
                Id = Guid.NewGuid(),
                Name = e.OBJECT_NAME,
                Latitude = 0,   // TODO:
                Longitude = 0,   // TODO:
                AltitudeKm = 0,  // TODO:
                Timestamp = DateTimeOffset.UtcNow
            }).ToList();
        }
        private sealed record GpElement(string OBJECT_NAME, string TLE_LINE1, string TLE_LINE2);
    }
}
