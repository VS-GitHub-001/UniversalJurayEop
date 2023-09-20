using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Exceptions;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Application.Wrappers;

namespace UniversalJurayEop.Application.Features.Foods.Commands.Update
{
    public class UpdateFoodCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Response<int>>
        {
            private readonly IFoodRepositoryAsync _FoodRepository;
            public UpdateFoodCommandHandler(IFoodRepositoryAsync FoodRepository)
            {
                _FoodRepository = FoodRepository;
            }
            public async Task<Response<int>> Handle(UpdateFoodCommand command, CancellationToken cancellationToken)
            {
                var Food = await _FoodRepository.GetByIdAsync(command.Id);

                if (Food == null)
                {
                    throw new ApiException($"Food Not Found.");
                }
                else
                {
                    Food.Name = command.Name;
                    Food.Barcode = command.Barcode;
                    Food.Description = command.Description;
                    await _FoodRepository.UpdateAsync(Food);
                    return new Response<int>(Food.Id);
                }
            }
        }
    }

}
