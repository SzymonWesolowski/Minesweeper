using MineSweeper.Domain;
using StructureMap;

namespace MineSweeper.Application
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });
        }
        
    }
}