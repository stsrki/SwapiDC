#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace SwapiDC
{
    public class Logger : ILogger
    {
        #region Methods

        public void Info( string message, params object[] results )
        {
            Write( message, Color.Normal );

            foreach ( var result in results )
            {
                Write( result, Color.Success );
            }

            Console.Write( Environment.NewLine );
        }

        public void Success( string message )
        {
            Write( message, Color.Success );

            Console.Write( Environment.NewLine );
        }

        public void Error( string message )
        {
            Write( message, Color.Error );

            Console.Write( Environment.NewLine );
        }

        private void Write( object value, Color color )
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = GetConsoleColor( color );

            Console.Write( value );

            Console.ForegroundColor = foregroundColor;
        }

        private ConsoleColor GetConsoleColor( Color color )
        {
            switch ( color )
            {
                case Color.Success:
                    return ConsoleColor.Green;
                case Color.Error:
                    return ConsoleColor.Red;
                case Color.Info:
                    return ConsoleColor.Blue;
                default:
                    return ConsoleColor.White;
            }
        }

        #endregion
    }
}
