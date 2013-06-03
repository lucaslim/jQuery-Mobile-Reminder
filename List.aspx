<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>
<%@ MasterType VirtualPath="Mobile.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="reminder-list">
        <div class="content-primary">
            <asp:Literal runat="server" ID="lit_reminders"></asp:Literal>
        </div>
    </section>
</asp:Content>

