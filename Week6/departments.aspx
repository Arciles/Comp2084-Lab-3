<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="Week6.departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>
    <a href="department-details.aspx">Add a Department</a>
    <asp:gridview ID="grdDepartments" runat="server" CssClass="table table-striped" autogeneratecolumns="false" DataKeyNames="DepartmentID" OnRowDeleting="grdDepartments_RowDeleting">
        <Columns>
            <asp:BoundField dataField="DepartmentID" HeaderText="ID" />
            <asp:BoundField dataField="Name" HeaderText="Department Name" />
            <asp:BoundField dataField="Budget" HeaderText="Budget" DataFormatString="{0:c}" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="confirmation"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/department-details.aspx" DataNavigateUrlFields="DepartmentID" 
                DataNavigateUrlFormatString="~/department-details.aspx?DepartmentID={0}" />
        </Columns>
    </asp:gridview>
</asp:Content>
