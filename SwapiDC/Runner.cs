#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiDC.Models;
using SwapiDC.Services;
#endregion

namespace SwapiDC
{
    public class Runner
    {
        #region Members

        private readonly ILogger logger;

        private readonly ICalculator calculator;

        private readonly IStarshipService starshipService;

        private List<Starship> starships;

        #endregion

        #region Constructors

        public Runner( ILogger logger, ICalculator calculator, IStarshipService starshipService )
        {
            this.logger = logger;
            this.calculator = calculator;
            this.starshipService = starshipService;
        }

        #endregion

        #region Methods

        public async Task Init()
        {
            logger.Info( "Getting all available starships." );

            starships = await starshipService.GetAll();
        }

        public void Run( long distance )
        {
            if ( starships == null )
                throw new ArgumentNullException( nameof( starships ) );

            logger.Success( $"Found {starships.Count} starships." );

            foreach ( var starship in starships )
            {
                if ( starship.MGLT == -1 )
                {
                    logger.Error( $"Unknown speed for: {starship.Name}" );
                    continue;
                }

                // Calculate total number of hours that the consumables can last.
                var hours = calculator.ToHours( starship.Consumables );

                // finaly calculate total number of stops required based on the distance, speed and time
                var stops = calculator.ToStops( distance, starship.MGLT, hours );

                logger.Info( $"{starship.Name} needs to stop: ", stops );
            }
        }

        #endregion
    }
}
