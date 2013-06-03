using System;
using System.Web.UI;
using System.Linq;

public partial class List : Page
{
    private readonly ReminderClass _reminderClass = new ReminderClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonHelper.SetMenuButton(Master.LeftButton);
        ButtonHelper.SetAddButton(Master.RightButton);

        if (Page.IsPostBack)
            return;

        GenerateReminderList();
    }

    /// <summary>
    /// Generate Reminder List base on Id query string
    /// </summary>
    private void GenerateReminderList()
    {
        int id;

        if (!Int32.TryParse(Request.QueryString["id"], out id))
            Response.Redirect("~/Default.aspx");

        var reminderList = _reminderClass.GetRemindersByListId(id);
        
        //Set listview
        lit_reminders.Text = "<ul data-filter-placeholder=\"Filter Reminder...\" data-filter=\"true\" data-inset=\"true\" data-role=\"listview\">";

        //Add List Header Category
        lit_reminders.Text += string.Format("<li data-role\"list-divider\">{0} <span class=\"ui-li-count\">{1}</span></li>", GetListHeader(), reminderList.Count(x => x.IsActive == true));




        // Add Active Reminders
        foreach (var reminder in reminderList.Where(reminder => reminder.IsActive == true))
            lit_reminders.Text += string.Format("<li>" +
                                                    "<a class=\"details\" data-ajax=\"false\" href=\"View.aspx?id={0}\">" +
                                                        "<h3>{1}</h3>" +
                                                        "<p class=\"ul-li-aside\">" +
                                                            "<strong>{2}</strong>" +
                                                        "</p>" +
                                                    "</a>" +
                                                "</li>", reminder.Id, reminder.Title, ((DateTime)reminder.Date).ToString("yyyy-MM-dd"));

        //Add Completed Category
        lit_reminders.Text += string.Format("<li data-role\"list-divider\">Completed <span class=\"ui-li-count\">{0}</span></li>", reminderList.Count(x => x.IsActive == false));

        //Add Inactive Reminders
        foreach (var reminder in reminderList.Where(reminder => reminder.IsActive == false))
            lit_reminders.Text += string.Format("<li><a data-ajax=\"false\" href=\"View.aspx?id={0}\"><h2>{1}</h2><p class=\"ui-li-aside\"><strong>{2}</strong></p></a></li>", reminder.Id, reminder.Title, ((DateTime)reminder.Date).ToString("yyyy-MM-dd"));

        //Close list view
        lit_reminders.Text += "<ul>";
    }

    /// <summary>
    /// Get List Header
    /// </summary>
    /// <returns></returns>
    private string GetListHeader()
    {
        var id = Convert.ToInt32(Request.QueryString["id"]);

        var listDetails = new ListClass().GetListById(id);

        return listDetails.Title;
    }
}