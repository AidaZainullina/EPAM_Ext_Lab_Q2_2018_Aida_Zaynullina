namespace Task01.Returns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Task01.Controllers;
    using static Task01.Rep.Rep;

    public static class ReturnLogs
    {
        /// <summary>
        /// This method outputs a log
        /// </summary>
        /// <param name="html">The extention is defined</param>
        /// <returns>Returns the list of logs</returns>
        public static List<MvcHtmlString> GLog(this HtmlHelper html)
        {
            List<MvcHtmlString> logTO = new List<MvcHtmlString>();
            foreach (var log in Logs)
            {
                logTO.Add(new MvcHtmlString(log));
            }

            return logTO;
        }
    }
}