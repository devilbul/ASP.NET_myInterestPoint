using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextDepartementRepository :
        BaseDbContextRepository<Departement>, IDepartementRepository
    {
        public DbContextDepartementRepository(
            ILogger<DbContextDepartementRepository> logger,
            ApplicationDbContext context)
            : base(logger, context)
        {
        }

        public Departement GetDepartementByNumero(int numero)
        {
            return Enumerable.FirstOrDefault(Context.DepartementCollection, commune => commune.Numero.Equals(numero));
        }

        public Departement GetDepartementByName(string name)
        {
            return Enumerable.FirstOrDefault(Context.DepartementCollection, commune => commune.Nom.Equals(name));
        }

        public Departement GetDepartementById(int id)
        {
            return Enumerable.FirstOrDefault(Context.DepartementCollection, commune => commune.Id.Equals(id));
        }
    }
}