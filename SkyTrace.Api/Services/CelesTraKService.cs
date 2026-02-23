using System.Net.Http.Json;
using SkyTrace.Api.Domain;

namespace SkyTrace.Api.Services
{
    public class IssTrackingService : IIssTrackingService
    {
        private readonly HttpClient http;
        // 25544 is the NORAD catalog ID for the ISS
        private const string IssUrl = "https://api.wheretheiss.at/v1/satellites/25544";

        public IssTrackingService(HttpClient http) => this.http = http;

        public async Task<IReadOnlyList<Satellite>> GetActiveSatellitesAsync(CancellationToken ct = default)
        {
            // Fetch live ISS data
            var issData = await http.GetFromJsonAsync<IssResponse>(IssUrl, ct);

            if (issData == null) return new List<Satellite>();

            return new List<Satellite>
            {
                new Satellite
                {
                    Id = Guid.NewGuid(),
                    Name = "ISS",
                    Latitude = issData.latitude,
                    Longitude = issData.longitude,
                    AltitudeKm = issData.altitude,
                    // The API returns a Unix timestamp (seconds since Jan 1, 1970)
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(issData.timestamp)
                }
            };
        }

        // Record to match the JSON response from the API
        private sealed record IssResponse(double latitude, double longitude, double altitude, long timestamp);
    }
}