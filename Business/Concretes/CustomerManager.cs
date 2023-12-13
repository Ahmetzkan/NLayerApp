using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        CustomerBusinessRules _customerBusinessRules;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules customerBusinessRules)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<CreatedCustomerResponse> AddAsync(CreateCustomerRequest createCustomerRequest)
        {
            await _customerBusinessRules.ContactNameCantRepeat(createCustomerRequest.ContactName);
            await _customerBusinessRules.MaxCityCountIsTen(createCustomerRequest.City);


            Customer customer = _mapper.Map<Customer>(createCustomerRequest);
            var createdCustomer = await _customerDal.AddAsync(customer);
            CreatedCustomerResponse result = _mapper.Map<CreatedCustomerResponse>(createdCustomer);
            return result;
        }

        public async Task<DeletedCustomerResponse> DeleteAsync(DeleteCustomerRequest deleteCustomerRequest)
        {
            Customer customer = _mapper.Map<Customer>(deleteCustomerRequest);
            var deletedCustomer = await _customerDal.DeleteAsync(customer);
            DeletedCustomerResponse result = _mapper.Map<DeletedCustomerResponse>(deletedCustomer);
            return result;
        }

        public async Task<IPaginate<GetListCustomerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var customerList = await _customerDal.GetListAsync(index:pageRequest.PageIndex, size: pageRequest.PageSize);
            var mappedCustomer = _mapper.Map<Paginate<GetListCustomerResponse>>(pageRequest);
            return mappedCustomer;
        }

        public async Task<UpdatedCustomerResponse> UpdateAsync(UpdateCustomerRequest updateCustomerRequest)
        {
            Customer customer = _mapper.Map<Customer>(updateCustomerRequest);
            var updatedCustomer = await _customerDal.UpdateAsync(customer);
            UpdatedCustomerResponse result = _mapper.Map<UpdatedCustomerResponse>(updatedCustomer);
            return result;
        }
    }
}