using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml;

namespace ApiDemo.WebService.Auth
{
    public delegate void WebServiceAuthenticationEventHandler(Object sender, WebServiceAuthenticationEvent e);

    /// <summary>
    /// 中间件，负责拦截请求
    /// </summary>
    public sealed class WebServiceAuthenticationModule : IHttpModule
    {
        private WebServiceAuthenticationEventHandler
                       _eventHandler = null;

        public event WebServiceAuthenticationEventHandler Authenticate
        {
            add { _eventHandler += value; }
            remove { _eventHandler -= value; }
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.AuthenticateRequest += new EventHandler(this.OnEnter);
                       
        }

        private void OnAuthenticate(WebServiceAuthenticationEvent e)
        {
            if (_eventHandler == null)
                return;

            _eventHandler(this, e);
            if (e.User != null)
                e.Context.User = e.Principal;
        }

        public string ModuleName
        {
            get { return "WebServiceAuthentication"; }
        }

        private void OnEnter(Object source, EventArgs eventArgs)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            Stream HttpStream = context.Request.InputStream;

            // Save the current position of stream.
            long posStream = HttpStream.Position;

            // If the request contains an HTTP_SOAPACTION 
            // header, look at this message.
            if (context.Request.ServerVariables["HTTP_SOAPACTION"] == null)
                          
                return;

            // Load the body of the HTTP message
            // into an XML document.
            XmlDocument dom = new XmlDocument();
            string soapUser;
            string soapPassword;

            try
            {
                dom.Load(HttpStream);

                // Reset the stream position.
                HttpStream.Position = posStream;

                // Bind to the Authentication header.
                soapUser =
                    dom.GetElementsByTagName("User").Item(0).InnerText;
                soapPassword =
                    dom.GetElementsByTagName("Password").Item(0).InnerText;
            }
            catch (Exception e)
            {
                // Reset the position of stream.
                HttpStream.Position = posStream;

                // Throw a SOAP exception.
                XmlQualifiedName name = new
                             XmlQualifiedName("Load");
                SoapException soapException = new SoapException(
                          "Unable to read SOAP request", name, e);
                throw soapException;
            }

            // Raise the custom global.asax event.
            OnAuthenticate(new WebServiceAuthenticationEvent
                         (context, soapUser, soapPassword));
            return;
        }
    }
}