using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace EFCoreExtensions
{
    public class ExampleContext<T> : DbContext
    {
        protected string ConnectionString { get; set; } 

        protected List<Assembly> OtherAssemblies { get; set; }  

        public ExampleContext(string ConnectionString, List<Assembly> OtherAssemblies)
        {
            this.ConnectionString = ConnectionString;
            this.OtherAssemblies = OtherAssemblies;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                  .UseSqlServer(this.ConnectionString, options =>
                  {
                      options.CommandTimeout(null);
                  });
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Type> typesInThisAssembly = typeof(T).Assembly.GetTypes().ToList();
            List<Type> typesFromOtherAssemblies = this.OtherAssemblies.SelectMany(r => r.GetTypes()).ToList();

            typesFromOtherAssemblies.ForEach(type =>
            {
                Console.WriteLine($"Ignoring type {type.Name}");
                modelBuilder.Ignore(type);
               
            });

            typesInThisAssembly.ForEach(type =>
            {
                var entityModel = modelBuilder.Entity(type);
                Console.WriteLine($"Ignoring indexes on {type.Name}");

                foreach (var index in modelBuilder.Entity(type).Metadata.GetIndexes().ToList())
                {
                    Console.WriteLine($"Found and will remove index {String.Join(", ", index.Properties.Select(s => s.Name))}");
                    entityModel.Metadata.RemoveIndex(index);
                }
            });
        }

    }
}
