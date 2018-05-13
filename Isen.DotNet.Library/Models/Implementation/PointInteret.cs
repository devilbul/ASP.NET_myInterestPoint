using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class PointInteret : BaseModel
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { set; get; }
        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }
        
        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.nom = Nom;
            response.description = Description;
            response.categorieId = CategorieId;
            response.adresseId = AdresseId;
            return response;
        }
    }
}