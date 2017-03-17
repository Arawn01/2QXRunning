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
    public class DepartementMgt : AbstractMgt<Departement, int>
    {
        public override IDal<Departement, int> Dal
        {
            get
            {
                return new DepartementDal();
            }
        }

        /// <summary>
        /// Renvoie une liste des départements WHERE nom LIKE "%{strRecherche}%"
        /// </summary>
        /// <param name="str">(String) Recherche sur le nom </param>
        /// <returns></returns>
        public List<Departement> GetByNomLike(string strRecherche)
        {
            List<Departement> departements = new List<Departement>();
            bool bOk = true;
            
            bOk &= (!string.IsNullOrEmpty(strRecherche));

            if (bOk)
                departements = ((DepartementDal)Dal).GetNomBy(strRecherche);

            return departements;
        }
    }
}
