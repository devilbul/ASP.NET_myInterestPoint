using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeedData> _logger;
        private readonly IDepartementRepository _departementRepository;
        private readonly ICommuneRepository _communeRepository;
        private readonly IAdresseRepository _adresseRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IPointInteretRepository _pointInteretRepository;

        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger,
            IDepartementRepository departementRepository,
            ICommuneRepository communeRepository,
            IAdresseRepository adresseRepository,
            ICategorieRepository categorieRepository,
            IPointInteretRepository pointInteretRepository)
        {
            _context = context;
            _logger = logger;
            _departementRepository = departementRepository;
            _communeRepository = communeRepository;
            _adresseRepository = adresseRepository;
            _categorieRepository = categorieRepository;
            _pointInteretRepository = pointInteretRepository;
        }

        public void DropDatabase()
        {
            var deleted = _context.Database.EnsureDeleted();
            var not = deleted ? "" : "not ";
            _logger.LogWarning($"Database was {not}dropped.");
        }

        public void CreateDatabase()
        {
            var created = _context.Database.EnsureCreated();
            var not = created ? "" : "not ";
            _logger.LogWarning($"Database was {not}created.");
        }

        /*Exercice 3*/
        public void ImportDepartement()
        {
            string fileName = "Resources\\departement.csv";
            string[] lines = File.ReadAllText(fileName).Split('\n');
            List<Departement> departements = new List<Departement>();

            for (int i = 1; i < lines.Length; i++)
            {
                departements.Add(new Departement
                {
                    Nom = lines[i].Split(';')[1],
                    Numero = Convert.ToInt32(lines[i].Split(';')[0]),
                    Prefecture = lines[i].Split(';')[2]
                });
            }

            _departementRepository.UpdateRange(departements);
            _departementRepository.Save();
            _logger.LogWarning("Added departements");
        }

        public void ImportCommunes()
        {
            string fileName = "Resources\\commune.csv";
            string[] lines = File.ReadAllText(fileName).Split('\n');
            List<Commune> communes = new List<Commune>();

            for (int i = 1; i < lines.Length; i++)
            {
                communes.Add(new Commune
                {
                    Nom = lines[i].Split(';')[1],
                    Latitude = lines[i].Split(';')[2].Length > 1 ? Convert.ToDouble(lines[i].Split(';')[2]) : 0,
                    Longitude = lines[i].Split(';')[3].Length > 1 ? Convert.ToDouble(lines[i].Split(';')[3]) : 0,
                    DepartementId = _departementRepository
                        .GetDepartementByNumero(Convert.ToInt32(lines[i].Split(';')[0])).Id
                });
            }

            _communeRepository.UpdateRange(communes);
            _communeRepository.Save();
            _logger.LogWarning("Added communes");
        }

        public void ImportCategories()
        {
            string fileName = "Resources\\categorie.csv";
            string[] lines = File.ReadAllText(fileName).Split('\n');
            List<Categorie> categories = new List<Categorie>();

            for (int i = 1; i < lines.Length; i++)
            {
                categories.Add(new Categorie
                {
                    Nom = lines[i].Split(';')[0],
                    Description = lines[i].Split(';')[1]
                });
            }

            _categorieRepository.UpdateRange(categories);
            _categorieRepository.Save();
            _logger.LogWarning("Added categories");
        }

        public void ImportPointsInteret()
        {
            string fileName = "Resources\\pointsinteret.csv";
            string[] lines = File.ReadAllText(fileName).Split('\n');
            List<PointInteret> points = new List<PointInteret>();

            for (int i = 1; i < lines.Length; i++)
            {
                points.Add(new PointInteret
                {
                    Nom = lines[i].Split(';')[0],
                    Description = lines[i].Split(';')[1],
                    CategorieId = _categorieRepository.GetCategorieByName(lines[i].Split(';')[2]).Id,
                    Adresse = new Adresse
                    {
                        AdresseText = lines[i].Split(';')[3],
                        CodePostal = lines[i].Split(';')[4],
                        CommuneId = _communeRepository.GetCommuneByName(lines[i].Split(';')[5]).Id,
                        Longitude = lines[i].Split(';')[6].Length > 1 ? Convert.ToDouble(lines[i].Split(';')[6]) : 0,
                        Latitude = lines[i].Split(';')[7].Length > 1 ? Convert.ToDouble(lines[i].Split(';')[7]) : 0
                    }
                });
            }

            _pointInteretRepository.UpdateRange(points);
            _pointInteretRepository.Save();
            _logger.LogWarning("Added categories");
        }

        /*Exercice 2*/
        public void AddDepartements()
        {
            if (_departementRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding departements");

            var departements = new List<Departement>
            {
                new Departement
                {
                    Nom = "Alpes-de-Haute-Provence",
                    Numero = 4,
                    Prefecture = "Digne-les-Bains"
                },
                new Departement
                {
                    Nom = "Hautes-Alpes",
                    Numero = 5,
                    Prefecture = "Gap"
                },
                new Departement
                {
                    Nom = "Alpes-Maritimes",
                    Numero = 6,
                    Prefecture = "Nice"
                },
                new Departement
                {
                    Nom = "Bouches-du-Rhone",
                    Numero = 13,
                    Prefecture = "Marseille"
                },
                new Departement
                {
                    Nom = "Var",
                    Numero = 83,
                    Prefecture = "Toulon"
                },
                new Departement
                {
                    Nom = "Vaucluse",
                    Numero = 84,
                    Prefecture = "Avignon"
                }
            };
            _departementRepository.UpdateRange(departements);
            _departementRepository.Save();
            _logger.LogWarning("Added departements");
        }

        public void AddCommunes()
        {
            if (_communeRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding communes");

            var communes = new List<Commune>
            {
                new Commune
                {
                    Nom = "Le Lavandou",
                    Longitude = 6.366,
                    Latitude = 43.137,
                    Departement = _departementRepository.GetDepartementByNumero(83)
                },
                new Commune
                {
                    Nom = "Cuers",
                    Longitude = 6.0667,
                    Latitude = 43.2333,
                    Departement = _departementRepository.GetDepartementByNumero(83)
                },
                new Commune
                {
                    Nom = "Toulon",
                    Longitude = 5.9333,
                    Latitude = 43.1167,
                    Departement = _departementRepository.GetDepartementByNumero(83)
                },
                new Commune
                {
                    Nom = "Nice",
                    Longitude = 5.9333,
                    Latitude = 43.1167,
                    Departement = _departementRepository.GetDepartementByNumero(6)
                }
            };
            _communeRepository.UpdateRange(communes);
            _communeRepository.Save();
            _logger.LogWarning("Added communes");
        }

        public void AddAdresses()
        {
            if (_adresseRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding communes");

            var adresses = new List<Adresse>();
            _adresseRepository.UpdateRange(adresses);
            _adresseRepository.Save();
            _logger.LogWarning("Added communes");
        }

        public void AddCategories()
        {
            if (_categorieRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding communes");

            var categories = new List<Categorie>
            {
                new Categorie
                {
                    Nom = "Golf",
                    Description = "terrain de golf"
                },
                new Categorie
                {
                    Nom = "Ecole",
                    Description = "batiment éducatif"
                },
                new Categorie
                {
                    Nom = "Bar",
                    Description = "pour décompresser"
                },
                new Categorie
                {
                    Nom = "Plage",
                    Description = "pour se baigner"
                }
            };
            _categorieRepository.UpdateRange(categories);
            _categorieRepository.Save();
            _logger.LogWarning("Added communes");
        }

        public void AddPointsInteret()
        {
            if (_pointInteretRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding point interets");

            var points = new List<PointInteret>
            {
                new PointInteret
                {
                    Nom = "Valcros",
                    Description = "Golf de Valcros",
                    CategorieId = _categorieRepository.GetCategorieByName("Golf").Id,
                    Adresse = new Adresse
                    {
                        AdresseText = "Avenue Vallée Heureuse",
                        CodePostal = "83250",
                        CommuneId = _communeRepository.GetCommuneByName("Le Lavandou").Id,
                        Longitude = 6.280890,
                        Latitude = 43.184911
                    }
                },
                new PointInteret
                {
                    Nom = "ISEN",
                    Description = "Ecole sup en info elec",
                    CategorieId = _categorieRepository.GetCategorieByName("Ecole").Id,
                    Adresse = new Adresse
                    {
                        AdresseText = "Maison du Numérique et de l'Innovation, Place Georges Pompidou",
                        CodePostal = "83000",
                        CommuneId = _communeRepository.GetCommuneByName("Toulon").Id,
                        Longitude = 5.9333,
                        Latitude = 43.1167
                    }
                },
                new PointInteret
                {
                    Nom = "Molly Bloom",
                    Description = "Bar place d'arme",
                    CategorieId = _categorieRepository.GetCategorieByName("Bar").Id,
                    Adresse = new Adresse
                    {
                        AdresseText = "18 Rue Anatole France",
                        CodePostal = "83250",
                        CommuneId = _communeRepository.GetCommuneByName("Toulon").Id,
                        Longitude = 5.9333,
                        Latitude = 43.1167
                    }
                }
            };
            _pointInteretRepository.UpdateRange(points);
            _pointInteretRepository.Save();
            _logger.LogWarning("Added point interets");
        }
    }
}