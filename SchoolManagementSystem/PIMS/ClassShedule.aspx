<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClassShedule.aspx.cs" Inherits="SchoolManagementSystem.PIMS.ClassShedule" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField id="hdnStuId" runat="server"></asp:HiddenField>
    <uc1:ResponseMessage runat="server" ID="rmmsg" />
    <div class="content-wrapper">
    <div class="container">
        <div class="card card-primary">
            <h3 class="text-center">Class Shedule</h3>
            <uc1:ResponseMessage runat="server" ID="ResponseMessage" />
             <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Shift</label>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <label class="form-label">Class Name</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <label class="form-label">Week Day</label>
                     <asp:DropDownList ID="ddlWeekDay" runat="server" CssClass="form-control" >
                         <asp:ListItem Value="Saturday">Saterday</asp:ListItem>
                         <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                         <asp:ListItem Value="Monday">Monday</asp:ListItem>
                     </asp:DropDownList>
                </div>
               <div class="col-md-3">
                    <label class="form-label">Subject</label>
                    <asp:DropDownList ID="ddlSubject"  runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
               
                <div class="col-md-2">
                    <label class="form-label">Start Time</label>
                    <asp:TextBox ID="txtStartTime" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                </div>
               
               <div class="col-md-2">
                    <label class="form-label">End Time</label>
                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                </div>
                <div class="col-md-2 mt-1">
                    <label>&nbsp;</label>
                    <asp:Button ID="AddBtn" CssClass="btn btn-primary form-control" runat="server" Text="Add" OnClick="AddBtn_Click"  />
                </div>
            </div>

                 <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                                <asp:GridView ID="gvClassShedule" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" Width="100%"  >
                                    <Columns>
                                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="WeekDay" HeaderText="WeekDay" />
                                        <asp:BoundField DataField="Subject" HeaderText="Subject" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                                        
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                 <asp:HiddenField ID="hdnShiftID" runat="server" Value='<%# Eval("ShiftID") %>' />
                                                 <asp:HiddenField ID="hdnClassID" runat="server" Value='<%# Eval("ClassID") %>' />
                                                 <asp:HiddenField ID="hdnSubjectId" runat="server" Value='<%# Eval("SubjectId") %>' />
                                               
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="admission" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-2" ">
                             <asp:Button ID="btnSubmit" CssClass="btn btn-primary form-control" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                        </div>
                     </div>
                </div>
        </div>
        </div>
        </div>
    </div>
</asp:Content>
