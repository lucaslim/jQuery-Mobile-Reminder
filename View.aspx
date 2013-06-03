<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

<%@ MasterType VirtualPath="Mobile.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul data-role="listview" data-inset="true">
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Title: " CssClass="form_label"></asp:Label>
            <p><asp:Label ID="lbl_title" runat="server"></asp:Label></p>
        </li>
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Date: " CssClass="form_label"></asp:Label>
            <p><asp:Label ID="lbl_date" runat="server"></asp:Label></p>
        </li>
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Notes: " CssClass="form_label"></asp:Label>
            <p><asp:Label ID="lbl_notes" runat="server"></asp:Label></p>
        </li>
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Categories: " CssClass="form_label"></asp:Label>
            <p><asp:Label ID="lbl_categories" runat="server"></asp:Label></p>
        </li>
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Priority: " CssClass="form_label"></asp:Label> 
            <p><asp:Label ID="lbl_priority" runat="server"></asp:Label></p>
        </li>
        <li data-role="fieldcontain">
            <asp:Label runat="server" Text="Completed: " CssClass="form_label"></asp:Label>
            <p><asp:Label ID="lbl_active" runat="server"></asp:Label></p>
        </li>
        <li>
            <div class="ui-grid-a">
                <div class="ui-block-a">
                    <asp:HyperLink runat="server" ID="hl_edit" Text="Edit" />
                </div>
                <div class="ui-block-b">
                    <asp:HyperLink runat="server" ID="hl_delete" Text="Delete" CssClass="button-red" NavigateUrl="#delete_box"></asp:HyperLink>
                    <div data-role="popup" id="delete_box" data-overlay-theme="a" data-theme="c">
                        <div data-role="header" data-theme="a">
                            <h1>Delete Reminder?</h1>
                        </div>
                        <div data-role="content" data-theme="d">
                            <h3>Are you sure you want to delete this reminder?</h3>
                            <asp:HyperLink runat="server" ID="hl_delete_cancel" Text="Cancel"></asp:HyperLink>
                            <asp:Button runat="server" ID="btn_delete_confirm" Text="Delete" OnClick="Button_Click" CommandName="delete" />
                        </div>
                    </div>
                </div>
            </div>
        </li>
    </ul>
</asp:Content>

