﻿using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Web.Controllers
{
    public class PointInteretController : BaseController<PointInteret>
    {
        public PointInteretController(
            ILogger<PointInteretController> logger,
            IPointInteretRepository repository) 
            : base(logger, repository)
        {
        }

        public virtual IActionResult Map()
        {
            return View();
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public virtual JsonResult GetAll()
        {
            var all = _repository.GetAll().Select(t => t.ToDynamic()).ToList();
            return Json(all);
        }
        
        [HttpGet]
        [Route("api/[controller]/{filter}")]
        public virtual JsonResult GetAllSort(string filter)
        {
            List<dynamic> all;
            
            if (filter.Equals("Commune") || filter.Equals("CommuneId"))
                all = _repository.GetAll().OrderBy(model => model.Adresse.CommuneId).Select(t => t.ToDynamic()).ToList();
            else if (filter.Equals("Departement") || filter.Equals("DepartementId"))
                all = _repository.GetAll().OrderBy(model => model.Adresse.Commune.DepartementId).Select(t => t.ToDynamic()).ToList();
            else if (filter.Equals("Categorie") || filter.Equals("CategorieId"))
                all = _repository.GetAll().OrderBy(model => model.CategorieId).Select(t => t.ToDynamic()).ToList();
            else
                all = _repository.GetAll().Select(t => t.ToDynamic()).ToList();
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