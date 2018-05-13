using Isen.DotNet.Library.Models.Implementation;

namespace Isen.DotNet.Library.Repositories.Interfaces
{
    public interface ICommuneRepository : IBaseRepository<Commune>
    {
        Commune GetCommuneByName(string name);
        Commune GetCommuneById(int id);
    }
}