using System;
using System.Web.UI.WebControls;

public partial class Mobile : System.Web.UI.MasterPage
{
    public HyperLink LeftButton
    {
        get { return hl_left_button; }
        set { hl_left_button = value; }
    }

    public HyperLink RightButton
    {
        get { return hl_right_button; }
        set { hl_right_button = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var listClass = new ListClass();
        var list = listClass.GetList();
        lit_menu.Text = "<ul data-role=\"listview\" data-filter=\"true\" data-filter-placeholder=\"Search\">";

        lit_menu.Text += "<li data-role=\"list-divider\">Categories</li>";
        lit_menu.Text += "<li><a href=\"Default.aspx\">All</a></li>";
        foreach (var item in list)
        {
            lit_menu.Text += string.Format("<li><a href=\"List.aspx?id={0}\">{1}</a></li>", item.Id, item.Title);
        }

        lit_menu.Text += "</ul>";
    }
}
