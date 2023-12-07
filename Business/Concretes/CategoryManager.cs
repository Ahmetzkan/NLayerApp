using Business.Abstracts;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public async Task Add(Category category)
    {
        await _categoryDal.AddAsync(category);

    }

    public async Task Update(Category category)
    {
        await _categoryDal.UpdateAsync(category);
    }

    public async Task Delete(Category category)
    {
        await _categoryDal.DeleteAsync(category,true);
    }

    public async Task<IPaginate<CategoryDetailDto>> GetDetailsListAsync()
    {
        return await _categoryDal.GetCategoryDetails();
    }


    public async Task<IPaginate<Category>> GetListAsync()
    {
        return await _categoryDal.GetListAsync();

    }


}

