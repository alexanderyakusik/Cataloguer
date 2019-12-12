namespace Cataloguer.Infrastructure.DependencyInjection.Interfaces
{
    public interface IModule
    {
        void RegisterDependencies(Container container);
    }
}
