using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SwapiDC.Services;

namespace SwapiDC.Tests
{
    [TestClass]
    public class TestBase
    {
        protected readonly Container container;

        public TestBase()
        {
            container = new Container();

            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            container.Register<ILogger, Logger>();
            container.Register<IParser, Parser>();
            container.Register<ICalculator, Calculator>();
            container.Register<IMapper, Mapper>();
            container.Register<IStarshipService, StarshipService>();

            container.Verify();
        }
    }
}
