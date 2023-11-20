using Entities.Concretes;
using System.Linq.Expressions;

namespace DataAccess.Abstracts;

public interface ICourseDal : IEntityRepository<Course, int>
{
   
}