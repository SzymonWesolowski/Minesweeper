using MineSweeper.Application;
using StructureMap;

namespace MineSweeper.TestPresentation
{
    class MineSweeperRegistry : Registry
    {
        public MineSweeperRegistry()
        {
            Scan(s =>
            {
                s.AssembliesFromApplicationBaseDirectory();
                s.LookForRegistries();
                s.WithDefaultConventions();
            });
            For<IUserOperations>().Use<ConsoleOperations>();
        }
    }
}
