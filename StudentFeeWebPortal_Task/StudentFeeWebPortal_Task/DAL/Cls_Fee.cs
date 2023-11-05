using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.Models;

namespace StudentFeeWebPortal_Task.DAL
{
    public class Cls_Fee
    {
        public string SubmitStudentFee(Fee_Model obj_Fee_Model)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {

                    bool userExists = context.Fee.Any(u => u.StudentID == obj_Fee_Model.StudentID && u.FeeMonth == obj_Fee_Model.FeeMonth && u.FeeAmount == obj_Fee_Model.FeeAmount);

                    if (!userExists)
                    {
                        // Create and configure your entity
                        Fee_Model newStudentFee = new Fee_Model
                        {

                            StudentID = obj_Fee_Model.StudentID,
                            FeeMonth = obj_Fee_Model.FeeMonth,
                            FeeAmount = obj_Fee_Model.FeeAmount,
                            SubmittedDate = obj_Fee_Model.SubmittedDate,
                            AddedBy = obj_Fee_Model.AddedBy,
                        };

                        // Add the entity to the DbSet
                        context.Fee.Add(newStudentFee);

                        // Save changes to the database
                        context.SaveChanges();
                        Res = "Add Successfully";
                    }
                    else
                    {
                        // Handle case where user already exists
                        // You might display an error message to the user
                        Res = "Student fee already exists";
                    }
                }
            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }
            return Res;
        }


      

        public string SearchStudent(string Name, string FName, string CNIC, string FeeMonth, GridView gridView)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {
                    var query = from student in context.Student
                                join classInfo in context.Classes on student.ClassID equals classInfo.ID
                                join feeInfo in context.Fee on student.ID equals feeInfo.StudentID
                                where (string.IsNullOrEmpty(Name) || student.Name == Name)
                                   && (string.IsNullOrEmpty(FName) || student.FatherName == FName)
                                   && (string.IsNullOrEmpty(CNIC) || student.FatherCNIC == CNIC)
                                   && (string.IsNullOrEmpty(FeeMonth) || feeInfo.FeeMonth == FeeMonth)
                                select new
                                {
                                    StudentID = student.ID,
                                    student.Name,
                                    student.FatherName,
                                    student.FatherCNIC,
                                    student.ContactNo,
                                    student.RollNo,
                                    student.ClassID,
                                    student.Fee,
                                    student.ResidenceAddress,
                                    student.AdminDate,
                                    student.LastUpdateDate,
                                    student.AddedBy,
                                    student.Gender,
                                    ClassName = classInfo.ClassName
                                };

                    var recordsExist = query.Any();

                    if (recordsExist)
                    {
                        gridView.DataSource = query.ToList();
                        gridView.DataBind();
                        Res = "Successfully";
                    }
                    else
                    {
                        Res = "Not Find, student fee not submitted for the month of "+ FeeMonth;
                    }
                }
            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }

            return Res;
        }


    }
}