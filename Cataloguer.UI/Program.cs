using Cataloguer.Infrastructure.Configuration;
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
            var config = new AppConfiguration();
            var initializer = new Initializer(config);

            initializer.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Cataloguer(config));
        }
    }
}
