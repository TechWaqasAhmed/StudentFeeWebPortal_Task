using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StudentFeeWebPortal_Task.Models;

namespace StudentFeeWebPortal_Task.DAL
{
    public class Cls_Student
    {
        public string AddNewStudent(Student_Model obj_Student_Model)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {

                    bool userExists = context.Student.Any(u => u.Name == obj_Student_Model.Name && u.FatherCNIC == obj_Student_Model.FatherCNIC);


                    if (!userExists)
                    {
                        // Create and configure your entity
                        Student_Model newStudent = new Student_Model
                        {
                            //ID = obj_Student_Model.ID,
                            Name = obj_Student_Model.Name,
                            FatherName = obj_Student_Model.FatherName,
                            FatherCNIC = obj_Student_Model.FatherCNIC,
                            ContactNo = obj_Student_Model.ContactNo,
                            RollNo = obj_Student_Model.RollNo,
                            ClassID = obj_Student_Model.ClassID,
                            Fee = obj_Student_Model.Fee,
                            ResidenceAddress = obj_Student_Model.ResidenceAddress,
                            AdminDate = obj_Student_Model.AdminDate,
                            LastUpdateDate = obj_Student_Model.LastUpdateDate,
                            AddedBy = obj_Student_Model.AddedBy,
                            Gender = obj_Student_Model.Gender
                        };

                        // Add the entity to the DbSet
                        context.Student.Add(newStudent);

                        // Save changes to the database
                        context.SaveChanges();

                        Res = "Add Successfully";
                    }
                    else
                    {
                        // Handle case where user already exists
                        // You might display an error message to the user
                        Res = "Student already exists";
                    }
                }

            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }

