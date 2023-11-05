<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frm_SubmitFee.aspx.cs" Inherits="StudentFeeWebPortal_Task.Views.frm_SubmitFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add New User
    </title>
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
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
                            <asp:Label ID="lbl_StudentID" runat="server" Text="Label" Visible="false"></asp:Label>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="Name" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SName" runat="server" class="form-control" placeholder="Please Enter Name" ReadOnly></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label7" runat="server" Text="Father Name" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SFName" runat="server" class="form-control" placeholder="Please Enter Contact No." ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="CNIC" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SCNIC" runat="server" class="form-control" placeholder="Please Enter Name" ReadOnly></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label8" runat="server" Text="Roll No" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SRollNo" runat="server" class="form-control" placeholder="Please Enter CNIC" ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Class" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SClass" runat="server" class="form-control" placeholder="Please Enter Class" ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" Text="Fee" Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SFee" runat="server" class="form-control" placeholder="Please Enter Class" ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="Fee Sumbit " Font-Bold="True" Font-Size="15px"></asp:Label>
                                        <asp:TextBox ID="txt_SFeeSubmit" runat="server" class="form-control" placeholder="Please Enter Name" TextMode="Number"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" Text="Fee Month" Font-Bold="True" Font-Size="15px"></asp:Label>

                                        <asp:DropDownList ID="ddl_SMonth" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>

                                        &nbsp;
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Button ID="btn_SubmitFee" runat="server" Text="Submit Fee" class="btn btn-success btn-lg" Style="margin-left: 9px; margin-bottom: 0px;" OnClick="btn_SubmitFee_Click" />
                                    </div>
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

