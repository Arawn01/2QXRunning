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
    class PointMgt : AbstractMgt<Point, int>
    {
        public override IDal<Point, int> Dal
        {
            get
            {
                return new PointDal();
            }
        }

        public List<Point> GetByCourse(Course course)
        {
            List<Point> points = new List<Point>();

            if (course != null)
                return ((PointDal)Dal).GetByCourse(course);

            return points;
        }
        
        public List<Point> GetByCategorieLike(Course course, string strCategorie)
        {
            List<Point> points = new List<Point>();

            try
            {
                if (string.IsNullOrEmpty("strCategorie"))
                    throw new ApplicationException("strCategorie est vide");

                points = ((PointDal)Dal).getByCategorieLike(course, strCategorie);

            } catch (ApplicationException)
            {

            }


            return points;
        }
    }
}
