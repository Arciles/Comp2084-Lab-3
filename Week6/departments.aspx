<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="Week6.departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>
    <a href="department-details.aspx">Add a Department</a>
    <asp:gridview ID="grdDepartments" runat="server" CssClass="table table-striped" autogeneratecolumns="false">
        <Columns>
            <asp:BoundField dataField="DepartmentID" HeaderText="ID" />
            <asp:BoundField dataField="Name" HeaderText="Department Name" />
            <asp:BoundField dataField="Budget" HeaderText="Budget" DataFormatString="{0:c}" />
        </Columns>
    </asp:gridview>
</asp:Content>
