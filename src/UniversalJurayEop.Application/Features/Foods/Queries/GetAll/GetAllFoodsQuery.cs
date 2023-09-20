using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Application.Wrappers;

namespace UniversalJurayEop.Application.Features.Foods.Queries.GetAll
{
    public class GetAllFoodsQuery : IRequest<PagedResponse<IEnumerable<GetAllFoodsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, PagedResponse<IEnumerable<GetAllFoodsViewModel>>>
    {
        private readonly IFoodRepositoryAsync _FoodRepository;
        private readonly IMapper _mapper;
        public GetAllFoodsQueryHandler(IFoodRepositoryAsync FoodRepository, IMapper mapper)
        {
            _FoodRepository = FoodRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFoodsViewModel>>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFoodsParameter>(request);
            var Food = await _FoodRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var FoodViewModel = _mapper.Map<IEnumerable<GetAllFoodsViewModel>>(Food);
            return new PagedResponse<IEnumerable<GetAllFoodsViewModel>>(FoodViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
