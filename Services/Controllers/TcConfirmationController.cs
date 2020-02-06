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
    public class TcConfirmationController : ApiController
    {
        LogFile logFile = new LogFile("TcConfirmationServiceLogs");
        // GET: api/TcConfirmation
        public string Get()
        {
            string message = "If you want Tc Confirmation, consider the following data types; \n TCKN:long | FirstName:string | LastName:string | BirthYear:int";
            return message;
        }

        // POST: api/TcConfirmation
        public bool Post([FromBody]TC value)
        {
            bool result = false;
            try
            {
                if (value!=null && value.TCKN.ToString().Length==11 && !string.IsNullOrEmpty(value.FirstName) && !string.IsNullOrEmpty(value.LastName) && value.BirthYear.ToString().Length==4)
                {
                    TcConfirmationService.KPSPublicSoapClient confirmation = new TcConfirmationService.KPSPublicSoapClient();
                    result = confirmation.TCKimlikNoDogrula(value.TCKN, value.FirstName.Trim().ToUpper(), value.LastName.Trim().ToUpper(), value.BirthYear);
                }
                else
                {
                    logFile.Message="Hata! Bilgiler hatalı veya eksik!";
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
