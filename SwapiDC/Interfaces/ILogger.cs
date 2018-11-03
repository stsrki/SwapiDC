#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public interface ILogger
    {
        void Info( string message, params object[] results );

        void Success( string message );

        void Error( string message );
    }
}
