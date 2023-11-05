<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frm_ViewStudent.aspx.cs" Inherits="StudentFeeWebPortal_Task.Views.frm_ViewStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Student 

    </title>
    <style>
        .test1 {
            /*width: 100%;*/
            overflow-x: auto;
            white-space: nowrap;
        }

        .test {
            width: 100%;
            /*height:250px;*/
            overflow-x: auto;
            white-space: nowrap;
        }

        table.beta {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        .beta td, .beta th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        .hiddencol {
            display: none;
        }

        #loading {
            position: fixed;
            top: 0px;
            right: 0px;
            width: 100%;
            height: 100%;
            background-color: #666;
            background-image: url('../images-login/loading.gif');
            background-repeat: no-repeat;
            background-position: center;
            background-size: 200px;
            z-index: 10000000;
            opacity: 0.8;
            filter: alpha(opacity=40);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inner_page" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <!-- Form Elements -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label ID="Label15" runat="server" Text="View Student" Font-Bold="True" Font-Size="18px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="Select Class" Font-Bold="True" Font-Size="15px"></asp:Label>

                                        <asp:DropDownList ID="ddl_Class" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>

                                        &nbsp;
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Enter Name" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_Name" runat="server" class="form-control" placeholder="Please Enter Name" Enabled="true" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Father Name" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_FName" runat="server" class="form-control" placeholder="Please Enter Contact No." Enabled="true" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Father CNIC" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_CNIC" runat="server" class="form-control" placeholder="Please Enter CNIC" Enabled="true" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-3" style="float: right;">
                                        <div class="form-group">
                                            <asp:Button ID="Searchbtn" runat="server" Text="Search" class="btn btn-primary btn-lg" Style="margin-left: 9px; margin-bottom: 10px;" OnClick="Searchbtn_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row test1 test beta">
                                <div class="col-md-12">

                                    <asp:GridView ID="dgvReport" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="3"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                        ShowHeaderWhenEmpty="True"
                                        BorderWidth="1px" CssClass="style4"
                                        OnRowEditing="dgvReport_RowEditing" 
                                        OnRowDeleting="dgvReport_RowDeleting"                                    
                                        DataKeyNames="StudentID"
                                        >
                                        <RowStyle ForeColor="#000066" />
                                        <Columns>
                                            <asp:BoundField DataField="StudentID" HeaderText="ID" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="FatherName" HeaderText="FatherName" />
                                            <asp:BoundField DataField="FatherCNIC" HeaderText="Father CNIC" />
                                            <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                            <asp:BoundField DataField="RollNo" HeaderText="Roll No"/>
                                            <asp:BoundField DataField="ClassName" HeaderText="Class ID"/>
                                            <asp:BoundField DataField="Fee" HeaderText="Fee"/>
                                            <asp:BoundField DataField="ResidenceAddress" HeaderText="Residence Address"/>
                                            <asp:BoundField DataField="Gender" HeaderText="Gender"/>

                                                
                                            <asp:ButtonField  CommandName="Edit" ShowHeader="True" ButtonType="Image" ImageUrl="~/Pictures/Edit.png" HeaderText="Edit." />
                                            <%--<asp:ButtonField  CommandName="Delete" ShowHeader="True" ButtonType="Image" ImageUrl="~/Pictures/Delete.png" HeaderText="Delete." />--%>

                                            <%--<asp:ButtonField CommandName="Delete" ShowHeader="True" ButtonType="Button" HeaderText='<i class="bi bi-trash"></i>' ControlStyle-CssClass="btn btn-primary" />--%>

                                             <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                                           <%-- <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />--%>
                                           
  

                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle HorizontalAlign="center"></RowStyle>
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">

        <ProgressTemplate>
            <div id="loading">
                <%--<asp:Image runat="server" ImageUrl="../images-login/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="width:30em; height:18em;"  />--%>
                <div>
                    <h7>loading...</h7>
                </div>

            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
