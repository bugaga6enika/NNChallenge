using System.Threading;
using System.Threading.Tasks;

namespace NNChallenge.Interfaces
{
    public interface IWeatherForcastRepository
    {
        public Task<IWeatherForcastVO> GetAsync(IWeatherForcastRequest weatherForcastRequest, CancellationToken cancellationToken = default);
    }
}
