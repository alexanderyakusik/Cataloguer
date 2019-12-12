namespace Cataloguer.Infrastructure.DependencyInjection.Interfaces
{
    public interface IModule
    {
        int Order { get; }

        void RegisterDependencies(Container container);
    }
}
