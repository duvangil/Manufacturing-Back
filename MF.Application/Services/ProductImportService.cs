using ClosedXML.Excel;
using MF.Domain.Dtos;
using MF.Domain.Entities;
using MF.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Application.Services
{
    public class ProductImportService: IProductImportService
    {
        private readonly IProductService _productService;
        private readonly IElaborationTypeService _elaborationTypeService;

        public ProductImportService(IProductService productService, IElaborationTypeService elaborationTypeService)
        {
            _productService = productService;
            _elaborationTypeService = elaborationTypeService;
        }

        public async Task<List<string>> ImportProductsAsync(Stream excelStream)
        {
            List<string> errors = new List<string>();

            List<ProductDto> listProduct = new List<ProductDto>();

            using var workbook = new XLWorkbook(excelStream);
            var worksheet = workbook.Worksheets.First();
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Salta encabezado

            foreach (var row in rows)
            {
                try
                {
                    var dto = new ProductImportDto
                    {
                        Name = row.Cell(1).GetString(),
                        ElaborationTypeName = row.Cell(2).GetString(),
                        Quantity = (int)row.Cell(3).GetDouble(),
                        State = row.Cell(4).GetString()
                    };

                    var elaborationType = await _elaborationTypeService
                        .FindByAlternateKeyAsync( x=> x.Name == dto.ElaborationTypeName);

                    if (elaborationType == null)
                    {
                        errors.Add($"Tipo de elaboración no encontrado: {dto.ElaborationTypeName}");
                        continue;
                    }

                    var product = new ProductDto
                    {
                        Id = Guid.NewGuid(),
                        Name = dto.Name,
                        Quantity = dto.Quantity,
                        State = dto.State,
                        ElaborationTypeId = elaborationType.Id,
                        DateCreated = DateTime.UtcNow
                    };

                    listProduct.Add(product);
                }
                catch (Exception ex)
                {
                    errors.Add($"Error en fila {row.RowNumber()}: {ex.Message}");
                }
            }
              await _productService.AddRangeAsync(listProduct);
            return errors;
        }
    }

}
