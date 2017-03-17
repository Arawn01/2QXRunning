using BO;
using Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using DAL;

namespace BLL
{
    public class VilleMgt : AbstractMgt<Ville, int>
    {
        public override IDal<Ville, int> Dal
        {
            get
            {
                return new VilleDal();
            }
        }

        /// <summary>
        /// Renvoie une liste des villes WHERE nom LIKE "%{strRecherche}%"
        /// </summary>
        /// <param name="str">(String) Recherche sur le nom </param>
        /// <returns></returns>
        public List<Ville> GetByNomLike(string strRecherche)
        {
            List<Ville> departements = new List<Ville>();

            if (!string.IsNullOrEmpty(strRecherche) && strRecherche.Length > 3)
                departements = ((VilleDal)Dal).GetByNom(strRecherche);
            
            return departements;
        }

        /// <summary>
        /// Renvoie les villes correspondant à WHERE codePostal LIKE "{strCodePostal}%"
        /// </summary>
        /// <param name="strCodePostal">(string) Code postal sans espaces</param>
        /// <returns></returns>
        public List<Ville> GetByCodePostalLike(string strCodePostal)
        {
            List<Ville> villes = new List<Ville>();

            // Contrôle de saisie
            try
            {
                // Contrôle que les caractères sont bien des chiffres
                foreach (char c in strCodePostal.Trim())
                {
                    if ((int)c >= 48 && (int)c <= 57)
                        throw new ApplicationException("La recherche n'est pas un code postal valide");
                }

                villes = ((VilleDal)Dal).GetByCodePostalLike(strCodePostal);
            }
            catch (ApplicationException)
            {

            }


            return villes;
        }

        /// <summary>
        /// Liste des villes par l'id du département
        /// </summary>
        /// <param name="idDepartement"></param>
        /// <returns></returns>
        public List<Ville> GetByDepartement(int idDepartement)
        {
            return ((VilleDal)Dal).GetByDepartement(idDepartement);
        }

        /// <summary>
        /// Renvoie les villes dont le département commence par la recherche.
        /// </summary>
        /// <param name="nomDepartement"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Ville> GetByIdDepartement_NomStartsWith(int idDepartement, string nomVille, int? max)
        {
            return ((VilleDal)Dal).GetByIdDepartement_NomStartsWith(idDepartement, nomVille, max);
        }
    }
}

