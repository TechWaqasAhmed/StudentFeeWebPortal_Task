using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.DAL;

namespace StudentFeeWebPortal_Task.Views
{
    public partial class frm_FeeStatus : System.Web.UI.Page
    {
        Cls_Fee obj_Cls_Fee = new Cls_Fee();
        string script = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
                    string[] monthNames = dtfi.MonthNames;

                    ddl_FeeMonth.DataSource = monthNames.Take(12); // Take the first 12 months
                    ddl_FeeMonth.DataBind();
                }
            }
            catch (Exception)
            {

                
            }
        }


        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Res = obj_Cls_Fee.SearchStudent(txt_Name.Text, txt_FName.Text, txt_CNIC.Text, ddl_FeeMonth.SelectedValue.ToString(), dgvReport);
               
                if (Res.Contains("Successfully"))
                {
                    script = "alert(\"Student fee submit successfully!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    dgvReport.Visible = true;
                }
                else
                {
                    script = Res;
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    dgvReport.Visible = false;
                }



            }
            catch (Exception ex)
            {

               
            }
        }
    }
}