using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MealsApi.Data.Contracts;
using MealsApi.Utils.Configuration;
using MealsApi.Utils.Ef;

namespace MealsApi.Data.Context
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        private readonly IGuidGenerator _generator;
        readonly IConfigurationModule[] _modules;

        protected DbContextBase(IConfiguration configuration, 
            IGuidGenerator generator, params IConfigurationModule[] modules)
            : base(configuration.DatabaseConnection)
        {
            _generator = generator;
            _modules = modules;
        }


        protected DbContextBase()
        {

        }

        protected DbContextBase(EntityConnection connection, params IConfigurationModule[] modules)
            : base(connection, true)
        {
            _modules = modules;
        }

        protected DbContextBase(DbConnection connection, params IConfigurationModule[] modules)
            : base(connection, true)
        {
            _modules = modules;
        }

        protected DbContextBase(EntityConnection connection)
            : base(connection, true)
        {
        }

        protected DbContextBase(DbConnection connection)
            : base(connection, true)
        {
        }

        protected DbContextBase(string connectionString, params IConfigurationModule[] modules)
            : base(connectionString)
        {
            _modules = modules;
        }

        public void Attach<T>(T entity) where T : class, IBaseEntity
        {
            Set<T>().Attach(entity);
        }

        public IQueryable<T> AsQueryable<T>() where T : class, IBaseEntity
        {
            return Set<T>().AsQueryable();
        }

        public void Update<T>(T entity) where T : class, IBaseEntity
        {
            EnsureAttachedEf(entity).State = EntityState.Modified;
            var orig = Set<T>().Find(entity.Id);
            if (orig != null)
            {
                Entry(entity).CurrentValues.SetValues(entity);
            }

            SaveChanges();
        }

        public void Save<T>(T entity) where T : class, IBaseEntity
        {
            Set<T>().Add(entity);
            SaveChanges();
        }

        DbEntityEntry<T> EnsureAttachedEf<T>(T entity) where T : class, IBaseEntity
        {
            if (Entry(entity).State == EntityState.Detached)
                Set<T>().Attach(entity);

            return Entry(entity);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added))
            {
                entry.Entity.Id = _generator.NewId();
            }

            return SaveUtil.ExecuteDatabaseSave(base.SaveChanges);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_modules != null && _modules.Any())
            {
                foreach (var module in _modules)
                {
                    module.Register(modelBuilder);
                }
            }
        }
    }
}