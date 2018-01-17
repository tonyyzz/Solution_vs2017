using System;
using log4net;

namespace Auction.Utility.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class LogHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LogHelper));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void WriteFatal(string msg, Exception e = null)
        {
            logger.Fatal(msg, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void WriteError(string msg, Exception e = null)
        {
            logger.Error(msg, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void WriteLog(string msg, Exception e = null)
        {
            logger.Info(msg, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void WritDebug(string msg, Exception e = null)
        {
            logger.Debug(msg, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void WritWarn(string msg, Exception e = null)
        {
            logger.Warn(msg, e);
        }
    }

}