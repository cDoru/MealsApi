using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MealsApi.Utils.Upload;

namespace MealsApi.App_Start
{
    public class FormatersConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
        }
    }
}