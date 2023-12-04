using Core.DataAccess.Repository;
using Entities.Concretes;
using System.Linq.Expressions;

namespace DataAccess.Abstracts;

public interface ICourseDal : IRepository<Course, int>, IAsyncRepository<Course, int>
{
   
}