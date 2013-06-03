using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : Page
{
    private readonly ReminderClass _reminderClass = new ReminderClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonHelper.SetBackButton(Master.LeftButton);
        ButtonHelper.HideButton(Master.RightButton);

        btn_back.Attributes["data-role"] = "button";
        btn_back.Attributes["data-icon"] = "back";
        btn_back.Attributes["data-iconpos"] = "left";

        btn_update.Attributes["data-role"] = "button";
        btn_update.Attributes["data-icon"] = "update";
        btn_update.Attributes["data-iconpos"] = "left";

        if (Page.IsPostBack)
            return;

        GetReminderDetails();
        SetCategories();
    }

    private void SetCategories()
    {
        var listClass = new ListClass();
        var list = listClass.GetList();

        ddl_categories.DataSource = list;
        ddl_categories.DataTextField = "Title";
        ddl_categories.DataValueField = "Id";
        ddl_categories.DataBind();

        //ddl_categories.Items.Insert(0, new ListItem("- Select -", "-1"));
    }
    private void GetReminderDetails()
    {
        int id;

        if (!Int32.TryParse(Request.QueryString["id"], out id))
            Response.Redirect("~/Default.aspx");

        var reminderDetails = _reminderClass.GetReminderById(id);

        if (reminderDetails == null)
            Response.Redirect("~/Default.aspx");

        //hl_edit.NavigateUrl = string.Format("~/Edit.aspx?id={0}", id);
        if (reminderDetails == null) return;
        txt_title.Text = reminderDetails.Title;
        txt_date.Text = reminderDetails.Date == null ? "-" : ((DateTime)reminderDetails.Date).ToString(@"yyyy\/MM\/dd");
        txt_notes.Text = reminderDetails.Notes;
        ddl_categories.SelectedValue = reminderDetails.ListId.ToString();
        rbl_priority.SelectedValue = reminderDetails.Priority;
        cb_active.Checked = reminderDetails.IsActive != null && !((bool)reminderDetails.IsActive);
    }


    protected void Button_Click(object sender, EventArgs e)
    {
        if (!(sender is Button))
            return;

        var button = sender as Button;

        switch (button.CommandName.ToLower())
        {
            case "update":
                if (Page.IsValid)
                {
                    var reminder = new _514_Reminder
                    {
                        Id =  Convert.ToInt32(Request.QueryString["id"]),
                        Title = txt_title.Text,
                        Notes = txt_notes.Text,
                        Date = GetDateTime(txt_date.Text),
                        IsActive = cb_active.Checked,
                        ListId = Convert.ToInt32(ddl_categories.SelectedValue),
                        Priority = rbl_priority.SelectedValue
                    };

                    _reminderClass.Update(reminder);

                    Response.Redirect("~/Default.aspx");
                }
                break;

            case "back":
               Response.Redirect(string.Format("~/View.aspx?id={0}", Request.QueryString["id"]));
                break;
        }
    }

    private static DateTime? GetDateTime(string val)
    {
        DateTime dateTime;

        if (DateTime.TryParse(val, out dateTime))
            return dateTime;

        return null;
    }
}