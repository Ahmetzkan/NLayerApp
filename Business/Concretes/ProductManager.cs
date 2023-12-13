using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Profiles;
using Core.DataAccess.Paging;
using Core.Persistence.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Rules;


namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    IMapper _mapper;
    ProductBusinessRules _productBusinessRules;


    public ProductManager(ProductBusinessRules productBusinessRules, IProductDal productDal, IMapper mapper)
    {
        _productBusinessRules = productBusinessRules;
        _productDal = productDal;
        _mapper = mapper;
    }

    public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
    {
        await _productBusinessRules.EachCategoryCanContainMax20Products(createProductRequest.CategoryId);
        Product product = _mapper.Map<Product>(createProductRequest);
        Product createdProduct = await _productDal.AddAsync(product);
        CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
        return createdProductResponse;

    }
    public async Task<DeletedProductResponse> Delete(DeleteProductRequest deleteProductRequest)
    {
        var product = _mapper.Map<Product>(deleteProductRequest);
        var deletedProduct = await _productDal.DeleteAsync(product, false); //DeletedDate'in değiştiğini kontrol etmek için false verdim
        var responseProduct = _mapper.Map<DeletedProductResponse>(deletedProduct);
        return responseProduct;
    }

    public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
    {

        var productList = await _productDal.GetListAsync(
            include: p => p.Include(p => p.Category),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedList = _mapper.Map<Paginate<GetListProductResponse>>(productList);
        return mappedList;
    }

    public async Task<UpdatedProductResponse> Update(UpdateProductRequest updateProductRequest)
    {
        var product = _mapper.Map<Product>(updateProductRequest);
        var updatedProduct = await _productDal.UpdateAsync(product);
        var mappedProduct = _mapper.Map<UpdatedProductResponse>(updatedProduct);
        return mappedProduct;
    }
}
