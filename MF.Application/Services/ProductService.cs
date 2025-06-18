using AutoMapper;
using MF.Domain.Dtos;
using MF.Domain.Entities;
using MF.Domain.Helpers;
using MF.Domain.Interfaces.Repositories;
using MF.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MF.Application.Services
{
    public class ProductService : Service<Product, ProductDto>, IProductService
    {
        public IConfiguration Configuration { get; }
        public ProductService(IProductRepository productRepository, IMapper mapper, IConfiguration configuration) : base(productRepository, mapper)
        {
            Configuration = configuration; 
        }

        public async Task RemoveStockAsync(Guid productId, int quantity)
        {
            var product = await FindByIdAsync(productId);
            if (product is null) throw new Exception("Producto no encontrado");

            if (product.Quantity < quantity)
                throw new InvalidOperationException("Stock insuficiente");

            product.Quantity -= quantity;

            if (product.Quantity == 0)
                product.State = ProductStates.OutOfStock;

            await base.UpdateAsync(product);
        }
    }
}
