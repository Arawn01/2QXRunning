using BO;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PointDal : AbstractDalAutoIncrement<Point, ApplicationDbContext>
    {
        public List<Point> getByCategorieLike(Course course, string strCategorie)
        {
            List<Point> points = new List<Point>();

            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                points = e.Set<Point>()
                    .Where(p => p.Course == course)
                    .Where(p => p.CategoriePoint.Libelle.ToUpper().Contains(strCategorie.ToUpper())
                ).ToList();
            }

            return points;

        }

        public List<Point> GetByCourse(Course course)
        {
            List<Point> points = new List<Point>();

            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                points = e.Set<Point>().Where(p => p.Course == course).ToList();
            }

            return points;
        }
    }
}
