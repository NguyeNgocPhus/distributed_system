using AutoMapper;
using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Domain.Abstractions;
using DistributedSystem.Domain.Abstractions.Repositories;

namespace DistributedSystem.Application.UseCases.Commands.Product;

public class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id, cancellationToken);
        
        product.Update(request.Name,request.Price,request.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}