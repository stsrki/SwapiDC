#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public class Mapper : IMapper
    {
        #region Members

        private readonly IParser parser;

        #endregion

        #region Constructors

        public Mapper( IParser parser )
        {
            this.parser = parser;
        }

        #endregion

        #region Methods

        public Models.Starship GetStarship( StarWarsAPI.Model.Starship starship )
        {
            return starship == null ? null : new Models.Starship
            {
                Name = starship.name,
                Consumables = parser.ParseDuration( starship.consumables ),
                MGLT = parser.ParseInt( starship.MGLT ),
            };
        }

        #endregion
    }
}
