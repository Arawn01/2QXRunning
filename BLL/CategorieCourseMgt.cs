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
    public class CategorieCourseMgt : AbstractMgt<CategorieCourse, int>
    {
        public override IDal<CategorieCourse, int> Dal
        {
            get
            {
                return new CategorieCourseDal();
            }
        }
    }
}
