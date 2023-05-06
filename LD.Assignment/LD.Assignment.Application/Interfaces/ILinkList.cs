using LD.Assignment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Assignment.Application.Interfaces
{
    public interface ILinkList
    {
        Task<IEnumerable<LinkDto>> GetLinkDtosByTopicAsync();
    }
}
