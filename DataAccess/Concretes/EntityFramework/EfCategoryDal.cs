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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, int, TobetoContext>, ICategoryDal
    {
        TobetoContext _context;
        public EfCategoryDal(TobetoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPaginate<CategoryDetailDto>> GetCategoryDetails()
        {
            int index = 0;
            int size = 20;

            var result = await (from category in _context.Categories
                                join course in _context.Courses
                                on category.Id equals course.Id
                                select new CategoryDetailDto
                                {
                                    Id = category.Id,
                                    CategoryName = category.Name,
                                    CourseName = course.Name

                                }).ToPaginateAsync(index, size, 0);

            return result;
        }

    }
}