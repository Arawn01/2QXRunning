using BO;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartementDal : AbstractDalAutoIncrement<Departement, ApplicationDbContext>
    {
        public List<Departement> GetNomBy(string strRecherche)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Departement>().Where(
                    dept => dept.Nom.ToUpper().Contains(strRecherche.ToUpper())).ToList();
            }
        }
    }
}
