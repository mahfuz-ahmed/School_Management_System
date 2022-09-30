<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Site_Post.aspx.cs" Inherits="SchoolManagementSystem.Setup.Site_Post" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Web Site Post </h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Category </label>
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control dropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Sub Category </label>
                                <asp:DropDownList ID="ddlSubCategory" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-md-12">
                            <div class="form-group ">
                                <label class="form-label">Title</label>
                                <asp:TextBox ID="txtTitle" runat="server" placeholder="Enter category" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group ">
                                    <label class="form-label">Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter category" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-12">
                                <div class="form-group ">
                                    <label class="form-label">Short Description</label>

                                    <asp:TextBox ID="txtShortDes" runat="server" placeholder="Enter category" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="form-label">&nbsp;</label>
                                        <asp:FileUpload ID="fuImg" runat="server" />
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group ">
                                            <label class="form-label">&nbsp;</label>
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                                        </div>

                                    </div>
                                </div>


                            </div>

                            <div class="card-header ">
                                <h3 class="card-title text-center">Category List</h3>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group ">
                                            <asp:HiddenField ID="hdnUpdateSubCId" runat="server" />
                                            <asp:GridView ID="gvCategory" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Category" HeaderText="Category" />
                                                    <asp:TemplateField HeaderText="SubCategory">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnCategoryId" runat="server" Value='<%# Eval("CategoryId") %>' />
                                                            <asp:Label ID="lblSubCategory" runat="server" Text='<%# Eval("SubCategory") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnSubCategoryId" runat="server" Value='<%# Eval("SubCategoryId") %>' />
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
