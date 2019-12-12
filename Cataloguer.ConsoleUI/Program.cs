using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping;
using System;

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

            var m = container.Resolve<IMovieService>();

            //m.Create(new Movie
            //{
            //    Name = "test",
            //    ReleaseDate = DateTime.Now,
            //    Runtime = TimeSpan.FromHours(2.0),
            //    Company = new Company { Id = 1 },
            //    Quality = new Quality { Id = 1 },
            //    Genre = new Genre { Id = 1 },
            //    Format = new Format { Id = 1 },
            //    Poster = new Poster { Image = new byte[] { 65, 65, 65 } },
            //});

            //var _1 = m.Get(1);
            //_1.Name = "test_updated";
            //_1.ReleaseDate = DateTime.Now;
            //_1.Runtime = TimeSpan.FromHours(3.0);
            //_1.Company.Id = 2;
            //_1.Genre.Id = 2;
            //_1.Format.Id = 2;
            //_1.Quality.Id = 2;
            //_1.Poster.Image = new byte[] { 66, 66, 66 };

            //m.Update(_1);

            m.Delete(1);
        }
    }
}
