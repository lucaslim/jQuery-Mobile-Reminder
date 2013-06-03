using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ButtonHelper
/// </summary>
public static class ButtonHelper
{
    private static void SetDefaultHeaderButton(HyperLink hyperLink)
    {
        hyperLink.Attributes["data-iconpos"] = "notext";
    }

    public static void SetMenuButton(HyperLink hyperLink)
    {
        SetDefaultHeaderButton(hyperLink);
        hyperLink.Attributes["data-icon"] = "bars";
        hyperLink.Attributes["data-direction"] = "reverse";
        hyperLink.NavigateUrl = "#menu";
    }

    public static void SetAddButton(HyperLink hyperLink)
    {
        SetDefaultHeaderButton(hyperLink);
        hyperLink.Attributes["data-icon"] = "add";
        hyperLink.Attributes["data-ajax"] = "false";
        hyperLink.NavigateUrl = "Add.aspx";
    }

    public static void SetBackButton(HyperLink hyperLink)
    {
        SetDefaultHeaderButton(hyperLink);
        hyperLink.Attributes["data-icon"] = "back";
        hyperLink.Attributes["data-rel"] = "back";
    }

    public static void SetBackButton(HyperLink hyperLink, string url)
    {
        SetDefaultHeaderButton(hyperLink);
        hyperLink.Attributes["data-icon"] = "back";
        hyperLink.NavigateUrl = url;
    }

    public static void HideButton(HyperLink hyperLink)
    {
        hyperLink.Visible = false;
    }
}