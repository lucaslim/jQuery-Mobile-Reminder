using System;
using System.Linq;
using System.Web.UI;

public partial class Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonHelper.SetMenuButton(Master.LeftButton);
        ButtonHelper.SetAddButton(Master.RightButton);

        if (Page.IsPostBack)
            return;

        GenerateReminderList();
    }

    private void GenerateReminderList()
    {
        var reminderClass = new ReminderClass();
        var reminderList = reminderClass.GetReminders();

        lit_reminders.Text = "<ul data-filter=\"true\" data-filter-placeholder=\"Filter Reminder...\" data-inset=\"true\" data-role=\"listview\">";
        lit_reminders.Text += string.Format("<li data-role\"list-divider\">Current<span class=\"ui-li-count\">{0}</span></li>", reminderList.Count(x => x.IsActive == true));
        foreach (var reminder in reminderList)
        {
            lit_reminders.Text += string.Format("<li><a data-ajax=\"false\" href=\"View.aspx?id={0}\"><h2>{1}</h2><p class=\"ul-li-aside\"><strong>{2}</strong></p></a></li>", reminder.Id, reminder.Title, ((DateTime)reminder.Date).ToString("yyyy-MM-dd"));
        }

        lit_reminders.Text += "<ul>";
    }
}