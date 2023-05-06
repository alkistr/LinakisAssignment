using LD.Assignment.Application.Interfaces;
using LD.Assignment.Application.Models;
using LD.Assignment.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Assignment.Application.Implementations
{
    public class TitleList : ITitleList
    {
        private readonly ITitlesRepository _titleRepository;

        public TitleList(ITitlesRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        public async Task<IEnumerable<TitleDto>> GetTitleDtosAsync()
        {
            var list = await _titleRepository.GetTitlesAsync();
            List<TitleDto> response = new List<TitleDto>();

            foreach (var title in list)
            {
                response.Add
                    (
                    new TitleDto
                    {
                        Title = title.Name
                    }
                    );
            }

            return response;
        }
    }
}
