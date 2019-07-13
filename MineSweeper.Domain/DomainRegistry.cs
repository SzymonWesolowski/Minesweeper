using MineSweeper.Domain.Model;
using StructureMap;

namespace MineSweeper.Domain
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });
            For<IGrid>().Use<Grid>();
        }
    }
}