            return Res;
        }

        public string ViewStudent(GridView gridView)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {
                    var query = from student in context.Student
                                join classInfo in context.Classes on student.ClassID equals classInfo.ID
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

                    gridView.DataSource = query.ToList();
                    gridView.DataBind();

                    Res = "Successfully";
                }
            }
            catch (Exception ex)
            {
                Res = ex.Message;
            }

            return Res;
        }

        public string DeleteStudent(decimal StudentID)
        {
            string Res = "";
            try
            {
                using ( var context = new Cls_DbContext())
                {
                    var studentData = (from student in context.Student
                                       where (string.IsNullOrEmpty(StudentID.ToString()) || student.ID == StudentID)
                                       select new
                                       {
                                           student.ID,
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
                                           student.Gender
                                       }).FirstOrDefault();

                    Student_Model studentToDelete = null;

                    if (studentData != null)
                    {
                        studentToDelete = new Student_Model
                        {
                            ID = studentData.ID,
                            Name = studentData.Name,
                            FatherName = studentData.FatherName,
                            FatherCNIC = studentData.FatherCNIC,
                            ContactNo = studentData.ContactNo,
                            RollNo = studentData.RollNo,
                            ClassID = studentData.ClassID,
                            Fee = studentData.Fee,
                            ResidenceAddress = studentData.ResidenceAddress,
                            AdminDate = studentData.AdminDate,
                            LastUpdateDate = studentData.LastUpdateDate,
                            AddedBy = studentData.AddedBy,
                            Gender = studentData.Gender
                        };
                    }





                    if (studentToDelete != null)
                    {
                        context.Student.Attach(studentToDelete);
                        context.Student.Remove(studentToDelete);
                        context.SaveChanges();

                        Res = "Successfully";

                    }
                    else
                    {
                        Res = "Not find";
                    }
                }


            }
            catch (Exception ex)
            {
                Res = ex.Message;
            }

            return Res;
        }

        public string FindStudent(decimal StudentID, ref Student_Model obj_Student_Model)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {
                    Student_Model studentToDelete = context.Student.Find(StudentID);

                    if (studentToDelete != null)
                    {
                        obj_Student_Model = studentToDelete;

                        Res = "Successfully";
                    }
                    else
                    {
                        Res = "Not Find";
                    }
                }
            }
            catch (Exception ex)
            {
                Res = ex.Message;

            }

            return Res;
        }

        public string UpdateStudent(Student_Model obj_Student_Model, decimal StudentID)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {
                    Student_Model studentToUpdate = context.Student.Find(StudentID);

                    if (studentToUpdate != null)
                    {

                        studentToUpdate.Name = obj_Student_Model.Name;
                        studentToUpdate.FatherName = obj_Student_Model.FatherName;
                        studentToUpdate.FatherCNIC = obj_Student_Model.FatherCNIC;
                        studentToUpdate.ContactNo = obj_Student_Model.ContactNo;
                        studentToUpdate.RollNo = obj_Student_Model.RollNo;
                        studentToUpdate.ClassID = obj_Student_Model.ClassID;
                        studentToUpdate.Fee = obj_Student_Model.Fee;
                        studentToUpdate.ResidenceAddress = obj_Student_Model.ResidenceAddress;
                        // studentToUpdate.AdminDate = obj_Student_Model.AdminDate;
                        studentToUpdate.LastUpdateDate = obj_Student_Model.LastUpdateDate;
                        studentToUpdate.AddedBy = obj_Student_Model.AddedBy;
                        studentToUpdate.Gender = obj_Student_Model.Gender;
                        context.SaveChanges(); // Save changes to commit the update
                        Res = "Successfully";
                    }
                    else
                    {
                        Res = "Not Find";
                    }

                }

            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }

            return Res;
        }

        public string SearchStudent(string Name, string FName, string CNIC, string ClassID, GridView gridView)
        {
            string Res = "";
            try
            {
                using (var context = new Cls_DbContext())
                {
                    var query = from student in context.Student
                                join classInfo in context.Classes on student.ClassID equals classInfo.ID
                                where (string.IsNullOrEmpty(Name) || student.Name.Contains(Name))
                                   && (string.IsNullOrEmpty(FName) || student.FatherName.Contains(FName))
                                   && (string.IsNullOrEmpty(CNIC) || student.FatherCNIC.Contains(CNIC))
                                   && (ClassID == null || student.ClassID.ToString().Contains(ClassID.ToString()))
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
                        Res = "Not Find";
                    }


                }


            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }

            return Res;
        }

        public string SearchStudentForFee(string Name, string FName, string CNIC, string ClassID, ref List<Student_Model> obj_Student_Model)
        {
            string Res = "";
            try
            {
                obj_Student_Model = new List<Student_Model>();
                using (var context = new Cls_DbContext())
                {

                    var query = from student in context.Student
                                join classInfo in context.Classes on student.ClassID equals classInfo.ID
                                where (string.IsNullOrEmpty(Name) || student.Name.Contains(Name))
                                   && (string.IsNullOrEmpty(FName) || student.FatherName.Contains(FName))
                                   && (string.IsNullOrEmpty(CNIC) || student.FatherCNIC.Contains(CNIC))
                                   && (ClassID == null || student.ClassID.ToString().Contains(ClassID.ToString()))
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
                        var anonymousList = query.ToList();

                        obj_Student_Model = anonymousList.Select(item => new Student_Model
                        {
                            ID = item.StudentID,
                            Name = item.Name,
                            FatherName = item.FatherName,
                            FatherCNIC = item.FatherCNIC,
                            ContactNo = item.ContactNo,
                            RollNo = item.RollNo,
                            ClassID = item.ClassID,
                            Fee = item.Fee,
                            ResidenceAddress = item.ResidenceAddress,
                            AdminDate = item.AdminDate,
                            LastUpdateDate = item.LastUpdateDate,
                            AddedBy = item.AddedBy,
                            Gender = item.Gender,
                            Classes = new Class_Model
                            {
                                ClassName = item.ClassName
                            }
                        }).ToList();

                        Res = "Successfully";
                    }
                    else
                    {
                        Res = "Not Find";
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