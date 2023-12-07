using Core.DataAccess.Repository;
using Core.Persistence.Paging;
using Entities.Concretes;
using Entities.DTO;
using System.Linq.Expressions;

namespace DataAccess.Abstracts;

public interface ICourseDal : IRepository<Course, int>, IAsyncRepository<Course, int>
{
    Task<IPaginate<CourseDetailDto>> GetCourseDetails();
}