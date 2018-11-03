using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwapiDC.Services;
using NSubstitute;
using SwapiDC.Models;
using System.Threading.Tasks;
using SimpleInjector.Lifestyles;

namespace SwapiDC.Tests
{
    [TestClass]
    public class TestRunner : TestBase
    {
        private ILogger logger;
        private ICalculator calculator;
        private IStarshipService starshipService;

        [TestInitialize]
        public void Setup()
        {
            logger = Substitute.For<ILogger>();
            calculator = Substitute.For<ICalculator>();
            starshipService = Substitute.For<IStarshipService>();
        }

        [TestMethod]
        public async Task Test_runner_info()
        {
            starshipService.GetAll().Returns( new List<Starship>
            {
                new Starship { Name = "Millennium Falcon" }
            } );

            var runner = new Runner( logger, calculator, starshipService );

            await runner.Run( 1000000 );

            logger.Received().Info( "Millennium Falcon needs to stop: ", Arg.Any<object>() );
        }

        [TestMethod]
        public async Task Test_runner_invalid_mglt()
        {
            starshipService.GetAll().Returns( new List<Starship>
            {
                new Starship { Name = "Millennium Falcon", MGLT = -1 }
            } );

            var runner = new Runner( logger, calculator, starshipService );

            await runner.Run( 1000000 );

            logger.Received().Error( "Unknown speed for: Millennium Falcon" );
        }

        [TestMethod]
        public async Task Test_runner_mock()
        {
            var distance = 1000000;
            var mglt = 75;
            var consumables = new Duration( TimeUnit.Month, 2 );

            starshipService.GetAll().Returns( new List<Starship>
            {
                new Starship { Name = "Millennium Falcon", MGLT = mglt, Consumables = consumables }
            } );

            calculator.ToHours( consumables ).Returns( 1460 );
            calculator.ToStops( distance, mglt, 1460 ).Returns( 9 );

            var runner = new Runner( logger, calculator, starshipService );

            await runner.Run( distance );

            long expected = 9;

            logger.Received().Info( "Millennium Falcon needs to stop: ", expected );
        }

        [TestMethod]
        public async Task Test_runner_real_calculator()
        {
            var distance = 1000000;
            var mglt = 75;
            var consumables = new Duration( TimeUnit.Month, 2 );

            starshipService.GetAll().Returns( new List<Starship>
            {
                new Starship { Name = "Millennium Falcon", MGLT = mglt, Consumables = consumables }
            } );

            var calculator = container.GetInstance<ICalculator>();

            var runner = new Runner( logger, calculator, starshipService );

            await runner.Run( distance );

            long expected = 9;

            logger.Received().Info( "Millennium Falcon needs to stop: ", expected );
        }

        [TestMethod]
        public async Task Test_runner_full_integration()
        {
            using ( AsyncScopedLifestyle.BeginScope( container ) )
            {
                // mock only the logger
                var logger = Substitute.For<ILogger>();

                // real instances
                var calculator = container.GetInstance<ICalculator>();
                var starshipService = container.GetInstance<IStarshipService>();

                var runner = new Runner( logger, calculator, starshipService );

                await runner.Run( 1000000 );

                logger.Received( 1 ).Info( Arg.Any<string>() );
                logger.Received( 1 ).Success( Arg.Any<string>() );
                logger.Received( 17 ).Info( Arg.Any<string>(), Arg.Any<object>() );
                logger.Received( 20 ).Error( Arg.Any<string>() );

                logger.Received().Info( "Millennium Falcon needs to stop: ", Arg.Is<long>( 9 ) );
            }
        }
    }
}
