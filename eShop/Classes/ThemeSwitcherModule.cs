using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace ThemeSwitcher_CS
{
    public class ThemeSwitcherModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(this.PreRequestHandlerExecute);
        }

        protected void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext current = HttpContext.Current;
            if (current.Handler is Page)
            {
                Page handler = (Page)current.Handler;
                if (handler != null)
                {                    
                    //These 8 lines below handle master pages. Courtesy of Craig G Fraser
                    string sUniqueID = "lbThemeSwitcher";                    
                    foreach (string str in current.Request.Form.AllKeys)
                    {
                        if (str.Contains("lbThemeSwitcher"))
                        {
                            sUniqueID = str;
                            break;
                        }
                    }
                    object theme = current.Request.Form[sUniqueID];
                    if (theme != null)
                    {
                        // this is postback from the page with the theme switcher list
                        // handle the user selection in the theme list
                        if (theme.ToString() == "0")
                        {
                            // user chose "none"
                            handler.Theme = "";
                            // delete the cookie
                            current.Response.Cookies[this.CookieName()].Expires = DateTime.Today.AddDays(-1.0);
                        }
                        else
                        {
                            if (this.ThemeExists(theme.ToString()))
                            {
                                handler.Theme = theme.ToString();
                            }
                            //set a cookie for persistence
                            current.Response.Cookies[this.CookieName()].Value = theme.ToString();
                            current.Response.Cookies[this.CookieName()].Expires = DateTime.Today.AddDays(90.0);
                        }
                    }
                    else
                    {
                        //for other pages with no theme switcher on them
                        HttpCookie cookie = current.Request.Cookies[this.CookieName()];
                        if ((cookie != null) && (cookie.Value != ""))
                        {
                            // if there's a cookie, get the theme from the cookie
                            if (this.ThemeExists(cookie.Value))
                            {
                                handler.Theme = cookie.Value;
                            }
                        }
                        else
                        {
                            // if there's no cookie, select the default theme (if it exists)
                            // the developer should provide a theme with the name "Default"
                            // if this behavior is wanted
                            if (this.ThemeExists("Default"))
                            {
                                handler.Theme = "Default";
                            }
                            string DefaultThemeName = ConfigurationManager.AppSettings["DefaultThemeName"];
                            if (this.ThemeExists(DefaultThemeName))
                            {
                                handler.Theme = DefaultThemeName;
                            }
                        }
                    }
                }
            }
        }

        private string CookieName()
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;
            return (applicationPath.Substring(1, applicationPath.Length - 1) + "_tsTheme");
        }

        private bool ThemeExists(string theme)
        {
            return Directory.Exists(HttpContext.Current.Server.MapPath("~/App_Themes/" + theme));
        }



        #endregion
    }
}
