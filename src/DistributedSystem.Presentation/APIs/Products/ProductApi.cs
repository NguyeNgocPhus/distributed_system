using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Abstractions;
using CommandV1 = DistributedSystem.Contract.Services.V1.Product;

namespace Presentation.APIs.Products;

public class ProductApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/products";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("products")
            .MapGroup(BaseUrl).HasApiVersion(1);

        group1.MapPost(string.Empty, CreateProductsV1).RequireAuthorization();
        group1.MapGet(string.Empty, GetProductsV1).RequireAuthorization();
        group1.MapGet("{productId}", GetProductsByIdV1).RequireAuthorization();
        group1.MapDelete("{productId}", DeleteProductsV1).RequireAuthorization();
        group1.MapPut("{productId}", UpdateProductsV1).RequireAuthorization();
    }

    #region ====== version 1 ======

    public static async Task<IResult> CreateProductsV1(ISender sender, [FromBody] CommandV1.Command.CreateProductCommand CreateProduct)
    {
        var result = await sender.Send(CreateProduct);

        if (result.IsFailure)
            return HandlerFailure(result);

        return Results.Ok(result);
    }

    public static async Task<IResult> GetProductsV1(ISender sender)
    {
        var result = await sender.Send(new CommandV1.Query.GetProductsQuery());
        return Results.Ok(result);
    }

    public static async Task<IResult> GetProductsByIdV1(ISender sender, Guid productId)
    {
        var result = await sender.Send(new CommandV1.Query.GetProductByIdQuery(productId));
        return Results.Ok(result);
    }

    public static async Task<IResult> DeleteProductsV1(ISender sender, Guid productId)
    {
        var result = await sender.Send(new CommandV1.Command.DeleteProductCommand(productId));
        return Results.Ok(result);
    }

    public static async Task<IResult> UpdateProductsV1(ISender sender, Guid productId, [FromBody] CommandV1.Command.UpdateProductCommand updateProduct)
    {
        var updateProductCommand = new CommandV1.Command.UpdateProductCommand(productId, updateProduct.Name, updateProduct.Price, updateProduct.Description);
        var result = await sender.Send(updateProductCommand);
        return Results.Ok(result);
    }

    #endregion ====== version 1 ======

}