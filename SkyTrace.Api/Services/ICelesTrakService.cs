using SkyTrace.Api.Domain;

namespace SkyTrace.Api.Services
{
    public interface ICelesTrakService
    {
        Task<IReadOnlyList<Satellite>> GetActiveSatellitesAsync(CancellationToken ct = default);

    }
}
