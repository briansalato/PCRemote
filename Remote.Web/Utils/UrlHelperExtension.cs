using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Remote.Web.Utils
{
    public static class UrlHelperExtension
    {
        #region -account
        public static string Home(this UrlHelper helper)
        {
            return helper.Dashboard();
        }

        public static string Dashboard(this UrlHelper helper)
        {
            return helper.Action("Dashboard", "Home");
        }
        #endregion

        #region -programs
        public static string Program_Show(this UrlHelper helper, int programId)
        {
            return helper.Action("Show", "Program", new { id = programId });
        }
        public static string Program_Create(this UrlHelper helper)
        {
            return helper.Action("Create", "Program");
        }
        #endregion

        #region -content
        /// <summary>
        /// Will load the stylesheet with the given name for the current theme
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string StyleSheet(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/stylesheets/{0}", fileName));
        }

        /// <summary>
        /// Will load the script file with the given name for the current theme
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Script(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/scripts/{0}", fileName));
        }

        /// <summary>
        /// Will load the image with the given name for the current theme
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Image(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/images/{0}", fileName));
        }

        /// <summary>
        /// Will load the file with the given name from the external folder
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string External(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Content/external/{0}", fileName));
        }
        #endregion
    }
}