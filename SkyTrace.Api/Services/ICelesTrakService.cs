using SkyTrace.Api.Domain;

namespace SkyTrace.Api.Services
{
    public interface IIssTrackingService
    {
        Task<IReadOnlyList<Satellite>> GetActiveSatellitesAsync(CancellationToken ct = default);
    }
}