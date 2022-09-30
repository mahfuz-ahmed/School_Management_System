<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResponseMessage.ascx.cs" Inherits="RealProjectB1.ResponseMessage" %>
<asp:Panel ID="pSuccess" runat="server" Visible="false">
    <div style="margin:10px auto 10px auto; width:auto;border:solid 0px Green; padding:5px 5px 5px 5px; background-color:darkgreen;color:white;text-align:center; " >
        <asp:Label ID="lSuccess" runat="server" Text="" Font-Bold="True"></asp:Label>
    </div>
</asp:Panel>
<asp:Panel ID="pFailure" runat="server" Visible="false">
    <div style="margin:10px auto 10px auto;width:auto;border:solid 0px Red; padding:5px 5px 5px 5px;background-color:darkred;color:white;text-align:center;">
        <asp:Label ID="lFailure" runat="server" Text="" Font-Bold="True"></asp:Label>
    </div>
</asp:Panel>
