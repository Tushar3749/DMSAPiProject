using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Utility.Library
{
    public class DateUtility
    {
        public static Nullable<DateTime> removeDateDefault(Nullable<DateTime> date)
        {
            try
            {
                if (date == null) return null;
                if (date.GetValueOrDefault().ToString("ddMMyyyy") == "01011900") return null;
                return date;
            }
            catch { return null; }
        } 
        
        public static string removeDateDefault(string Date)
        {
            try
            {
                if (Date != null && Date == "01/01/1900") return "";
                return Date;
            }
            catch { return ""; }
        }

        public static Boolean isDateNullOrDefault(Nullable<DateTime> date)
        {
            try
            {
                if (date == null) return true;
                if (date.GetValueOrDefault().ToString("ddMMyyyy") == "01011900") return true;
                return false;
            }
            catch { return false; }
        }


        public static string getAppointmentTime(string AppointmentTime)
        {
            try
            {
                if (string.IsNullOrEmpty(AppointmentTime)) return "";
                int len = AppointmentTime.Length;
                AppointmentTime = AppointmentTime.Trim();

                if (len == 0) AppointmentTime = "000000";
                else if (len == 1) AppointmentTime = "00000" + AppointmentTime;
                else if (len == 2) AppointmentTime = "0000" + AppointmentTime;
                else if (len == 3) AppointmentTime = "000" + AppointmentTime;
                else if (len == 4) AppointmentTime = "00" + AppointmentTime;
                else if (len == 5) AppointmentTime = "0" + AppointmentTime;

                int hours = int.Parse(AppointmentTime.Substring(0, 2));
                int mins = int.Parse(AppointmentTime.Substring(2, 2));
                //int seconds = int.Parse(AppointmentTime.Substring(5, 2));

                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, mins, 0).ToString("hh:mm tt");
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
