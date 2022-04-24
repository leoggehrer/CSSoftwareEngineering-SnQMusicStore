//@CodeCopy
//MdStart
using System.Linq;
using System.Threading.Tasks;
using SnQMusicStore.Logic.Modules.Exception;
using System.Linq.Expressions;
using System;
#if ACCOUNT_ON
using System.Reflection;
#endif

namespace SnQMusicStore.Logic.Controllers
{
    internal abstract partial class GenericController<TContact, TEntity> : ControllerObject, Contracts.Client.IControllerAccess<TContact>
        where TContact : Contracts.IIdentifiable
        where TEntity : Entities.IdentityEntity, TContact, Contracts.ICopyable<TContact>, new()
    {
        #region Class-Constructors
        static GenericController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        #endregion Class-Constructors

        #region Properties
        public abstract bool IsTransient { get; }
        public virtual int MaxPageSize { get; } = 500;
        #endregion Properties

        #region Instance-Constructors
        protected GenericController(DataContext.IContext context) : base(context)
        {
            Constructing();
            Constructed();
        }
        protected GenericController(ControllerObject other) : base(other)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        #endregion Instance-Constructors

        #region Converter
        protected virtual TEntity ConvertTo(TContact contract)
        {
            var result = new TEntity();

            result.CopyProperties(contract);
            return result;
        }
        protected virtual IQueryable<TEntity> ConvertTo(IQueryable<TContact> contracts)
        {
            var result = new List<TEntity>();

            foreach (var item in contracts)
            {
                result.Add(ConvertTo(item));
            }
            return result.AsQueryable();
        }
        #endregion Converter

        #region Count
        public virtual async Task<int> CountAsync()
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryCount).ConfigureAwait(false);
#endif
            return await ExecuteCountAsync().ConfigureAwait(false);
        }
        internal abstract Task<int> ExecuteCountAsync();

        public virtual async Task<int> CountByAsync(string predicate)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryCountBy).ConfigureAwait(false);
#endif
            return await ExecuteCountByAsync(predicate).ConfigureAwait(false);
        }
        internal abstract Task<int> ExecuteCountByAsync(string predicate);
        #endregion Count

        #region Before-Return
        protected virtual TEntity BeforeReturn(TEntity entity) { return entity; }
        protected virtual IEnumerable<TEntity> BeforeReturn(IEnumerable<TEntity> entities)
        {
            var result = new List<TEntity>();

            foreach (var item in entities)
            {
                result.Add(BeforeReturn(item));
            }
            return result;
        }
        protected virtual Task<TEntity> BeforeReturnAsync(TEntity entity) => Task.FromResult(entity);
        protected virtual async Task<IEnumerable<TEntity>> BeforeReturnAsync(IEnumerable<TEntity> entities)
        {
            var result = new List<TEntity>();

            foreach (var item in entities)
            {
                result.Add(await BeforeReturnAsync(item).ConfigureAwait(false));
            }
            return result;
        }
        #endregion Before-Return

        #region Query
        public virtual async ValueTask<TContact?> GetByIdAsync(int id)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.GetBy).ConfigureAwait(false);
#endif
            return await GetEntityByIdAsync(id).ConfigureAwait(false);
        }
        internal virtual async Task<TEntity> GetEntityByIdAsync(int id)
        {
            var result = await ExecuteGetEntityByIdAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                throw new LogicException(ErrorType.InvalidId, $"Invalid id '{id}'.");
            }
            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract ValueTask<TEntity?> ExecuteGetEntityByIdAsync(int id);

        public virtual async Task<IEnumerable<TContact>> GetPageListAsync(int pageIndex, int pageSize)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.GetAll).ConfigureAwait(false);
#endif

            return await GetEntityPageListAsync(pageIndex, pageSize).ConfigureAwait(false);
        }
        public virtual async Task<IEnumerable<TContact>> GetPageListAsync(string orderBy, int pageIndex, int pageSize)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.GetAll).ConfigureAwait(false);
#endif

            return await GetEntityPageListAsync(orderBy, pageIndex, pageSize).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> GetEntityPageListAsync(int pageIndex, int pageSize)
        {
            if (pageSize < 1 && pageSize > MaxPageSize)
                throw new LogicException(ErrorType.InvalidPageSize);

            var result = await ExecuteGetEntityPageListAsync(pageIndex, pageSize).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> GetEntityPageListAsync(string orderBy, int pageIndex, int pageSize)
        {
            if (pageSize < 1 && pageSize > MaxPageSize)
                throw new LogicException(ErrorType.InvalidPageSize);

            var result = await ExecuteGetEntityPageListAsync(orderBy, pageIndex, pageSize).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<IEnumerable<TEntity>> ExecuteGetEntityPageListAsync(int pageIndex, int pageSize);
        internal abstract Task<IEnumerable<TEntity>> ExecuteGetEntityPageListAsync(string orderBy, int pageIndex, int pageSize);

        public virtual async Task<IEnumerable<TContact>> GetAllAsync()
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.GetAll).ConfigureAwait(false);
#endif
            return await GetEntityAllAsync().ConfigureAwait(false);
        }
        public virtual async Task<IEnumerable<TContact>> GetAllAsync(string orderBy)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.GetAll).ConfigureAwait(false);
