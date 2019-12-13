using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping;
using System;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new ContainerBuilder()
                .WithMapper()
                .Build();

            Application.Run(container.Resolve<Cataloguer>());
        }
    }
}
