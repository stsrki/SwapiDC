﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SwapiDC.Services;
#endregion

namespace SwapiDC
{
    class Program
    {
        static Container container;

        static async Task Main( string[] args )
        {
            try
            {
                Bootstrap();

                var runner = container.GetInstance<Runner>();

                string input = string.Empty;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write( "Enter distance: " );
                    Console.ForegroundColor = ConsoleColor.White;

                    input = Console.ReadLine();

                    if ( long.TryParse( input, out var distance ) )
                    {
                        if ( !runner.Initialised )
                            await runner.Init();

                        runner.Run( distance );
                    }
                } while ( input != "exit" );
            }
            catch ( Exception exc )
            {
                Console.WriteLine( exc.Message );
            }
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.Register<ILogger, Logger>();
            container.Register<IParser, Parser>();
            container.Register<ICalculator, Calculator>();
            container.Register<IMapper, Mapper>();
            container.Register<IStarshipService, StarshipService>();

            container.Verify();
        }
    }
}
