<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

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
    <h2>แก้ไขข้อมูลส่วนตัว</h2>
    <table class="formContent">
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regUser">ชื่อผู้ใช้งาน : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regUser" placeholder="กรุณากรอกชื่อผู้ใช้" runat="server" AutoCompleteType="Disabled" MaxLength="15" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                <label for="IDNumber">เลขบัตรประชาชน : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regIDNumber" placeholder="กรุณากรอกหมายเลขบัตรประชาชน" runat="server" AutoCompleteType="Disabled" MaxLength="13"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regFirstName">ชื่อจริง : </label></td>
            <td class="auto-style2">
                <asp:TextBox CssClass="form-control" ID="regFirstname" placeholder="กรุณากรอกชื่อจริง" runat="server" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regLastName">นามสกุล : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regLastname" placeholder="กรุณากรอกนามสกุล" runat="server" AutoCompleteType="Disabled" MaxLength="20"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regLastName">ที่อยู่ : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regAddress" placeholder="กรุณากรอกที่อยู่" runat="server" Rows="4" TextMode="MultiLine" style="resize:none"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regTel">เบอร์โทรศัพท์ : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regTel" placeholder="กรุณากรอกเบอร์โทรศัพท์" runat="server" TextMode="Phone" AutoCompleteType="Disabled" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3"><label for="regEmail">E-mail : </label></td>
            <td class="auto-style2"><asp:TextBox CssClass="form-control" ID="regEmail" placeholder="กรุณากรอก E-mail" runat="server" TextMode="Email" AutoCompleteType="Disabled" MaxLength="30"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button CssClass="btn btn-primary" ID="btnEditProfile" runat="server" Text="บันทึกข้อมูล" OnClick="btnEditProfile_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

