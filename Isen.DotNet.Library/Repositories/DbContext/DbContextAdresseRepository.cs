using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextAdresseRepository :
        BaseDbContextRepository<Adresse>, IAdresseRepository
    {
        public DbContextAdresseRepository(
            ILogger<DbContextAdresseRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }
    }
}