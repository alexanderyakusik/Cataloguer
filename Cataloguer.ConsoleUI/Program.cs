using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerBuilder()
                .WithMapper()
                .Build();

            var initializer = container.Resolve<Initializer>();
            initializer.Run();

            var c = container.Resolve<IQualityService>();
            var _1 = c.GetAll();
            var _2 = c.Create(new Quality { Name = "Test" });
            var _3 = c.Get(_2);
            _3.Name = "Test_Updated";
            c.Update(_3);
            var _4 = c.GetAll();
            c.Delete(_3.Id);
            var _5 = c.GetAll();
        }
    }
}
