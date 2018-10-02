<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPage.master" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <style type="text/css">
        .auto-style5 {
            width: 132px;
            height: 25px;
        }
        .auto-style6 {
            width: 14px;
            height: 25px;
        }
        .auto-style8 {
        height: 55px;
    }
        .auto-style9 {
            height: 25px;
        }
        .auto-style10 {
            height: 44px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content1" Runat="Server">
    <h2>ข้อมูลหนังสือ</h2>
    <table class="book-detail">
        <tr>
            <td rowspan="11" style="padding-right:10px;">
                <asp:Image ID="ImageBook" runat="server"  style="max-width:160px; max-height:180px; border:solid 1px #cbcbcb"/></td>
            <td colspan="3"><h3><asp:Label ID="LabelTitle" runat="server"></asp:Label></h3></td>
        </tr>
        <tr>
            <td colspan="3"><p><asp:Label ID="LabelDesc" runat="server"></asp:Label></p></td>
        </tr>

        <tr>
            <td colspan="3" style="vertical-align:middle" class="auto-style10"><h3>รายละเอียดหนังสือ</h3></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>รหัสหนังสือ</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelBookID" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>ISBN</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelISBN" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>หมวด</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelCategory" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>จำนวนหน้า	</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td class="auto-style9"><asp:Label ID="LabelPage" runat="server"></asp:Label>  หน้า</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>ผู้แต่ง	</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelAuthor" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>สำนักพิมพ์</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelPublisher" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>สถานะ</strong></td>
            <td class="auto-style6"><strong>:</strong></td>
            <td><asp:Label ID="LabelStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style8" style="vertical-align:middle;">
                <asp:Button ID="btnBorrowModal" cssClass="btn btn-success" data-toggle="modal" data-target="#borrow" runat="server" Text="ยืมหนังสือ" OnClientClick="return false" UseSubmitBehavior="True" Visible="False" />
                
                <asp:Button ID="btnReserverData" cssClass="btn btn-primary" data-toggle="modal" data-target="#reserver" runat="server" Text="ข้อมูลผู้จอง" OnClientClick="return false" UseSubmitBehavior="True" Visible="False" />

                <!-- Modal Borrow -->
                <div id="borrow" class="modal fade" role="dialog">
                  <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                      <div class="modal-header">
                        <h4 class="modal-title">ข้อมูลผู้ยืมหนังสือ</h4>
                      </div>
                      <div class="modal-body">
                          <table class="form-modal">
                              <tr>
                                  <td style="text-align:right"><label for="BorrowUser"><strong>ID ผู้ยืม : </strong></label></td>
                                  <td>
                                      <asp:TextBox CssClass="form-control" ID="BorrowUser" runat="server" placeholder="กรุณากรอกชื่อผู้ใช้งาน" MaxLength="15"></asp:TextBox>
                                      
                                  </td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="borrowDate"><strong>รหัสหนังสือ : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowBookID" runat="server" placeholder="BookID" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="borrowDate"><strong>ISBN : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowISBN" runat="server" placeholder="ISBN" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="BorrowDate"><strong>ชื่อหนังสือ : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowBookTitle" runat="server" placeholder="ชื่อหนังสือ" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="BorrowDate"><strong>วันที่ยืม : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowDate" runat="server" placeholder="วันที่ยืม" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="BorrowReturn"><strong>กำหนดส่งคืน : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowReturn" runat="server" placeholder="วันที่คืน" ReadOnly="True"></asp:TextBox></td>
                              </tr>  
                              <tr>
                                  <td style="text-align:right"><label for="BorrowRemark"><strong>หมายเหตุ : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="BorrowRemark" runat="server" placeholder="หมายเหตุ (ถ้ามี)" TextMode="MultiLine" style="resize:none;"></asp:TextBox></td>
                              </tr>                        
                          </table>
                      </div>
                      <div class="modal-footer">
                        <asp:Button CssClass="btn btn-primary" ID="btnBorrowSave" runat="server" Text="บันทึก" OnClick="btnBorrowSave_Click" />
                        <button type="button" class="btn" data-dismiss="modal">ยกเลิก</button>
                      </div>
                    </div>
                  </div>
                </div>

                <asp:Button ID="btnBorrowerData" cssClass="btn btn-primary" data-toggle="modal" data-target="#borrower" runat="server" Text="ข้อมูลผู้ยืม" OnClientClick="return false" UseSubmitBehavior="True" Visible="False" />
                
                    <!-- Modal Borrower -->
                <div id="borrower" class="modal fade" role="dialog">
                  <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                      <div class="modal-header">
                        <h4 class="modal-title">ข้อมูลผู้ยืมหนังสือ</h4>
                      </div>
                      <div class="modal-body">
                          <table class="form-modal">
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerID"><strong>หมายเลขยืม : </strong></label></td>
                                  <td>
                                      <asp:TextBox CssClass="form-control" ID="txtBorrowerID" runat="server" placeholder="หมายเลขยืม" MaxLength="15" ReadOnly="true"></asp:TextBox>           
                                  </td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerName"><strong>ชื่อผู้ยืม : </strong></label></td>
                                  <td>
                                      <asp:TextBox CssClass="form-control" ID="txtBorrowerName" runat="server" placeholder="ชื่อผู้ยืม" MaxLength="15" ReadOnly="true"></asp:TextBox>           
                                  </td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerTitle"><strong>ชื่อหนังสือ : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="txtBorrowerTitle" runat="server" placeholder="ชื่อหนังสือ" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerDate"><strong>วันที่ยืม : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="txtBorrowerDate" runat="server" placeholder="วันที่ยืม" ReadOnly="True"></asp:TextBox></td>
                              </tr>
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerReturn"><strong>กำหนดส่งคืน : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="txtBorrowerReturn" runat="server" placeholder="วันที่คืน" ReadOnly="True"></asp:TextBox></td>
                              </tr>  
                              <tr>
                                  <td style="text-align:right"><label for="txtBorrowerRemark"><strong>หมายเหตุ : </strong></label></td>
                                  <td><asp:TextBox CssClass="form-control" ID="txtBorrowerRemark" runat="server" placeholder="หมายเหตุ (ถ้ามี)" TextMode="MultiLine" ReadOnly="true" style="resize:none;"></asp:TextBox></td>
                              </tr>                        
                          </table>
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn" data-dismiss="modal">ปิด</button>
                      </div>
                    </div>
                  </div>
                </div>
                

                <asp:Button ID="btnReserveModal" runat="server" Text="จองหนังสือ" class="btn btn-danger" Visible="False"  data-toggle="modal" data-target="#reserve" OnClientClick="return false" />          
                 &nbsp;<asp:Label ID="Label1" runat="server" Text="&gt;&gt; หากต้องการยืมหนังสือ กรุณาติดต่อบรรณารักษ์ &lt;&lt;" Font-Bold="True" Visible="False"></asp:Label>

                <!-- Modal Reserve -->
                <div id="reserve" class="modal fade" role="dialog">
                  <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                      <div class="modal-header">
                        <h4 class="modal-title">กรุณายืนยันข้อมูล</h4>
                      </div>
                      <div class="modal-body">
                          <h4>ต้องการจองหนังสือเล่มนี้ใช่หรือไม่?</h4>
                      </div>
                      <div class="modal-footer">
                          <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="บันทึก" OnClick="btnReserveModal_Click" />
                        <button type="button" class="btn" data-dismiss="modal">ปิด</button>
                      </div>
                    </div>
                  </div>
                </div>

            </td>
        </tr>
    </table>
    <h2>หนังสือที่เกี่ยวข้อง</h2>
    <div class="book-list">
            <asp:Repeater ID="RepeaterBookRelated" runat="server">
                <ItemTemplate>
                    <a href="book.aspx?BookID=<%#Eval("BookID") %>" data-toggle="tooltip" data-placement="top" title="<%#Eval("Title") %>"><img src="image/book/<%#Eval("BookID") %>.jpg" width="100" height="130" /></a>
                </ItemTemplate>
            </asp:Repeater>    
    </div>
</asp:Content>

