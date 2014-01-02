using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HttpModuleDemo
{
    public class CustomDemoModule: IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpModuleDemoSection section = (HttpModuleDemoSection)ConfigurationManager.GetSection("HttpModuleDemoGroup/HttpModuleDemo");

            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write(string.Format("<h1><font color=green>" +
                     "HelloWorldModule: {0}" +
                     "</font></h1><hr>", section.EndText.Text.ToString()));
            }
            if (fileExtension.Equals(".demoHttpHandler"))
            {
                
                context.Response.Write("Whoo hoo! The end request of your http module got triggered!    ");

            }
        }

        void context_BeginRequest(object sender, EventArgs e)
        {

            HttpModuleDemoSection section = (HttpModuleDemoSection)ConfigurationManager.GetSection("HttpModuleDemoGroup/HttpModuleDemo");

            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write(string.Format("<h1><font color=green>" +
                    "HelloWorldModule: {0}" +
                    "</font></h1><hr>", section.BeginText.Text.ToString()));
            }
            if (fileExtension.Equals(".demoHttpHandler"))
            {
                context.Response.Write("Whoo hoo! The begin request of your http module got triggered!     ");
                
            }
        }
    }
}