using System.Linq;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextCategorieRepository :
        BaseDbContextRepository<Categorie>, ICategorieRepository
    {
        public DbContextCategorieRepository(
            ILogger<DbContextCategorieRepository> logger, 
            ApplicationDbContext context) 
            : base(logger, context)
        {
        }
        
        public Categorie GetCategorieByName(string name)
        {
            return Enumerable.FirstOrDefault(Context.CategorieCollection, categorie => categorie.Nom.Equals(name));
        }

        public Categorie GetCategorieById(int id)
        {
            return Enumerable.FirstOrDefault(Context.CategorieCollection, categorie => categorie.Id.Equals(id));
        }
    }
}