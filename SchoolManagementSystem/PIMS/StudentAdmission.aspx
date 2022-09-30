<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BlankMaster.Master" AutoEventWireup="true" CodeBehind="StudentAdmission.aspx.cs" Inherits="SchoolManagementSystem.PIMS.StudentAdmission" %>
<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:HiddenField id="hdnRegsl" runat="server"></asp:HiddenField>
   <asp:HiddenField id="hdnStuid" runat="server"></asp:HiddenField>

    <div class="container">
            <h3 class="text-center mt-3">Student Admission</h3>
            <uc1:ResponseMessage runat="server" ID="rmMsg" />
            <div class="row">
                <div class="col-md-4 mt-3">
                    <label class="form-label">Student Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Shift</label>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem>Morning</asp:ListItem>
                        <asp:ListItem>Day</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="col-md-4 mt-3">
                    <label class="form-label">Class Name</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Session Year</label>
                     <asp:DropDownList ID="ddlSession" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Student Registration No</label>
                    <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-md-4 mt-3">
                    <label class="form-label">Admission Date</label>
                    <asp:TextBox ID="txtDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Roll No</label>
                    <asp:TextBox ID="txtRoll" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
               
               
                <div class="col-md-4 mt-3">
                    <label>&nbsp;</label>
                    <asp:Button ID="AddBtn" CssClass="btn btn-primary form-control" runat="server" Text="Save" OnClick="AddBtn_Click"  />
                </div>
            </div>
        </div>
</asp:Content>
