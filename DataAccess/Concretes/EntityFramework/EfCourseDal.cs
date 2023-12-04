using Core.DataAccess.EntityFramework;
using Core.DataAccess.Repository;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseDal : EfRepositoryBase<Course, int, NorthwindContext>, ICourseDal
    {
        public EfCourseDal(NorthwindContext context) : base(context)
        {
        }
    }
}