<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="StudentFeeWebPortal_Task.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">

        window.onload = window.history.forward(0);  //calling function on window onload

    </script>


    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>LogIn</title>
    <!-- BOOTSTRAP STYLES-->
    <link href="../../assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="../../assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLES-->
    <link href="../../assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <style>
        #LogInfooter {
            position: relative;
            bottom: 0;
            width: 100%;
            height: 40px;
            display: block;
            margin-top: 100px; /* Height of the footer */
        }

        body {
            background-color: #ffffff;
        }
    </style>

    <script>
        function validateForm() {
            var nameField = document.getElementById('<%= txt_UserName.ClientID %>');
            var passwordField = document.getElementById('<%= txt_Password.ClientID %>');
            if (nameField.value.trim() === "") {
                alert("UserName cannot be empty");
                return false;
            }
            else if (passwordField.value.trim() === "") {
                alert("Password cannot be empty");
                return false;
            }
            else if (isValidUsername(nameField)) {
                console.log("Valid username, only alphabets allow ");
            }

            return true;
        }

        function isValidUsername(username) {
            return /^[A-Za-z]+$/.test(username);
        }
    </script>



</head>
<body>

    <div class="row" style="width: 100%">
        <center>

            <div class="col-md-12" style="margin-top: 20px; text-align: center">
                <asp:Label ID="Label2" runat="server" Text="Student Fee Managment " Font-Size="45pt" Font-Names="Algerian" ForeColor="#0086C5"></asp:Label>

            </div>
        </center>

    </div>

    <br />

    <form id="form1" runat="server">


        <div class="container">

            <div class="row text-center ">
                <div class="col-md-12">

                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Names="Algerian" Font-Size="35pt" Font-Underline="False" Text="LogIn" ForeColor="#0086C5"></asp:Label>

                </div>
            </div>

            <div class="row " id="Log">

                <%--       <div class="col-md-2">
                        <img src="assets/img/H1png.png" style="width: 300px;height:220px;margin-right:20px" />
                    </div>  --%>


                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <strong>Enter Details To Login </strong>
                        </div>
                        <div class="panel-body">
                            <form role="form">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatoName" runat="server"
                                    ControlToValidate="txt_UserName" ErrorMessage=" * *  User Name Required"
                                    ForeColor="Red"> * * User Name Required</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txt_Password" ErrorMessage=" * *  Password Required"
                                    ForeColor="Red"> * * Password Required</asp:RequiredFieldValidator>
                                <div class="form-group input-group" style="padding-top: 10px">
                                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                    <asp:TextBox ID="txt_UserName" runat="server" class="form-control" placeholder="Your Username " ViewStateMode="Disabled"></asp:TextBox>

                                </div>
                                <div class="form-group input-group" style="padding-top: 10px">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <asp:TextBox ID="txt_Password" runat="server" class="form-control" placeholder="Your Password " TextMode="Password"></asp:TextBox>

                                    <%--<input type="password" class="form-control"  placeholder="Your Password" />--%>
                                </div>

                                <div style="padding-top: 10px">
                                    <asp:Button ID="btnLogIn" runat="server" Text="LogIn" class="btn btn-success "
                                        Width="120px" BackColor="#0086C5" OnClick="btnLogIn_Click" OnClientClick="return validateForm();"/>
                                </div>
                                <div class="form-group">

                                    <asp:Label ID="lbl_Status" runat="server" Text="lbl_Status" class="pull-right" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>

                                </div>
                                <br />
                            </form>
                        </div>

                    </div>
                </div>




            </div>

            <%--    <div >           
             <img src="Pictures/estee%20.png" style="height: 50px; width: 114px; margin-top: 15px; margin-left:15px; margin-right: 5px" />
        </div>--%>
        </div>



    </form>
    <div id="LogInfooter">
        <%--<center>           
             &nbsp;<asp:Label ID="Label4" runat="server" Text="Powerd By :" Font-Size="10pt" ForeColor="#006600" Font-Bold="True"></asp:Label>
         <a href="http://www.esscom.com.pk/"> <asp:Label ID="Label5" runat="server" Text="http://IT Applications" Font-Size="10pt" ForeColor="Red" Font-Bold="True"></asp:Label></a>
            &nbsp;</center>--%>
    </div>

    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>

</body>
</html>
