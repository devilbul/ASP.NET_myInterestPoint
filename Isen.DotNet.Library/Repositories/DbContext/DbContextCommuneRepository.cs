using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextCommuneRepository :
        BaseDbContextRepository<Commune>, ICommuneRepository
    {
        public DbContextCommuneRepository(
            ILogger<DbContextCommuneRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }

        public Commune GetCommuneByName(string name)
        {
            return Enumerable.FirstOrDefault(Context.CommuneCollection, commune => commune.Nom.Equals(name));
        }

        public Commune GetCommuneById(int id)
        {
            return Enumerable.FirstOrDefault(Context.CommuneCollection, commune => commune.Id.Equals(id));
        }
    }
}