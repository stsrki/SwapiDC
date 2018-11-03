#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiDC.Models;
#endregion

namespace SwapiDC
{
    public interface IMapper
    {
        Starship GetStarship( StarWarsAPI.Model.Starship starship );
    }
}
