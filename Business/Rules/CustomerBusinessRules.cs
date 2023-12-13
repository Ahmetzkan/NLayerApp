using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CustomerBusinessRules : BaseBusinessRules
    {
        ICustomerDal _customerDal;

        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task ContactNameCantRepeat(string name)
        {
            var result = await _customerDal.GetListAsync(
                predicate: c => c.ContactName == name
                );
            if ( result.Count >=1 )
            {
                throw new BusinessException(BusinessMessages.ContactNameCantRepeat);
            }

        }
        public async Task MaxCityCountIsTen(string city)
        {
            var result = await _customerDal.GetListAsync(
                predicate: c => c.City == city ,
                size: 25
                );
            if (result.Count >= 10)
            {
                throw new BusinessException(BusinessMessages.MaxCityCountIsTen);
            }
        }
    }
}
