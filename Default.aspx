<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<%@ MasterType VirtualPath="Mobile.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="reminder-list">
        <div class="content-primary">
            <asp:Literal runat="server" ID="lit_reminders"></asp:Literal>
        </div>
    </section>
</asp:Content>

