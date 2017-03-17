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
    public class TypeManifestationMgt : AbstractMgt<TypeManifestation, int>
    {
        public override IDal<TypeManifestation, int> Dal
        {
            get
            {
                return new TypeManifestationDal();
            }
        }
    }
}
