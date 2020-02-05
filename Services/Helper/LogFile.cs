using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Services.Helper
{
    public class LogFile
    {
        public LogFile(string pathName)
        {
            PathName = pathName;
            Date = DateTime.Now;
        }
        private string _message;
        public string Message { get { return _message; } set { _message = value; ErrorLog(_message); } }
        private DateTime Date { get; set; }
        public string PathName { get; set; }

        public void ErrorLog(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + PathName + ".txt", true);
                sw.WriteLine(Date.ToString() + " :" + message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}