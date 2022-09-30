<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AuthMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolManagementSystem.dashboard.login" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-box">
  <div class="login-logo">
    <a href="#"><b>KR </b>Model School</a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
      <uc1:ResponseMessage runat="server" id="rmMsg" />
    <div class="card-body login-card-body">
      <p class="login-box-msg">Sign in to start your session</p>

        <div class="input-group mb-3">
           <asp:TextBox ID="txtUsername"  runat="server" CssClass ="form-control" placeholder="Username"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtPassword"  runat="server" CssClass ="form-control" placeholder="Password" TextMode="Password" Text="123"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="icheck-primary">
                <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="form-check-input"/>

              <label for="remember">
                Remember Me
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-4">
              <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click"  />
           
          </div>
          <!-- /.col -->
        </div>
      

    <%--  <div class="social-auth-links text-center mb-3">
        <p>- OR -</p>
        <a href="#" class="btn btn-block btn-primary">
          <i class="fab fa-facebook mr-2"></i> Sign in using Facebook
        </a>
        <a href="#" class="btn btn-block btn-danger">
          <i class="fab fa-google-plus mr-2"></i> Sign in using Google+
        </a>
      </div>--%>
      <!-- /.social-auth-links -->

      <p class="mb-1">
        <a href="forgot-password.html">I forgot my password</a>
      </p>
      <p class="mb-0">
        <a href="register.html" class="text-center">Register a new membership</a>
      </p>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->
</asp:Content>
