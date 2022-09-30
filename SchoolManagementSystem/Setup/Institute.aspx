<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Institute.aspx.cs" Inherits="SchoolManagementSystem.Setup.Institute" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Institute Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Institute Name</label>
                                <asp:TextBox ID="txtInstitute" runat="server" placeholder="Institute Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">EIIN/RegistrationNo</label>
                                <asp:TextBox ID="txtEIINRegiNo" runat="server" placeholder="Enter EIIN/RegistrationNo" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Email Address</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Phone Number</label>
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Fax</label>
                                <asp:TextBox ID="txtFax" runat="server" placeholder="Fax Number" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Institute Type</label>
                                <asp:DropDownList ID="ddlInstituteType" runat="server">
                                    <asp:ListItem>Primary</asp:ListItem>
                                    <asp:ListItem>High School</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Institute Logo</label>
                                <asp:FileUpload ID="fuInstituteLogo" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-md-6">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="form-control btn-primary" OnClick="btnSave_Click" />
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="form-control btn-danger" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-header ">
                <h3 class="card-title text-center">Institute</h3>
            </div>
            <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateInstituteId" runat="server" />
                                <asp:GridView ID="gvInstitute" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" Width="100%" OnRowCommand="gvInstitute_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="EIIN_RegistrationNo" HeaderText="EIIN/ Registration No" />
                                        <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="InstituteType" HeaderText="Institute Type" />

                                         <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnInstituteId" runat="server" Value='<%# Eval("InstituteId") %>' />
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
</asp:Content>
