<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department-details.aspx.cs" Inherits="Week6.department_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Details</h1>
    <div class="form-group">
        <label for="txtName" class="col-sm-3 control-label">Name :</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="col-sm-3 form-control" required />
    </div>
    <div class="form-group">
        <label for="txtBudget" class="col-sm-3 control-label">Budget :</label>
        <asp:TextBox ID="txtBudget" runat="server" CssClass="col-sm-3 form-control" type="number" min="0" required />
    </div>
    <asp:Button ID="btnSave" runat="server" CssClass="col-sm-offset-3 btn btn-primary"  Text="Save" OnClick="btnSave_Click"/>
    <asp:label ID="lblError" runat="server" text="Someting Went wrong Please try again later!" CssClass="label-danger" Visible="false"></asp:label>
 </asp:Content>
