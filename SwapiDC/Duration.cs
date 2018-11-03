#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public class Duration
    {
        #region Constructors

        public Duration()
        {
        }

        public Duration( TimeUnit unit, long time )
        {
            Unit = unit;
            Time = time;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the time unit.
        /// </summary>
        public TimeUnit Unit { get; set; }

        /// <summary>
        /// Duration value.
        /// </summary>
        public long Time { get; set; }

        #endregion
    }
}
