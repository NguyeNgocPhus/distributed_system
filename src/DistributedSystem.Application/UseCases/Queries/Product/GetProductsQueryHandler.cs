using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;

namespace DistributedSystem.Application.UseCases.Queries.Product;

public class GetProductsQueryHandler : IQueryHandler<Query.GetProductsQuery , List<Response.ProductResponse>>
{
    public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}