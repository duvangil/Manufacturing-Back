using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces.Services
{
   public interface IProductImportService
    {
        Task<List<string>> ImportProductsAsync(Stream excelStream);
    }
}
