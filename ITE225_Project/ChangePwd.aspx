<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 243px;
        }
        .auto-style3 {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>เปลี่ยนรหัสผ่าน</h2>
    <table class="formContent">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="txtUser">ชื่อผู้ใช้งาน : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="txtUser" placeholder="กรุณากรอกชื่อผู้ใช้" runat="server" AutoCompleteType="Disabled" MaxLength="15" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <label for="txtOldPwd">รหัสผ่านเดิม : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="txtOldPwd" placeholder="กรุณากรอกรหัสผ่านเดิม" runat="server" AutoCompleteType="Disabled" MaxLength="15" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="txtNewPwd">รหัสผ่านใหม่ : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="txtNewPwd" placeholder="กรุณากรอกรหัสผ่านใหม่" runat="server" AutoCompleteType="Disabled" MaxLength="15" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="txtConfirmNewPwd">ยืนยันรหัสผ่านใหม่ : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="txtConfirmNewPwd" placeholder="กรุณายืนยันรหัสผ่าน" runat="server" AutoCompleteType="Disabled" MaxLength="15" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button CssClass="btn btn-primary" ID="btnEditPwd" runat="server" Text="เปลี่ยนรหัสผ่าน" OnClick="btnEditPwd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

