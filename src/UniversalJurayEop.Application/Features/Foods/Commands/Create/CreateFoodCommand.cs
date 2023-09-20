using AutoMapper;
using MediatR;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Application.Wrappers;
using UniversalJurayEop.Domain.Models;

namespace UniversalJurayEop.Application.Features.Foods.Commands.Create
{

    public partial class CreateFoodCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Response<int>>
    {
        private readonly IFoodRepositoryAsync _foodRepository;
        private readonly IMapper _mapper;
        public CreateFoodCommandHandler(IFoodRepositoryAsync foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Food>(request);
            await _foodRepository.AddAsync(product);
            return new Response<int>(product.Id);
        }
    }
}
