using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudentFeeWebPortal_Task.Models;

namespace StudentFeeWebPortal_Task.DAL
{
    public class Cls_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Class_Model> Classes { get; set; }

        public DbSet<Student_Model> Student { get; set; }

        public DbSet<Fee_Model> Fee { get; set; }
        // Constructor with connection string
        public Cls_DbContext() : base("name=strCon_StudentFee")
        {
        }
    }
}