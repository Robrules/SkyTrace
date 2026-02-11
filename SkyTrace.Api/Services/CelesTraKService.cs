using SkyTrace.Api.Domain;

namespace SkyTrace.Api.Services
{
    public class CelesTraKService : ICelesTrakService
    {
        public Task<IReadOnlyList<Satellite>> GetActiveSatellitesAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
