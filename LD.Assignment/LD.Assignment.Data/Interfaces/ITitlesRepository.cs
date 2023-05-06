using LD.Assignment.Core;

namespace LD.Assignment.Data.Interfaces
{
    public interface ITitlesRepository
    {
        Task<IEnumerable<Title>> GetTitlesAsync();
    }
}
