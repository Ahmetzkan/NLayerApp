using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concetes.EntityFramework;
using Entities.Concretes;
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
    public IList<Category> GetAll()
    {
        //iş kodları
       
        return _categoryDal.GetList();
    }
}

