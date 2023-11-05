using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.DAL;

namespace StudentFeeWebPortal_Task
{
    public partial class LogIn : System.Web.UI.Page
    {
        string script = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_UserName.Text))
                {
                    script = "alert(\"Please Enter UserName!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    lbl_Status.Text = "*Please Enter UserName.";
                    lbl_Status.Visible = true;
                }
                else if (string.IsNullOrEmpty(txt_Password.Text))
                {
                    script = "alert(\"Please Enter Password!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    lbl_Status.Text = "*Please Enter Password.";
                    lbl_Status.Visible = true;
                }
                else
                {
                    Cls_User obj_Cls_User = new Cls_User();
                    decimal UserID=0;
                    string Res=  obj_Cls_User.Fun_LogIn(txt_UserName.Text, txt_Password.Text, ref UserID);
                    if (Res.Equals("Successful login"))
                    {
                        Session["UserID"] = UserID;
                        
                        Response.Redirect("Views/frm_ViewStudent.aspx", false);
                    }
                    else 
                    {
                       // lbl_Status.Text = Res;

                        script = "alert(\"*Incorrect User Name & Password!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        lbl_Status.Text = "*Incorrect User Name & Password";
                        lbl_Status.Visible = true;
                    }
                }

               
            }
            catch (Exception ex)
            {
                string eas = ex.Message;
                throw;
            }
        }
    }
}