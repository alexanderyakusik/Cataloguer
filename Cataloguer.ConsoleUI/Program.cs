using Cataloguer.ConsoleUI.DependencyInjection;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new UIModule())
                .WithMapper();

            var initializer = container.Resolve<Initializer>();
            initializer.Run();
        }
    }
}