#endif
            return await GetEntityAllAsync(orderBy).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> GetEntityAllAsync()
        {
            var result = await ExecuteGetEntityAllAsync().ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> GetEntityAllAsync(string orderBy)
        {
            var result = await ExecuteGetEntityAllAsync().ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<IEnumerable<TEntity>> ExecuteGetEntityAllAsync();
        internal abstract Task<IEnumerable<TEntity>> ExecuteGetEntityAllAsync(string orderBy);

        public virtual async Task<IEnumerable<TContact>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryBy).ConfigureAwait(false);
#endif
            return await QueryEntityPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false);
        }
        public virtual async Task<IEnumerable<TContact>> QueryPageListAsync(string predicate, string orderBy, int pageIndex, int pageSize)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryBy).ConfigureAwait(false);
#endif
            return await QueryEntityPageListAsync(predicate, orderBy, pageIndex, pageSize).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> QueryEntityPageListAsync(string predicate, int pageIndex, int pageSize)
        {
            var result = await ExecuteQueryEntityPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> QueryEntityPageListAsync(string predicate, string orderBy, int pageIndex, int pageSize)
        {
            var result = await ExecuteQueryEntityPageListAsync(predicate, orderBy, pageIndex, pageSize).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityPageListAsync(string predicate, int pageIndex, int pageSize);
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityPageListAsync(string predicate, string orderBy, int pageIndex, int pageSize);

        internal virtual async Task<IEnumerable<TEntity>> QueryEntityPageListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            var result = await ExecuteQueryEntityPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityPageListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        public virtual async Task<IEnumerable<TContact>> QueryAllAsync(string predicate)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryAll).ConfigureAwait(false);
#endif
            return await QueryEntityAllAsync(predicate).ConfigureAwait(false);
        }
        public virtual async Task<IEnumerable<TContact>> QueryAllAsync(string predicate, string orderBy)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.QueryAll).ConfigureAwait(false);
#endif
            return await QueryEntityAllAsync(predicate, orderBy).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> QueryEntityAllAsync(string predicate)
        {
            var result = await ExecuteQueryEntityAllAsync(predicate).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> QueryEntityAllAsync(string predicate, string orderBy)
        {
            var result = await ExecuteQueryEntityAllAsync(predicate, orderBy).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal virtual async Task<IEnumerable<TEntity>> QueryEntityAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await ExecuteQueryEntityAllAsync(predicate).ConfigureAwait(false);

            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityAllAsync(Expression<Func<TEntity, bool>> predicate);
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityAllAsync(string predicate);
        internal abstract Task<IEnumerable<TEntity>> ExecuteQueryEntityAllAsync(string predicate, string orderBy);
        #endregion Query

        #region Create
        public virtual async Task<TContact> CreateAsync()
        {
            return await CreateEntityAsync().ConfigureAwait(false);
        }
        internal virtual async Task<TEntity> CreateEntityAsync()
        {
            var entity = new TEntity();

            AfterCreate(entity);
            return await BeforeReturnAsync(entity).ConfigureAwait(false);
        }
        protected virtual void AfterCreate(TEntity entity)
        {
        }
        #endregion Create

        #region InsertUpdate
        protected virtual TEntity BeforeInsertUpdate(TEntity entity) { return entity; }
        protected virtual Task<TEntity> BeforeInsertUpdateAsync(TEntity entity) => Task.FromResult(entity);
        protected virtual TEntity AfterInsertUpdate(TEntity entity) { return entity; }
        protected virtual Task<TEntity> AfterInsertUpdateAsync(TEntity entity) => Task.FromResult(entity);
        #endregion InsertUpdate

        #region Insert
        protected virtual TEntity BeforeInsert(TEntity entity) { return entity; }
        protected virtual Task<TEntity> BeforeInsertAsync(TEntity entity) => Task.FromResult(entity);
        public virtual async Task<TContact> InsertAsync(TContact entity)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Insert).ConfigureAwait(false);
#endif
            var innerEntity = await CreateEntityAsync().ConfigureAwait(false);

            innerEntity.CopyProperties(entity);

            return await InsertEntityAsync(innerEntity).ConfigureAwait(false);
        }
        internal virtual async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            entity = BeforeInsertUpdate(entity);
            entity = await BeforeInsertUpdateAsync(entity).ConfigureAwait(false);
            entity = BeforeInsert(entity);
            entity = await BeforeInsertAsync(entity).ConfigureAwait(false);
            var result = await ExecuteInsertEntityAsync(entity).ConfigureAwait(false);
            result = AfterInsert(result);
            result = await AfterInsertAsync(result).ConfigureAwait(false);
            result = AfterInsertUpdate(result);
            result = await AfterInsertUpdateAsync(result).ConfigureAwait(false);
            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<TEntity> ExecuteInsertEntityAsync(TEntity entity);
        protected virtual TEntity AfterInsert(TEntity entity) { return entity; }
        protected virtual Task<TEntity> AfterInsertAsync(TEntity entity) => Task.FromResult(entity);
        public virtual async Task<IEnumerable<TContact>> InsertAsync(IEnumerable<TContact> entities)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.InsertArray).ConfigureAwait(false);
