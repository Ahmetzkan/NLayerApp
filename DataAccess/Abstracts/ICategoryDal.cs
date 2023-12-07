using Core.DataAccess.Repository;
using Core.Entities;
using Core.Persistence.Paging;
using Entities.Concretes;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface ICategoryDal : IRepository<Category, int>, IAsyncRepository<Category, int>
{
    Task<IPaginate<CategoryDetailDto>> GetCategoryDetails();

}
