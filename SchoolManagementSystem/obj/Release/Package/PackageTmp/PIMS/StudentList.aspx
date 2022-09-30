<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="SchoolManagementSystem.PIMS.StudentList" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Student List</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">

                        <div class="col-md-4">
                            <label class="form-label">Student Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                               <br />
                                <asp:Button ID="btnSearch" CssClass="btn btn-danger mt-2" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                                <asp:GridView ID="gvStudentProfile" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvStudentProfile_RowCommand" OnRowDataBound="gvStudentProfile_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>Admission Class</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnAdmissionId" runat="server" Value='<%# Eval("AdmissionId") %>' />
                                            <asp:Label ID="lblClass" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                                <br />
                                                <asp:LinkButton ID="lbAdCanel" runat="server" CommandName="adcancel" CommandArgument="<%# Container.DataItemIndex %>" >Admission Cancel</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="admission" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>
</asp:Content>
