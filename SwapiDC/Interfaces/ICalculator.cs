#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public interface ICalculator
    {
        long ToStops( long distance, long mglt, long hours );

        long ToHours( Duration duration );
    }
}
