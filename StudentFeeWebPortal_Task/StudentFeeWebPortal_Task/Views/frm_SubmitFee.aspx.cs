using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.DAL;
using StudentFeeWebPortal_Task.Models;

namespace StudentFeeWebPortal_Task.Views
{
    public partial class frm_SubmitFee : System.Web.UI.Page
    {
        Cls_Student obj_Cls_Student = new Cls_Student();
        Cls_Fee obj_Cls_Fee = new Cls_Fee();
        string script = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    //obj_Cls_Student.ViewStudent(dgvReport);
                    Cls_Class obj_Cls_Class = new Cls_Class();
                    obj_Cls_Class.BindDataToDropdown(ddl_Class, "ClassName", "Id");

                    DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
                    string[] monthNames = dtfi.MonthNames;

                    ddl_SMonth.DataSource = monthNames.Take(12); // Take the first 12 months
                    ddl_SMonth.DataBind();
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
               List<Student_Model> obj_Student_Model = new List<Student_Model>();
               obj_Cls_Student.SearchStudentForFee(txt_Name.Text, txt_FName.Text, txt_CNIC.Text, ddl_Class.SelectedValue.ToString(), ref obj_Student_Model);

                if (obj_Student_Model!=null)
                {
                    if (obj_Student_Model.Count > 0)
                    {
                        Student_Model student = obj_Student_Model[0]; // Assuming you want to display the first student in the list
                        lbl_StudentID.Text = student.ID.ToString();
                        txt_SName.Text = student.Name;
                        txt_SFName.Text = student.FatherName;
                        txt_SCNIC.Text = student.FatherCNIC;
                        txt_SRollNo.Text = student.RollNo.ToString();
                        txt_SClass.Text = student.Classes.ClassName;
                        txt_SFee.Text = student.Fee.ToString();
                        // Continue for other properties...
                    }
                    else
                    {
                        script = "alert(\"Student not find!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_SubmitFee_Click(object sender, EventArgs e)
        {
            try
            {
                // obj_Cls_Student.SearchStudent(txt_Name.Text, txt_FName.Text, txt_CNIC.Text, ddl_Class.SelectedValue.ToString(), dgvReport);
                Fee_Model obj_Fee_Model = new Fee_Model();
                obj_Fee_Model.StudentID = Convert.ToInt32(lbl_StudentID.Text);
                obj_Fee_Model.FeeMonth = ddl_SMonth.SelectedValue.ToString();
                obj_Fee_Model.FeeAmount = Convert.ToDecimal(txt_SFeeSubmit.Text);
                obj_Fee_Model.SubmittedDate = DateTime.Now;
                obj_Fee_Model.AddedBy= Convert.ToInt32(Session["UserID"].ToString());

                string Res = obj_Cls_Fee.SubmitStudentFee(obj_Fee_Model);

                if (Res.Contains("Add Successfully"))
                {
                    script = "alert(\"Student fee submitted successfully!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    script = Res;
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }

            }
            catch (Exception ex)
            {

               
            }
        }
    }
}