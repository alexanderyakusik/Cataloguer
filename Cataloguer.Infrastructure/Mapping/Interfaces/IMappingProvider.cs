namespace Cataloguer.Infrastructure.Mapping.Interfaces
{
    public interface IMappingProvider
    {
        object Map(object source, Mapper mapper);
    }
}
