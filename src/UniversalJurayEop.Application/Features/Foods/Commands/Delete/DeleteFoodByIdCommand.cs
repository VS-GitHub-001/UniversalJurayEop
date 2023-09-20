using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Exceptions;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Application.Wrappers;

namespace UniversalJurayEop.Application.Features.Foods.Commands.Delete
{
    public class DeleteFoodByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFoodByIdCommandHandler : IRequestHandler<DeleteFoodByIdCommand, Response<int>>
        {
            private readonly IFoodRepositoryAsync _FoodRepository;
            public DeleteFoodByIdCommandHandler(IFoodRepositoryAsync FoodRepository)
            {
                _FoodRepository = FoodRepository;
            }
            public async Task<Response<int>> Handle(DeleteFoodByIdCommand command, CancellationToken cancellationToken)
            {
                var Food = await _FoodRepository.GetByIdAsync(command.Id);
                if (Food == null) throw new ApiException($"Food Not Found.");
                await _FoodRepository.DeleteAsync(Food);
                return new Response<int>(Food.Id);
            }
        }
    }
}
