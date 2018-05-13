using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Commune : BaseModel
    {
        public string Nom { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int DepartementId { get; set; }
        public Departement Departement { get; set; }
        
        public ICollection<Adresse> Adresses { get; set; }

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.nom = Nom;
            response.departementId = DepartementId;
            response.longitude = Longitude;
            response.latitude = Latitude;
            return response;
        }
    }
}