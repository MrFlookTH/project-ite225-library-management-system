<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ข่าวประชาสัมพันธ์</h2>
    <h3 class="table-head" style="line-height:25px; margin-bottom:10px"><asp:Label ID="LabelTitle" runat="server"></asp:Label></h3>
    <p><asp:Label ID="LabelDesc" runat="server" Style="padding-left:20px; padding-right:20px"></asp:Label></p>

</asp:Content>