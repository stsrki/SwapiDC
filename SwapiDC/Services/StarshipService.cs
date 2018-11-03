#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsAPI;
using SwapiDC.Models;
#endregion

namespace SwapiDC.Services
{
    public interface IStarshipService
    {
        Task<Starship> Get( int id );

        Task<List<Starship>> GetAll();
    }

    public class StarshipService : IStarshipService
    {
        #region Members

        private readonly IMapper mapper;

        #endregion

        #region Constructors

        public StarshipService( IMapper mapper )
        {
            this.mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<Starship> Get( int id )
        {
            var api = new StarWarsAPIClient();

            var starship = await api.GetStarshipAsync( id.ToString() );

            return await Task.FromResult( mapper.GetStarship( starship ) );
        }

        public async Task<List<Starship>> GetAll()
        {
            var api = new StarWarsAPIClient();

            var starships = new List<Starship>();

            int pageNo = 0;

            while ( true )
            {
                var page = await api.GetAllStarship( ( ++pageNo ).ToString() );

                starships.AddRange( page.results.Select( x => mapper.GetStarship( x ) ) );

                if ( !page.isNext )
                    break;
            }

            return starships;
        }

        #endregion
    }
}
