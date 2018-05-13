using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface ICategorieRepository : IBaseRepository<Categorie>
    {
        Categorie GetCategorieByName(string name);
        Categorie GetCategorieById(int id);
    }
}