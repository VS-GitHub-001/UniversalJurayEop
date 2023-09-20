using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Exceptions;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Application.Wrappers;
using UniversalJurayEop.Domain.Models;

namespace UniversalJurayEop.Application.Features.Foods.Queries.GetById
{
    public class GetFoodByIdQuery : IRequest<Response<Food>>
    {
        public int Id { get; set; }
        public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, Response<Food>>
        {
            private readonly IFoodRepositoryAsync _FoodRepository;
            public GetFoodByIdQueryHandler(IFoodRepositoryAsync FoodRepository)
            {
                _FoodRepository = FoodRepository;
            }
            public async Task<Response<Food>> Handle(GetFoodByIdQuery query, CancellationToken cancellationToken)
            {
                var Food = await _FoodRepository.GetByIdAsync(query.Id);
                if (Food == null) throw new ApiException($"Food Not Found.");
                return new Response<Food>(Food);
            }
        }
    }
}
