using System;
using System.Web.UI.WebControls;

public partial class View : System.Web.UI.Page
{
    private readonly ReminderClass _reminderClass = new ReminderClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        ButtonHelper.SetBackButton(Master.LeftButton,"~/Default.aspx");
        Master.RightButton.CssClass += " mark-complete";

        hl_edit.Attributes["data-role"] = "button";
        hl_edit.Attributes["data-icon"] = "edit";
        hl_edit.Attributes["data-iconpos"] = "left";
        hl_edit.Attributes["data-ajax"] = "false";

        hl_delete.Attributes["data-role"] = "button";
        hl_delete.Attributes["data-iconpos"] = "left";
        hl_delete.Attributes["data-icon"] = "delete";
        hl_delete.Attributes["data-rel"] = "popup";

        hl_delete_cancel.Attributes["data-role"] = "button";
        hl_delete_cancel.Attributes["data-inline"] = "true";
        hl_delete_cancel.Attributes["data-rel"] = "back";
        hl_delete_cancel.Attributes["data-theme"] = "c";

        btn_delete_confirm.Attributes["data-role"] = "button";
        btn_delete_confirm.Attributes["data-inline"] = "true";
        btn_delete_confirm.Attributes["data-rel"] = "back";
        btn_delete_confirm.Attributes["data-theme"] = "b";

        if (Page.IsPostBack)
            return;

        GetReminderDetails();
    }

    private void GetReminderDetails()
    {
        int id;

        if (!Int32.TryParse(Request.QueryString["id"], out id))
            Response.Redirect("~/Default.aspx");
        var reminderDetails = _reminderClass.GetReminderById(id);

        if (reminderDetails == null)
            Response.Redirect("~/Default.aspx");

        hl_edit.NavigateUrl = string.Format("~/Edit.aspx?id={0}", id);
        lbl_title.Text = reminderDetails.Title;
        lbl_date.Text = reminderDetails.Date == null ? "-" : ((DateTime)reminderDetails.Date).ToString(@"yyyy\/MM\/dd");
        lbl_notes.Text = reminderDetails.Notes;
        lbl_categories.Text = reminderDetails._514_List.Title;
        lbl_priority.Text = reminderDetails.Priority;
        lbl_active.Text = reminderDetails.IsActive == null ? "Yes" : ((bool)reminderDetails.IsActive) ? "No" : "Yes";

        //Set right button
        if (reminderDetails.IsActive != null && ((bool) reminderDetails.IsActive))
        {
            Master.RightButton.Attributes["data-icon"] = "check";
            Master.RightButton.Text = "Mark as Complete";
        }
        else
        {
            Master.RightButton.Attributes["data-icon"] = "delete";
            Master.RightButton.Text = "Mark as Not Complete";
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        if (!(sender is Button))
            return;

        var button = sender as Button;

        switch (button.CommandName.ToLower())
        {
            case "delete":
                var id = Convert.ToInt32(Request.QueryString["id"]);

                _reminderClass.DeleteReminderById(id);

                Response.Redirect("~/Default.aspx");

                break;
        }
    }
}