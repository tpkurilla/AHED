using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Util
{
    /// <summary>
    /// Conduit for all logging activity for AHED.
    /// <remarks>
    /// @todo: Change this interface to match general logging.
    /// @todo: Stream messages to some panel in UI
    /// @todo: Actually perform logging.
    /// </remarks>
    /// </summary>
    public class Log
    {
        public enum Level { None, Info, Warning, Error, Fatal };

        static public void Message(Level level, string msg)
        {
        }

        static public void Info(string msg)
        {
            Message(Level.Info, msg);
        }

        static public void Warning(string msg)
        {
            Message(Level.Warning, msg);
        }

        static public void Error(string msg)
        {
            Message(Level.Error, msg);
        }

        static public void Fatal(string msg)
        {
            Message(Level.Fatal, msg);
        }
    }
}
