using LD.Assignment.Application.Interfaces;
using LD.Assignment.Application.Models;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;

namespace LD.Assignment.Application.Implementations
{
    public class LinkList : ILinkList
    {
        public async Task<IEnumerable<LinkDto>> GetLinkDtosByTopicAsync()
        {
            var newsApiClient = new NewsApiClient("f73967c13c4b45c886d6bc98d61fce04");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2018, 1, 25)
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
