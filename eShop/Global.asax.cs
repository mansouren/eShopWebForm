using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Globalization;
using System.Threading;

namespace eShop
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo culture_info = new CultureInfo("fa-IR");
            // to make following line working, please install the Persian Culture Package (http://persianculture.codeplex.com)
            culture_info.DateTimeFormat.Calendar = new PersianCalendar();


            culture_info.DateTimeFormat.AbbreviatedDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            culture_info.DateTimeFormat.ShortestDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            culture_info.DateTimeFormat.DayNames = new string[] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            culture_info.DateTimeFormat.AbbreviatedMonthNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            culture_info.DateTimeFormat.MonthNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            culture_info.DateTimeFormat.AbbreviatedMonthGenitiveNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            culture_info.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;
            culture_info.DateTimeFormat.AMDesignator = "ق.ظ";
            culture_info.DateTimeFormat.PMDesignator = "ب.ظ";
            culture_info.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            culture_info.DateTimeFormat.LongDatePattern = "yyyy/MM/dd";

            Thread.CurrentThread.CurrentCulture = culture_info;
            Thread.CurrentThread.CurrentUICulture = culture_info;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}