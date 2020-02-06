using Services.Helper;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class ForeignTcConfirmationController : ApiController
    {
        LogFile logFile = new LogFile("ForeignTcServiceLogs");
        // GET: api/TcConfirmation
        public string Get()
        {
            string message = "If you want Foreign Tc Confirmation, consider the following data types; \n TCKN:long | FirstName:string | LastName:string | BirthDay:int (two characters) | BirthMonth:int (two characters) | BirthYear:int (four characters)";
            return message;
        }

        // POST: api/TcConfirmation
        public bool Post([FromBody]ForeignTC value)
        {
            bool result = false;
            try
            {
                if (value != null && value.TCKN.ToString().Length == 11 && !string.IsNullOrEmpty(value.FirstName) && !string.IsNullOrEmpty(value.LastName) && value.BirthDay.ToString().Length==2 && value.BirthMonth.ToString().Length==2 && value.BirthYear.ToString().Length == 4)
                {
                    ForeignTcConfirmationService.KPSPublicYabanciDogrulaSoapClient confirmation = new ForeignTcConfirmationService.KPSPublicYabanciDogrulaSoapClient();
                    result = confirmation.YabanciKimlikNoDogrula(value.TCKN, value.FirstName, value.LastName, value.BirthDay, value.BirthMonth, value.BirthYear);
                }
                else
                {
                    logFile.Message = "Hata! Bilgiler hatalı veya eksik!";
                }
            }
            catch (Exception e)
            {
                logFile.Message = e.Message;
                throw;
            }
            return result;
        }

    }
}
