using LD.Assignment.Core;
using LD.Assignment.Data.Context;
using LD.Assignment.Data.Interfaces;

namespace LD.Assignment.Data.Implementations
{
    public class TitlesRepository : ITitlesRepository
    {
        private readonly TitleContext _titleContext;

        public TitlesRepository(TitleContext titleContext)
        {
            _titleContext = titleContext;
        }


        public async Task<IEnumerable<Title>> GetTitlesAsync()
        {
            return _titleContext.Titles;
        }
    }
}