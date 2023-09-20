using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Application.Interfaces;
using UniversalJurayEop.Application.Interfaces.Repositories;
using UniversalJurayEop.Domain.Models;
using UniversalJurayEop.Infrastructure.Context;

namespace UniversalJurayEop.Infrastructure.Repositories
{
    public class FoodRepositoryAsync : GenericRepositoryAsync<Food>, IFoodRepositoryAsync
    {
        private readonly DbSet<Food> _food;
        public FoodRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _food = dbContext.Set<Food>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _food
                .AllAsync(p => p.Barcode != barcode);

        }
    }
}
