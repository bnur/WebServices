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
        LogFile logFile = new LogFile("ServiceLogs");
        // GET: api/TcConfirmation
        public string Get()
        {
            return "Running..";
        }

        // POST: api/TcConfirmation
        public bool Post([FromBody]TC value)
        {
            bool result = false;
            try
            {
                if (value.TCKN != null && value.FirstName != null && value.LastName != null && value.BirthYear != null)
                {
                    TcConfirmationService.KPSPublicSoapClient confirmation = new TcConfirmationService.KPSPublicSoapClient();
                    result = confirmation.TCKimlikNoDogrula(value.TCKN, value.FirstName.Trim().ToUpper(), value.LastName.Trim().ToUpper(), value.BirthYear);
                    //logFile.Message = "Başarılı";
                }
                else
                {
                    //logFile.Message="Hata! Bilgilerden bir veya daha fazlası eksik.";
                }
            }
            catch (Exception e)
            {
                //logFile.Message = e.Message;
                throw;
            }
            return result;
        }
        
    }
}
