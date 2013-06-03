<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<%@ MasterType VirtualPath="Mobile.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul data-role="listview" data-inset="true">
        <li data-role="fieldcontain">
            <asp:Label ID="Label6" runat="server" Text="Completed" CssClass="form_label" AssociatedControlID="cb_active"></asp:Label>
            <asp:CheckBox runat="server" ID="cb_active" Checked="True" />
        </li>
        <li data-role="fieldcontain">
            <asp:Label ID="Label1" runat="server" Text="Title" CssClass="form_label" AssociatedControlID="txt_title"></asp:Label>
            <asp:TextBox runat="server" ID="txt_title"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" CssClass="error_message" ID="rfv_title" ControlToValidate="txt_title" Display="Dynamic" ErrorMessage="* Error: Title must not be empty."></asp:RequiredFieldValidator>
        </li>
        <li data-role="fieldcontain">
            <asp:Label ID="Label2" runat="server" Text="Date" CssClass="form_label" AssociatedControlID="txt_date"></asp:Label>
            <asp:TextBox runat="server" ID="txt_date"></asp:TextBox>
            <ajax:CalendarExtender ID="ce_date" runat="server" TargetControlID="txt_date"  Format="yyyy/MM/dd"/>
            <asp:RequiredFieldValidator runat="server" CssClass="error_message" ID="rfv_date" ControlToValidate="txt_date" Display="Dynamic" ErrorMessage="* Error: Date must not be empty."></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ID="cmp_date" Type="Date" CssClass="error_message" ControlToValidate="txt_date" Operator="DataTypeCheck" Display="Dynamic" ErrorMessage="* Error: Date is incorrect."></asp:CompareValidator>
        </li>
        <li data-role="fieldcontain">
            <asp:Label ID="Label3" runat="server" Text="Notes" CssClass="form_label" AssociatedControlID="txt_notes"></asp:Label>
            <asp:TextBox runat="server" ID="txt_notes" TextMode="MultiLine" Height="200px"></asp:TextBox>
        </li>
        <li data-role="fieldcontain">
            <asp:Label ID="Label4" runat="server" Text="Categories" CssClass="form_label" AssociatedControlID="ddl_categories"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_categories" />
            <%--<asp:RequiredFieldValidator runat="server" CssClass="error_message" ID="rfv_categories" ControlToValidate="ddl_categories" InitialValue="-1" Display="Dynamic" ErrorMessage="* Error: Please select a category."></asp:RequiredFieldValidator>--%>
        </li>
        <li data-role="fieldcontain">
            <asp:Label ID="Label5" runat="server" Text="Priority" CssClass="form_label" AssociatedControlID="rbl_priority"></asp:Label>
            <asp:RadioButtonList runat="server" ID="rbl_priority">
                <Items>
                    <asp:ListItem Text="High" Value="High"></asp:ListItem>
                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                    <asp:ListItem Text="Low" Value="Low" Selected="True"></asp:ListItem>
                </Items>
            </asp:RadioButtonList>
        </li>
        <li class="ui-body ui-body-b">
            <div class="ui-grid-a">
                <div class="ui-block-a">
                    <asp:Button runat="server" CssClass="update_button" CommandName="update" ID="btn_update" Text="Update" CausesValidation="True" OnClick="Button_Click" />
                </div>
                <div class="ui-block-b">
                    <asp:Button runat="server" ID="btn_back" Text="Back" CommandName="back" OnClick="Button_Click" />
                </div>
            </div>
        </li>
    </ul>
</asp:Content>

