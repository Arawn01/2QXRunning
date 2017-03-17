using BO;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VilleDal : AbstractDalAutoIncrement<Ville, ApplicationDbContext>
    {
        public List<Ville> GetByNom(string strRecherche)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Ville>().Where(
                    ville => ville.Nom.ToUpper().StartsWith(strRecherche.ToUpper())).Take(10).ToList();
            }
        }

        public List<Ville> GetByCodePostalLike(string strCodePostal)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Ville>().Where(
                    ville => ville.Departement.Code.Contains(strCodePostal)).ToList();
            }
        }

        public List<Ville> GetByDepartement(int idDepartement)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Ville>()
                    .Where(ville => ville.Departement.Id == idDepartement)
                    .Include(Ville => Ville.Departement)
                    .ToList();
            }
        }

        public List<Ville> GetByIdDepartement_NomStartsWith(int idDepartement, string nomVille, int? max = null)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                if (max != null && max > 0)
                    return e.Set<Ville>()
                        .Where(ville => ville.Nom.ToLower().StartsWith(nomVille.ToLower()))
                        .Where(ville => ville.Departement.Id == idDepartement)
                        .Include(Ville => Ville.Departement)
                        .Take(max.Value)
                        .ToList();
                else
                    return e.Set<Ville>()
                        .Where(ville => ville.Nom.ToLower().StartsWith(nomVille.ToLower()))
                        .Where(ville => ville.Departement.Id == idDepartement)
                        .Include(Ville => Ville.Departement)
                        .ToList();
            }
        }

        public override Ville GetById(int Id)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Ville>()
                    .Where(ville => ville.Id == Id)
                    .Include(ville => ville.Departement)
                    .FirstOrDefault();
            }
        }
    }
}
