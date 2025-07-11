﻿using AutoMapper;
using MF.Domain.Interfaces.Repositories;
using MF.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace MF.Application.Services
{
    public class Service<TEntity, TEntityDto> : IServiceBase<TEntity, TEntityDto>
        where TEntity : class
        where TEntityDto : class
    {
        private readonly IERepositoryBase<TEntity> repository;
        private readonly IMapper mapper;

        public Service(IERepositoryBase<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TEntityDto> AddAsync(TEntityDto entityDto)
        {
            return mapper.Map<TEntityDto>(await repository.AddAsync(mapper.Map<TEntity>(entityDto)).ConfigureAwait(false));
        }

        public async Task AddRangeAsync(IEnumerable<TEntityDto> entities)
        {
            await repository.AddRangeAsync(mapper.Map<IEnumerable<TEntity>>(entities)).ConfigureAwait(false);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await repository.AnyAsync(filter).ConfigureAwait(false);
        }

        public async Task DeleteAsync(TEntityDto entity)
        {
            await repository.DeleteAsync(mapper.Map<TEntity>(entity)).ConfigureAwait(false);
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntityDto> entities)
        {
            await repository.DeleteRangeAsync(mapper.Map<IEnumerable<TEntity>>(entities)).ConfigureAwait(false);
        }

        public async Task ExecuteSqlCommandAsync(string query, params object[] parameters)
        {
            await repository.ExecuteSqlCommandAsync(query, parameters).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntityDto>> ExecuteStoredProcedureAsync(string query, params object[] parameters)
        {
            return mapper.Map<IEnumerable<TEntityDto>>(await repository.ExecuteStoredProcedureAsync(query, parameters).ConfigureAwait(false));
        }

        public async Task<TEntityDto> FindByIdAsync(dynamic id)
        {
            var book = await repository.FindByIdAsync(id).ConfigureAwait(false);
            return book != null ? mapper.Map<TEntityDto>(book) : null;
        }

        public async Task<TEntityDto> FindByAlternateKeyAsync(Expression<Func<TEntity, bool>> alternateKey, string includeProperties = "")
        {
            var book = await repository.FindByAlternateKeyAsync(alternateKey, includeProperties).ConfigureAwait(false);
            return book != null ? mapper.Map<TEntityDto>(book) : null;
        }

        public async Task<IEnumerable<TEntityDto>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return mapper.Map<IEnumerable<TEntityDto>>(await repository.GetAllAsync(filter, orderBy, includeProperties).ConfigureAwait(false));
        }

        public async Task<IEnumerable<TEntityDto>> GetAllPagedAsync(int take, int skip, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return mapper.Map<IEnumerable<TEntityDto>>(await repository.GetAllPagedAsync(take, skip, filter, orderBy, includeProperties).ConfigureAwait(false));
        }

        public async Task UpdateAsync(TEntityDto entity)
        {
            await repository.UpdateAsync(mapper.Map<TEntity>(entity)).ConfigureAwait(false);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntityDto> entities)
        {
            await repository.UpdateRangeAsync(mapper.Map<IEnumerable<TEntity>>(entities)).ConfigureAwait(false);
        }

        public async Task TruncateTableAsync()
        {
            await repository.ExecuteSqlCommandAsync($"TRUNCATE TABLE [used].[{typeof(TEntityDto).Name}]").ConfigureAwait(false);
        }
    }
}
