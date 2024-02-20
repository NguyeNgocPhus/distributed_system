using AutoMapper;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Domain.Entities;
using Response = DistributedSystem.Contract.Services.V1.Product.Response;


namespace DistributedSystem.Application.Mapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        // V1
         CreateMap<Product, Response.ProductResponse>().ReverseMap();
         CreateMap<PagedResult<Product>, PagedResult<Response.ProductResponse>>().ReverseMap();

        // V2
        //CreateMap<Product, Contract.Services.V2.Product.Response.ProductResponse>().ReverseMap();
    }
}