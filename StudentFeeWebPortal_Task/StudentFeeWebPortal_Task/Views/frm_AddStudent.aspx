<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frm_AddStudent.aspx.cs" Inherits="StudentFeeWebPortal_Task.Views.frm_AddStudent" %>

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

    <script>
        function validateForm() {
            var nameField = document.getElementById('<%= txt_Name.ClientID %>');
            var fnameField = document.getElementById('<%= txt_FName.ClientID %>');
            var fCNICField = document.getElementById('<%= txt_FCNIC.ClientID %>');
            var contactNoField = document.getElementById('<%= txt_ContactNo.ClientID %>');
            var rollNoField = document.getElementById('<%= txt_RollNo.ClientID %>');
            var feeField = document.getElementById('<%= txt_Fee.ClientID %>');
            var addressField = document.getElementById('<%= txt_Address.ClientID %>');



            if (nameField.value.trim() === "") {
                alert("Name cannot be empty");
                return false;
            }
            else if (fnameField.value.trim() === "") {
                alert("Father name cannot be empty");
                return false;
            }
            else if (fCNICField.value.trim() === "") {
                alert("CNIC cannot be empty");
                return false;
            }
            else if (contactNoField.value.trim() === "") {
                alert("Contact no cannot be empty");
                return false;
            }
            else if (rollNoField.value.trim() === "") {
                alert("Roll no cannot be empty");
                return false;
            }
            else if (feeField.value.trim() === "") {
                alert("Fee amount cannot be empty");
                return false;
            }
            else if (addressField.value.trim() === "") {
                alert("Address cannot be empty");
                return false;
            }
            else if (!this.isValidStringFiled(nameField)) {
                console.log("Invalid name, only alphabets allow ");
            }
            else if (!this.isValidStringFiled(fnameField)) {
                console.log("Invalid username, only alphabets allow ");
            }
            else if (!this.isValidPakistaniCNIC(fCNICField)) {
                console.log("Invalid CNIC no");
            }
            else if (!this.isValidPakistaniContactNumber(contactNoField)) {
                console.log("Invalid contact no");
            }
            else if (!this.isValidRollNumber(rollNoField)) {
                console.log("Invalid roll no");
            }

            return true;
        }

        function isValidStringFiled(username) {
            return /^[A-Za-z]+$/.test(username);
        }

        function isValidPakistaniContactNumber(number) {
            // Regular expression for Pakistani phone number
            var regex = /^(0)(3[0-9])(\d{9})$/;
            return regex.test(number);
        }

        function isValidPakistaniCNIC(cnic) {
            var regex = /^[0-9]{5}-[0-9]{7}-[0-9]$/;
            return regex.test(cnic);
        }

        function isValidRollNumber(rollNumber) {
            var regex = /^[0-9]+$/;
            return regex.test(rollNumber);
        }
    </script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="inner_page" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <asp:Label ID="lbl_frm_Heading" runat="server" Text="Add New Student" Font-Bold="True" Font-Size="18px"></asp:Label>
                </div>
                <div class="panel-body">
                    <br />
                    <table>
                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Name</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_Name" runat="server" Width="198px"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatoName" runat="server"
                                         ControlToValidate="txt_Name" ErrorMessage=" * * Name Required"
                                         ForeColor="Red"> * *  Name Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>
                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Father Name</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_FName" runat="server" Width="198px"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                         ControlToValidate="txt_FName" ErrorMessage=" * * Father Name Required"
                                         ForeColor="Red"> * * Father Name Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>
                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Father CNIC #</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_FCNIC" runat="server" Width="198px"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                         ControlToValidate="txt_FCNIC" ErrorMessage=" * * Father CNIC No Required"
                                         ForeColor="Red"> * * Father CNIC No Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Contact #</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_ContactNo" runat="server" Width="198px"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                         ControlToValidate="txt_ContactNo" ErrorMessage=" * * Contact No Required"
                                         ForeColor="Red"> * * Contact No Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Select Gender</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:DropDownList ID="ddl_Gender" runat="server" Height="29px" Width="195px">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>

                                        &nbsp;
                                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="* * Please Select Gender" InitialValue="0" ControlToValidate="ddl_Gender" runat="server" ErrorMessage="* * Please Select Gender!" />
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Roll No</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_RollNo" runat="server" Width="198px" TextMode="Number"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ControlToValidate="txt_RollNo" ErrorMessage=" * * Roll No Required"
                                         ForeColor="Red"> * * Roll No Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>


                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Select Class</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:DropDownList ID="ddl_Class" runat="server" Height="29px" Width="195px">
                                            <asp:ListItem Value="1">Class 1</asp:ListItem>
                                            <asp:ListItem Value="2">Class 2</asp:ListItem>

                                        </asp:DropDownList>

                                        &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="* * Please Select Class" InitialValue="0" ControlToValidate="ddl_Class" runat="server" ErrorMessage="* * Please Select Class!" />
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Fee</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_Fee" runat="server" Width="198px" TextMode="Number"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                         ControlToValidate="txt_Fee" ErrorMessage=" * * Fee Required"
                                         ForeColor="Red"> * * Fee Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <div class="row">
                                <div class="col-md-3">
                                    <td>Residence Address</td>
                                </div>

                                <div class="col-md-9">
                                    <td>
                                        <asp:TextBox ID="txt_Address" runat="server" Width="198px"
                                            TextMode="MultiLine" Rows="3"></asp:TextBox>
                                        &nbsp;
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                         ControlToValidate="txt_Address" ErrorMessage=" * * Residence Address Required"
                                         ForeColor="Red"> * * Residence Address Required</asp:RequiredFieldValidator>
                                    </td>
                                </div>
                            </div>
                        </tr>

                        <tr>
                            <td colspan="2" align="right">

                                <asp:Button ID="btn_Add" runat="server" Text="Add " Width="127px"
                                    class="btn btn-primary" OnClick="btn_Add_Click" />




                            </td>
                        </tr>

                    </table>



                    <br />

                    <center>
                    </center>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
