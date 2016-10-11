<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="Week6.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Deatails</h1>

    <div class="form-group">
        <label for="txtStudentLastName" class="control-label">Last Name :</label>
        <asp:TextBox ID="txtStudentLastName" runat="server" CssClass="form-control" required />
    </div>
    <div class="form-group">
        <label for="txtStudentFirstAndMidName" class="control-label">First-Mid Name :</label>
        <asp:TextBox ID="txtStudentFirstAndMidName" runat="server" CssClass="form-control" required />
    </div>
    <div class="form-group">
        <label for="txtStudentEnrollmentDate" class="control-label">Enrollment Date :</label>
        <asp:TextBox ID="txtStudentEnrollmentDate" runat="server" CssClass="form-control" type="date" required />
    </div>
    <asp:button id="btnSave" runat="server" cssclass="col-sm-offset-3 btn btn-success" text="Save" onclick="btnSave_Click" />
    <asp:label ID="lblError" runat="server" text="Someting Went wrong Please try again later!" CssClass="label-danger" Visible="false"></asp:label>
</asp:Content>
