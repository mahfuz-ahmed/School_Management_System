<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Shift.aspx.cs" Inherits="SchoolManagementSystem.Setup.Shift" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ConfirmationMsg() {
            return confirm("Are u sure to Delete");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Designation Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Shift Name</label>
                                <asp:TextBox ID="txtShift" runat="server" placeholder="Enter Shift" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>

                        </div>
                    </div>


                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Shift List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateDesgId" runat="server" />
                                <asp:GridView ID="gvShift" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvShift_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Shift Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShift" runat="server" Text='<%# Eval("ShiftName") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnShiftId" runat="server" Value='<%# Eval("ShiftId") %>' />
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
