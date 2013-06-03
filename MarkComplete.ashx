<%@ WebHandler Language="C#" Class="MarkComplete" %>

using System;
using System.Web;

public class MarkComplete : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        int id;
        if (!Int32.TryParse(HttpContext.Current.Request.QueryString["id"], out id))
            context.Response.Write("{\"success\" : false}");

        bool flag;
        if (!bool.TryParse(HttpContext.Current.Request.QueryString["c"], out flag))
            context.Response.Write("{\"success\" : false}");

        var reminderClass = new ReminderClass();

        if (reminderClass.SetReminderIsActive(id, flag))
        {
            context.Response.Write("{\"success\" : true, \"id\" : " + id + "}");
        }
        else
        {
            context.Response.Write("{\"success\" : false}");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}