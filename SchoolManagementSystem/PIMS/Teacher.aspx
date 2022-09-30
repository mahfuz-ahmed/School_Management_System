<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="SchoolManagementSystem.PIMS.Teacher" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Teacher Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label class="form-label">First Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Last Name</label>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Designation</label>
                            <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="form-label">Date Of Birth</label>
                            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control datepicker" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Gender</label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Religion</label>
                            <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Blood Group</label>
                            <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <label class="form-label">Contact Number</label>
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control "></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Nationality</label>
                            <asp:TextBox ID="txtNationality" runat="server" CssClass="form-control "></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">National Id</label>
                            <asp:TextBox ID="txtNID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3 mt-3">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 mt-3">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-md-4">
                            <label class="form-label">Joining Date</label>
                            <asp:TextBox ID="txtJoiningDate" runat="server" CssClass="form-control datepicker" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Teacher Image</label>
                            <asp:FileUpload ID="fuTeacherImage" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="form-control btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    
                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Teacher List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateTeacherId" runat="server" />
                                <asp:GridView ID="gvTeacherProfile" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvTeacherProfile_RowCommand">
                                    <Columns>
                                        <%--<asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />--%>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <%--<asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />--%>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
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
