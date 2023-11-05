using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.DAL;
using StudentFeeWebPortal_Task.Models;
namespace StudentFeeWebPortal_Task.Views
{
    public partial class frm_AddStudent : System.Web.UI.Page
    {
        static decimal StudentID = 0;
        static bool IsUpdate = false;
        string script = "";

        Cls_Student obj_Cls_Student = new Cls_Student();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UpdateStudent"] != null)
                {
                    
                    decimal userID = Convert.ToInt32(Session["UserID"]);
                    StudentID= Convert.ToInt32(Session["StudentID"]);
                    lbl_frm_Heading.Text = "update Student";
                    IsUpdate = true;

                    GetStudentData(StudentID);
                    btn_Add.Text = "Update Student";
                    btn_Add.CssClass = "btn btn-success";

                }
                else
                {
                    lbl_frm_Heading.Text = "Add New Student";
                    IsUpdate = false;

                    btn_Add.Text = "Add Student";
                    btn_Add.CssClass = "btn btn-primary";

                }
             
                


                Cls_Class obj_Cls_Class = new Cls_Class();
                obj_Cls_Class.BindDataToDropdown(ddl_Class, "ClassName", "Id");
            }
        }
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsUpdate)
                {
                    Student_Model obj_Student_Model = new Student_Model();
                    Cls_Student obj_Cls_Student = new Cls_Student();

                    obj_Student_Model.Name = txt_Name.Text;
                    obj_Student_Model.FatherName = txt_FName.Text;

                    obj_Student_Model.FatherCNIC = txt_FCNIC.Text;
                    obj_Student_Model.ContactNo = txt_ContactNo.Text;
                    obj_Student_Model.RollNo = Convert.ToInt32(txt_RollNo.Text);
                    obj_Student_Model.ClassID = Convert.ToInt32(ddl_Class.SelectedValue);
                    obj_Student_Model.Fee = Convert.ToInt32(txt_Fee.Text);
                    obj_Student_Model.ResidenceAddress = txt_Address.Text;
                    obj_Student_Model.AdminDate = DateTime.Now;
                    obj_Student_Model.LastUpdateDate = DateTime.Now;
                    obj_Student_Model.AddedBy = Convert.ToInt32(Session["UserID"].ToString());
                    obj_Student_Model.Gender = ddl_Gender.SelectedValue.ToString();
                    string Res = obj_Cls_Student.AddNewStudent(obj_Student_Model);


                    if (Res.Contains("Add Successfully"))
                    {
                        script = "alert(\"Student add successfully!\");";
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
                else
                {
                    Student_Model obj_Student_Model = new Student_Model();                   

                    obj_Student_Model.Name = txt_Name.Text;
                    obj_Student_Model.FatherName = txt_FName.Text;

                    obj_Student_Model.FatherCNIC = txt_FCNIC.Text;
                    obj_Student_Model.ContactNo = txt_ContactNo.Text;
                    obj_Student_Model.RollNo = Convert.ToInt32(txt_RollNo.Text);
                    obj_Student_Model.ClassID = Convert.ToInt32(ddl_Class.SelectedValue);
                    obj_Student_Model.Fee = Convert.ToInt32(txt_Fee.Text);
                    obj_Student_Model.ResidenceAddress = txt_Address.Text;
                    //obj_Student_Model.AdminDate = DateTime.Now;
                    obj_Student_Model.LastUpdateDate = DateTime.Now;
                    obj_Student_Model.AddedBy = Convert.ToInt32(Session["UserID"].ToString());
                    obj_Student_Model.Gender = ddl_Gender.SelectedValue.ToString();
                    string Res = obj_Cls_Student.UpdateStudent(obj_Student_Model, StudentID);

                    if (Res.Contains("Add Successfully"))
                    {
                        script = "alert(\"Student update successfully!\");";
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
            }
            catch (Exception ex)
            {

              
            }
        }
    
        
        public void GetStudentData(decimal StudentID)
        {
            try
            {
                Student_Model student_Model = null;

                obj_Cls_Student.FindStudent(StudentID, ref student_Model);

                if (student_Model!=null)
                {
                    txt_Name.Text = student_Model.Name;
                    txt_FName.Text = student_Model.FatherName;
                    txt_FCNIC.Text = student_Model.FatherCNIC;
                    txt_ContactNo.Text = student_Model.ContactNo;
                    txt_RollNo.Text = student_Model.RollNo.ToString();
                    //txt_ClassID
                    txt_Fee.Text = Convert.ToInt32(student_Model.Fee).ToString();
                    txt_Address.Text = student_Model.ResidenceAddress;
                    //ddl_Gender


                    ListItem selectedItem = ddl_Class.Items.FindByValue(student_Model.ClassID.ToString());
                    if (selectedItem != null)
                    {
                        // Set the Selected property to true
                        selectedItem.Selected = true;
                    }

                    ListItem selectedItem2 = ddl_Gender.Items.FindByValue(student_Model.Gender.ToString());
                    if (selectedItem2 != null)
                    {
                        // Set the Selected property to true
                        selectedItem2.Selected = true;
                    }
                }

            }
            catch (Exception)
            {

                
            }
        }

    
    
    }

       
}