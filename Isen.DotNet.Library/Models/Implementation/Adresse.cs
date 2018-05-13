using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Adresse : BaseModel
    {
        public string AdresseText { get; set; }
        public string CodePostal { get; set; }
        public int CommuneId { get; set; }
        public Commune Commune { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<PointInteret> Points { get; set; }

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.adresseText = AdresseText;
            response.codePostal = CodePostal;
            response.communId = CommuneId;
            response.longitude = Longitude;
            response.latitude = Latitude;
            return response;
        }
    }
}