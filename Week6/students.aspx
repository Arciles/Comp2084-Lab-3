<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="Week6.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>
    <a href="student-details.aspx">Add a new student</a>
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" DataKeyNames="StudentID" OnRowDeleting="grdStudents_RowDeleting">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First-Middle Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Data" DataFormatString="{0:D}" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/student-details.aspx" DataNavigateUrlFields="StudentID" 
                DataNavigateUrlFormatString="~/student-details.aspx?StudentID={0}" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="confirmation" />
        </Columns>
    </asp:GridView>
</asp:Content>
