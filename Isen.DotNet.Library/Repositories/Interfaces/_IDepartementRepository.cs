using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface IDepartementRepository : IBaseRepository<Departement>
    {
        Departement GetDepartementByNumero(int numero);
        Departement GetDepartementByName(string name);
        Departement GetDepartementById(int id);
    }
}