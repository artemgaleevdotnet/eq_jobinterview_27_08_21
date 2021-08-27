using Interview.DomainModel;
using StructureMap.Configuration.DSL;

namespace Interview.Services
{
    public class DependencyRegistry
    {
        public static void AddDependencies(Registry defaultRegistry)
        {
            defaultRegistry.For<ISomeEntityService>().Use<SomeEntityService>();
        }
    }
}
