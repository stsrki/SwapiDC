#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public class Parser : IParser
    {
        #region Methods

        public Duration ParseDuration( string consumables )
        {
            if ( string.IsNullOrEmpty( consumables ) )
                throw new ArgumentNullException( nameof( consumables ) );

            var parts = consumables.Split( ' ' );

            if ( parts?.Count() != 2 )
                return new Duration( TimeUnit.Unknown, -1 );
            //throw new ArgumentException( "Invalid consumables type.", nameof( consumables ) );

            return new Duration( ParseTimeUnit( parts[1] ), ParseInt( parts[0] ) );
        }

        public TimeUnit ParseTimeUnit( string unit )
        {
            switch ( unit )
            {
                case "day":
                case "days":
                    return TimeUnit.Day;
                case "week":
                case "weeks":
                    return TimeUnit.Week;
                case "month":
                case "months":
                    return TimeUnit.Month;
                case "year":
                case "years":
                    return TimeUnit.Year;
                default:
                    return TimeUnit.Unknown;
            }
        }

        public int ParseInt( string value )
        {
            if ( int.TryParse( value, out var number ) )
                return number;

            return -1;
        }

        #endregion
    }
}
