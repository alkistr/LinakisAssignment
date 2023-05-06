using LD.Assignment.Application.Interfaces;
using LD.Assignment.Application.Models;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

namespace LD.Assignment.Application.Implementations
{
    public class LinkList : ILinkList
    {
        public async Task<IEnumerable<LinkDto>> GetLinkDtosByTopicAsync(string category)
        {
            var newsApiClient = new NewsApiClient("f73967c13c4b45c886d6bc98d61fce04");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = category,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = DateTime.Today.AddYears(-1)
            });

            return await TransformResponse(articlesResponse);
        }

        private async Task<IEnumerable<LinkDto>> TransformResponse(ArticlesResult articles)
        {
            List<LinkDto> linkDtos = new List<LinkDto>();

            foreach(var article in articles.Articles)
            {
                linkDtos.Add
                (
                    new LinkDto
                    {
                        Link = article.UrlToImage
                    }
                );

                if(linkDtos.Count == 5)
                {
                    return linkDtos;
                }
            }

            return linkDtos;
        }
    }
}
