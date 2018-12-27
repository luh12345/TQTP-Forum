using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Insolation.Forum.Api.Common.Const
{
    public class DomainConst
    {
        public static string CurrentDomain = string.Format(@"{0}://{1}{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
    }
}