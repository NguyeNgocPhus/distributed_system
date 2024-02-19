using DistributedSystem.Contract.Abstractions.Messages;
using static DistributedSystem.Contract.Services.V1.Product.Response;

namespace DistributedSystem.Contract.Services.V1.Product;

public static class Query
{
    public record GetProductsQuery() : IQuery<List<ProductResponse>>;

    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}