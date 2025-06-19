using MF.Application.Services;
using MF.Domain.Dtos;
using MF.Domain.Helpers;
using MF.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manufacturing_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        private readonly IProductImportService ProductImportService;
        public ProductController(IProductService productService, IProductImportService productImportService)
        {
            ProductService = productService;
            ProductImportService = productImportService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await ProductService.GetAllAsync(includeProperties: "ElaborationType").ConfigureAwait(false));
        }

        // POST api/Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            productDto.DateCreated = DateTime.UtcNow;
            await ProductService.AddAsync(productDto).ConfigureAwait(false);
            return Ok(productDto);
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }
            var existingProduct = await ProductService.FindByIdAsync(id).ConfigureAwait(false);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }
            productDto.DateCreated = existingProduct.DateCreated; // Preserve the original creation date
            productDto.ModifyDate = DateTime.UtcNow; // Update the modification date
            await ProductService.UpdateAsync(productDto).ConfigureAwait(false);
            return Ok(productDto);
        }

        // POST api/Product/
        [HttpPost("RemoveStock/{productId}/{quantity}")]
        public async Task<IActionResult> RemoveStock(Guid productId, int quantity)
        {
            try
            {
                await ProductService.RemoveStockAsync(productId, quantity).ConfigureAwait(false);
                return Ok("Stock updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Product/Import
        [HttpPost("import")]
        public async Task<IActionResult> ImportProducts(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado.");

            using var stream = file.OpenReadStream();
            var errors = await ProductImportService.ImportProductsAsync(stream);

            if (errors.Any())
                return BadRequest(new { message = "Errores durante la importación", errors });

            return Ok(new { message = "importación Exitosa" });
        }
    }
}
