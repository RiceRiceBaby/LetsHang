using LetsHang.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Data
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Name=LetsHang")
        {
            Database.SetInitializer<EFContext>(null);
            Database.Connection.Open();
        }

        /// <summary>
        /// Returns a set of whatever type the repostiory asks for
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            // Calls set method of the DbContext class
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Loops through current assembly and finds all the domain models created and registers them.
            // Finds them by looking for all objects that inherit from BaseEntity
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }


            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {
            Database.Connection.Close();
            base.Dispose();
        }
    }
}
