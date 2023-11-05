using StudentFeeWebPortal_Task.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentFeeWebPortal_Task.Views
{
    public partial class frm_ViewStudent : System.Web.UI.Page
    {
        Cls_Student obj_Cls_Student = new Cls_Student();
        string script = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    obj_Cls_Student.ViewStudent(dgvReport);
                    Cls_Class obj_Cls_Class = new Cls_Class();
                    obj_Cls_Class.BindDataToDropdown(ddl_Class, "ClassName", "Id");
                }
            }
            catch (Exception)
            {

               
            }
        }

        protected void dgvReport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (e.NewEditIndex >= 0 && e.NewEditIndex < dgvReport.Rows.Count)
            {
                decimal studentID = Convert.ToInt32(dgvReport.DataKeys[e.NewEditIndex].Value);

                Session["UpdateStudent"] = "True";
                Session["StudentID"] = studentID;

                Response.Redirect("frm_AddStudent.aspx", false);
            }
           
        }


        protected void dgvReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.RowIndex < dgvReport.Rows.Count)
                {
                    decimal studentID = Convert.ToInt32(dgvReport.DataKeys[e.RowIndex].Value);
                    string Res= obj_Cls_Student.DeleteStudent(studentID);
                    if (Res.Contains("Successfully"))
                    {
                        script = "alert(\"Student delete successfully!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);

                        obj_Cls_Student.ViewStudent(dgvReport);
                    }
                    else
                    {
                        script = Res;
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                }
                else
                {
                    // Handle invalid row index (optional)
                }


            }
            catch (Exception ex)
            {

               
            }
            
        }

        protected void dgvReport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvReport.EditIndex = -1;
            // Rebind the GridView to exit edit mode
            // For example:
            // DataTable dt = GetDataFromDatabase();
            // GridView1.DataSource = dt;
            // GridView1.DataBind();
        }

        protected void dgvReport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idToUpdate = Convert.ToInt32(dgvReport.DataKeys[e.RowIndex].Value);
            string updatedName = ((TextBox)dgvReport.Rows[e.RowIndex].FindControl("TextBoxName")).Text;
            string updatedEmail = ((TextBox)dgvReport.Rows[e.RowIndex].FindControl("TextBoxEmail")).Text;

            // Perform update operation (e.g., using Entity Framework)
            // For example:
            // UpdateRecordInDatabase(idToUpdate, updatedName, updatedEmail);

            dgvReport.EditIndex = -1;
            // Rebind the GridView after update
            // For example:
            // DataTable dt = GetDataFromDatabase();
            // GridView1.DataSource = dt;
            // GridView1.DataBind();
        }

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                obj_Cls_Student.SearchStudent(txt_Name.Text, txt_FName.Text,txt_CNIC.Text, ddl_Class.SelectedValue.ToString(), dgvReport);
            }
            catch (Exception ex)
            {

               
            }
        }
    }
}