#endif
            var result = new List<TContact>();

            foreach (var entity in entities)
            {
                result.Add(await InsertEntityAsync(ConvertTo(entity)).ConfigureAwait(false));
            }
            return result.AsQueryable();
        }
        #endregion Insert

        #region Update
        protected virtual TEntity BeforeUpdate(TEntity entity) { return entity; }
        protected virtual Task<TEntity> BeforeUpdateAsync(TEntity entity) => Task.FromResult(entity);
        public virtual async Task<TContact> UpdateAsync(TContact entity)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Update).ConfigureAwait(false);
#endif
            var innerEntity = await GetEntityByIdAsync(entity.Id).ConfigureAwait(false);

            innerEntity.CopyProperties(entity);
            return await UpdateEntityAsync(innerEntity).ConfigureAwait(false);
        }
        internal virtual async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            entity = BeforeInsertUpdate(entity);
            entity = await BeforeInsertUpdateAsync(entity).ConfigureAwait(false);
            entity = BeforeUpdate(entity);
            entity = await BeforeUpdateAsync(entity).ConfigureAwait(false);
            var result = await ExecuteUpdateEntityAsync(entity).ConfigureAwait(false);
            result = AfterUpdate(result);
            result = await AfterUpdateAsync(result).ConfigureAwait(false);
            result = AfterInsertUpdate(result);
            result = await AfterInsertUpdateAsync(result).ConfigureAwait(false);
            result = BeforeReturn(result);
            return await BeforeReturnAsync(result).ConfigureAwait(false);
        }
        internal abstract Task<TEntity> ExecuteUpdateEntityAsync(TEntity entity);
        protected virtual TEntity AfterUpdate(TEntity entity) { return entity; }
        protected virtual Task<TEntity> AfterUpdateAsync(TEntity entity) => Task.FromResult(entity);
        public virtual async Task<IEnumerable<TContact>> UpdateAsync(IEnumerable<TContact> entities)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.UpdateArray).ConfigureAwait(false);
#endif
            var result = new List<TContact>();

            foreach (var entity in entities)
            {
                result.Add(await UpdateEntityAsync(ConvertTo(entity)).ConfigureAwait(false));
            }
            return result.AsQueryable();
        }
        #endregion Update

        #region Delete
        protected virtual void BeforeDelete(TEntity entity) { }
        protected virtual Task BeforeDeleteAsync(TEntity entity) => Task.FromResult(0);
        public virtual async Task DeleteAsync(int id)
        {
#if ACCOUNT_ON
            await CheckAuthorizationAsync(GetType(), MethodBase.GetCurrentMethod(), AccessType.Delete).ConfigureAwait(false);
#endif
            var entity = await GetEntityByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
                throw new LogicException(ErrorType.InvalidId);

            await DeleteEntityAsync(entity).ConfigureAwait(false);
        }
        internal virtual async Task DeleteEntityAsync(TEntity entity)
        {
            BeforeDelete(entity);
            await BeforeDeleteAsync(entity).ConfigureAwait(false);
            await ExecuteDeleteEntityAsync(entity).ConfigureAwait(false);
            AfterDelete(entity);
            await AfterDeleteAsync(entity).ConfigureAwait(false);
        }
        internal abstract Task ExecuteDeleteEntityAsync(TEntity entity);
        protected virtual void AfterDelete(TEntity entity) { }
        protected virtual Task AfterDeleteAsync(TEntity entity) => Task.FromResult(0);
        #endregion Delete
    }
}
//MdEnd
