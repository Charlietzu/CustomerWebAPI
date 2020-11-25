using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWebAPI.Util
{
    public class Authentication
    {
        public static string TOKEN = "123uiy706059hgj";
        public static string AUTH_FAIL = "Authentication failed, the token is invalid.";
        IHttpContextAccessor _contextAcessor;

        public Authentication(IHttpContextAccessor context)
        {
            _contextAcessor = context;
        }

        public void Auth()
        {
            try
            {
                string tokenReceived = _contextAcessor.HttpContext.Request.Headers["Token"].ToString();
                if(!String.Equals(TOKEN, tokenReceived))
                {
                    throw new Exception(AUTH_FAIL);
                }
            }catch(Exception e)
            {
                throw new Exception(AUTH_FAIL);
            }
        }
    }
}
