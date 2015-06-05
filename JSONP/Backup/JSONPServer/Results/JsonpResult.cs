using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;

namespace JSONPClient.Results
{
    //public class JsonpResult : ActionResult
    //{
    //    public string CallbackFunction { get; set; }
    //    public Encoding ContentEncoding { get; set; }
    //    public string ContentType { get; set; }
    //    public object Data { get; set; }

    //    public JsonpResult(object data) : this(data, null) { }
    //    public JsonpResult(object data, string callbackFunction)
    //    {
    //        Data = data;
    //        CallbackFunction = callbackFunction;
    //    }


    //    public override void ExecuteResult(ControllerContext context)
    //    {
    //        if (context == null) throw new ArgumentNullException("context");

    //        HttpResponseBase response = context.HttpContext.Response;

    //        response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/x-javascript" : ContentType;

    //        if (ContentEncoding != null) response.ContentEncoding = ContentEncoding;

    //        if (Data != null)
    //        {
    //            HttpRequestBase request = context.HttpContext.Request;

    //            var callback = CallbackFunction ?? request.Params["callback"] ?? "callback";

    //            var serializer = new JavaScriptSerializer();
    //            response.Write(string.Format("{0}({1});", callback, serializer.Serialize(Data)));
    //        }
    //    }
    //}

    public class JsonpResult : JsonResult
    {
        object data = null;

        public JsonpResult()
        {
        }

        public JsonpResult(object data)
        {
            this.data = data;
        }

        public override void ExecuteResult(ControllerContext controllerContext)
        {
            if (controllerContext != null)
            {
                var Response = controllerContext.HttpContext.Response;
                var Request = controllerContext.HttpContext.Request;

                string callbackfunction = Request["callback"];
                if (string.IsNullOrEmpty(callbackfunction))
                {
                    throw new Exception("Callback function name must be provided in the request!");
                }
                Response.ContentType = "application/x-javascript";
                if (data != null)
                {
                    var serializer = new JavaScriptSerializer();
                    Response.Write(string.Format("{0}({1});", callbackfunction, serializer.Serialize(data)));
                }
            }
        }
    }
}