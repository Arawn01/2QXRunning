using Common.Bll;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using DAL;

namespace BLL
{
    public class TypeDePaiementMgt : AbstractMgt<TypeDePaiement, int>
    {
        public override IDal<TypeDePaiement, int> Dal
        {
            get { return new TypeDePaiementDal(); }
        }
    }
}
