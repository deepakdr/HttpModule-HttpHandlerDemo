using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpModuleDemo
{
    /*
     * Accessing http://localhost:61356/demo.demoHttpHandler will bascially the process request method
     * Because, this is the "path" that is configured in web.config under handlers
     * This is for all the verbs
     * 
     */
    public class DemoHttpHandler: IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello World - from handler process request, check the file DemoHttpHandler & Web.config entry");
           
        }
    }
}