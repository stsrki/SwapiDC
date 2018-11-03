#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public class Calculator : ICalculator
    {
        #region Methods

        public long ToStops( long distance, long mglt, long hours )
        {
            return (long)((double)distance / ( hours * mglt ));
        }

        public long ToHours( Duration duration )
        {
            if ( duration == null )
                throw new ArgumentNullException( nameof( duration ) );

            switch ( duration.Unit )
            {
                case TimeUnit.Day:
                    return 24 * duration.Time;
                case TimeUnit.Week:
                    return 168 * duration.Time;
                case TimeUnit.Month:
                    return 730 * duration.Time;
                case TimeUnit.Year:
                    return 8760 * duration.Time;
                default:
                    return 0;
                    //throw new ArgumentException( "Invalid time unit." );
            }
        }

        #endregion
    }
}
