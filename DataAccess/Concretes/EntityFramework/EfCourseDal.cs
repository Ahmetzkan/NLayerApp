using Core.DataAccess.EntityFramework;
using Core.DataAccess.Repository;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using DataAccess.Concetes.EntityFramework;
using DataAccess.Contexts;
using Entities.Concretes;
using Entities.DTO;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCourseDal : EfRepositoryBase<Course, int, TobetoContext>, ICourseDal
    {
        TobetoContext _context;
        public EfCourseDal(TobetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPaginate<CourseDetailDto>> GetCourseDetails()
        {
            int index = 0;
            int size = 20;

            var result = await (from course in _context.Courses
                                join category in _context.Categories
                                on course.CategoryId equals category.Id
                                select new CourseDetailDto
                                {
                                    Id = course.Id,
                                    CategoryName = category.Name,
                                    CourseName = course.Name,
                                    CreatedDate = course.CreatedDate,
                                    UpdatedDate = course.UpdatedDate,
                                    DeletedDate = course.DeletedDate

                                }).ToPaginateAsync(index, size, 0);

            return result;
        }


    }
}