using LD.Assignment.Core;
using Microsoft.EntityFrameworkCore;

namespace LD.Assignment.Data.Context
{
    public class TitleContext : DbContext
    {
        public TitleContext(DbContextOptions<TitleContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Title> Titles { get; set; }
    }
}
