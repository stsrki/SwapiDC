#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public interface IParser
    {
        Duration ParseDuration( string consumables );

        TimeUnit ParseTimeUnit( string unit );

        int ParseInt( string value );
    }
}
