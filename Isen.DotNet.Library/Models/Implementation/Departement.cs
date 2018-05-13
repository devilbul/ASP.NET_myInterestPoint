using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class Departement : BaseModel
    {
        public string Nom { get; set; }
        public int Numero { get; set; }
        public string Prefecture { get; set; }

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.nom = Nom;
            response.numero = Numero;
            response.prefecture = Prefecture;
            return response;
        }
    }
}