using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonHelper.SetBackButton(Master.LeftButton, "~/Default.aspx");
        ButtonHelper.HideButton(Master.RightButton);

        btn_submit.Attributes["data-icon"] = "check";
        btn_reset.Attributes["data-icon"] = "delete";

        if (Page.IsPostBack)
            return;

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

    protected void Button_Click(object sender, EventArgs e)
    {
        if (!(sender is Button))
            return;

        var button = sender as Button;

        switch (button.CommandName.ToLower())
        {
            case "submit":
                if (Page.IsValid)
                {
                    var reminder = new _514_Reminder
                        {
                            Title = txt_title.Text,
                            Notes = txt_notes.Text,
                            Date = GetDateTime(txt_date.Text),
                            IsActive = true,
                            ListId = Convert.ToInt32(ddl_categories.SelectedValue),
                            Priority = rbl_priority.SelectedValue
                        };

                    var reminderClass = new ReminderClass();

                    reminderClass.Insert(reminder);

                    txt_title.Text = string.Empty;
                    txt_date.Text = string.Empty;
                    txt_notes.Text = string.Empty;
                    ddl_categories.SelectedIndex = 0;
                    rbl_priority.SelectedValue = "Low";

                    lbl_success.Visible = true;
                }
                break;

            case "reset":
                txt_title.Text = string.Empty;
                txt_date.Text = string.Empty;
                txt_notes.Text = string.Empty;
                ddl_categories.SelectedIndex = 0;
                rbl_priority.SelectedValue = "Low";
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