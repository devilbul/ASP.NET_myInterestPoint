using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Web.Controllers
{
    public class CategorieController : BaseController<Categorie>
    {
        public CategorieController(
            ILogger<CategorieController> logger,
            ICategorieRepository repository) 
            : base(logger, repository)
        {
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public virtual JsonResult GetAll()
        {
            var all = _repository.GetAll().Select(t => t.ToDynamic()).ToList();
            return Json(all);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public virtual JsonResult GetById(int id)
        {
            var single = _repository.Single(id).ToDynamic();
            return Json(single);
        }
    }
}