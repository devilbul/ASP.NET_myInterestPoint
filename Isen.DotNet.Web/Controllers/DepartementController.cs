using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Web.Controllers
{
    public class DepartementController : BaseController<Departement>
    {
        public DepartementController(
            ILogger<DepartementController> logger,
            IDepartementRepository repository)
            : base(logger, repository)
        {
        }
    }
}