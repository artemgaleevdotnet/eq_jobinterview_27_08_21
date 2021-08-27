using Interview.DomainModel;
using StructureMap.Configuration.DSL;

namespace Interview.DataAccess
{
    public class DependencyRegistry
    {
        public static void AddDependencies(Registry defaultRegistry)
        {
            defaultRegistry.For<ISomeEntityRepository>().Use<SomeEntityRepository>();
            defaultRegistry.For<IFileReaderWriter>().Use<FileReaderWriter>();
        }
    }
}
