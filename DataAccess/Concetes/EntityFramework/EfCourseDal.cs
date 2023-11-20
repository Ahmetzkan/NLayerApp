using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace DataAccess.Concetes.EntityFramework;

public class EfCourseDal : EfEntityRepositoryBase<Course, int, TobetoContext>, ICourseDal
{
}

