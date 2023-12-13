using Business.Abstracts;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ProductBusinessRules : BaseBusinessRules
    {
        IProductDal _productDal;

        public ProductBusinessRules(IProductDal productDal)
        {
            _productDal = productDal;
        }

      
        public async Task EachCategoryCanContainMax20Products(int categoryId)
            {
            var result = await _productDal.GetListAsync(
                predicate: p => p.CategoryId == categoryId,
                size: 25
                );
            if (result.Count >= 20)
            {
                throw new BusinessException(BusinessMessages.CategoryProductLimit);
            }
        }



    }
}

