#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC.Models
{
    /// <summary>
    /// A Starship resource is a single transport craft that has hyperdrive capability.
    /// </summary>
    public class Starship
    {
        /// <summary>
        /// Starship name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Maximum number of Megalights this starship can travel in a standard hour.
        /// </summary>
        public long MGLT { get; set; }

        /// <summary>
        /// The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        /// </summary>
        public Duration Consumables { get; set; }
    }
}
