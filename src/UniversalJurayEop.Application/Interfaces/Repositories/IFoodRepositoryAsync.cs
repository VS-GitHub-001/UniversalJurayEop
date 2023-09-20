using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalJurayEop.Domain.Models;

namespace UniversalJurayEop.Application.Interfaces.Repositories
{
    public interface IFoodRepositoryAsync : IGenericRepositoryAsync<Food>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
