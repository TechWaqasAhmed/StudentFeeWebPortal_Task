using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentFeeWebPortal_Task.Models
{

    [Table("Tbl_User")]
    public class User
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}